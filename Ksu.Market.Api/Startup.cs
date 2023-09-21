using Ksu.Market.Api.Middlewares;
using Ksu.Market.Data;
using Ksu.Market.Domain.Models.Options;
using Ksu.Market.Infrastructure;
using MassTransit;

namespace Ksu.Market.Api
{
	/// <summary>
	/// Конфигурация
	/// </summary>
	public class Startup
	{
		private readonly IConfiguration _configuration;

		/// <summary>
		/// Внедрение зависимостей
		/// </summary>
		/// <param name="configuration"></param>
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		/// <summary>
		/// Конфигурация приложения
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseMiddleware<ErrorHandlingMiddleware>();

			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		/// <summary>
		/// Регистрация сервисов
		/// </summary>
		/// <param name="services"></param>
		/// <exception cref="InvalidOperationException"></exception>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<ErrorHandlingMiddleware>();
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			services.AddPersistance();
			services.AddInfrastructure();
			SwaggerOptions.Configure(services);
			services.AddMassTransit(cfg =>
			{
				cfg.SetKebabCaseEndpointNameFormatter();
				cfg.AddDelayedMessageScheduler();
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