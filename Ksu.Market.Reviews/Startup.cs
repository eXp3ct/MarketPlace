using Ksu.Market.Data;
using Ksu.Market.Domain.Models.Options;
using Ksu.Market.Infrastructure;
using MassTransit;
using System.Reflection;

namespace Ksu.Market.Reviews
{
	public class Startup
	{
		public IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddPersistance();
			services.AddInfrastructure();
			services.AddMassTransit(cfg =>
			{
				cfg.SetKebabCaseEndpointNameFormatter();
				cfg.AddDelayedMessageScheduler();
				cfg.AddConsumers(Assembly.GetExecutingAssembly());
				cfg.UsingRabbitMq((context, config) =>
				{
					var rabbitMqConfig = _configuration
					.GetSection("RabbitMqOptions")
					.Get<RabbitMqOptions>()
					?? throw new InvalidOperationException("Cannot create RabbitMq configuration");

					config.Host(rabbitMqConfig.Host, "/", host =>
					{
						host.Username(rabbitMqConfig.Username);
						host.Password(rabbitMqConfig.Password);
					});

					config.UseMessageRetry(retry =>
					{
						retry.Incremental(3, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
					});
					config.UseDelayedMessageScheduler();
					config.ConfigureEndpoints(context);
				});
			});
		}
	}
}