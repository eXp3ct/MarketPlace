using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Ksu.Market.Api
{
	/// <summary>
	///
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Точка входа в программу
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			host.Run();
		}

		/// <summary>
		/// Настройка хоста
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
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