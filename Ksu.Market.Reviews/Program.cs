using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Ksu.Market.Reviews
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
					var outputTemplate = "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}";
					cfg
						.MinimumLevel.Debug()
						.WriteTo.Console(outputTemplate: outputTemplate, theme: AnsiConsoleTheme.Code)
						.WriteTo.File("logs.txt", outputTemplate: outputTemplate, restrictedToMinimumLevel: LogEventLevel.Information);
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}