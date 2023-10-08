using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Networks;
using Ksu.Market.Domain.Contracts;
using Ksu.Market.Domain.Results;
using Ksu.Market.Infrastructure;
using Ksu.Market.Testing.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace Ksu.Market.Testing.Fixtures
{
	public class IntegrationTestFactory<TProgram, TDbContext> : WebApplicationFactory<TProgram>, IAsyncLifetime
		where TProgram : class
		where TDbContext : DbContext
	{
		private readonly PostgreSqlContainer _postgresContainer;
		private readonly INetwork _network;

		public IntegrationTestFactory()
		{
			_network = new NetworkBuilder()
				.WithName("test-network")
				.WithDriver(DotNet.Testcontainers.Configurations.NetworkDriver.Bridge)
				.Build();

			_postgresContainer = new PostgreSqlBuilder()
				.WithName("market-postgres-test")
				.WithImage("postgres:15")
				.WithDatabase("postgres")
				.WithUsername("root")
				.WithPassword("root")
				.WithHostname("postgres")
				.WithPortBinding(5431, 5432)
				.WithNetwork(_network)
				.Build();
		}

		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.UseEnvironment("Testing");
			builder.ConfigureTestServices(services =>
			{
				services.AddInfrastructure();
				services.RemoveDbContext<TDbContext>();
				services.AddMassTransitTestHarness(cfg =>
				{
					cfg.AddHandler<IGetProductPagedListRequired>(async cxt =>
					{
						await cxt.RespondAsync(new OperationResult());
					});
				});
				services.AddDbContext<TDbContext>(options =>
				{
					var connectionString = _postgresContainer.GetConnectionString();
					options.UseNpgsql(connectionString);
				});
				services.EnsureDbCreated<TDbContext>();
			});
		}

		public async Task InitializeAsync()
		{
			await _postgresContainer.StartAsync();
		}

		async Task IAsyncLifetime.DisposeAsync()
		{
			await _postgresContainer.DisposeAsync();
		}
	}
}
