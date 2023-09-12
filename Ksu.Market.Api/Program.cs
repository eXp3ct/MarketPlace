
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Ksu.Market.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseSerilog((contxt, cfg) =>
				{
					cfg
						.MinimumLevel.Debug()
						.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Code);
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}