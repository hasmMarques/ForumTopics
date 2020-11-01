using _4TuneForum.Areas.Identity;
using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace _4TuneForum.Areas.Identity
{
	public class IdentityHostingStartup : IHostingStartup
	{
		#region Public Methods

		public void Configure(IWebHostBuilder builder)
		{
			builder.ConfigureServices((context, services) => { });
		}

		#endregion
	}
}