namespace Ksu.Market.Api
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
		}
	}
}
