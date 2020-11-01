using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace _4TuneForum
{
	public class Program
	{
		#region Public Methods

		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

		#endregion
	}
}