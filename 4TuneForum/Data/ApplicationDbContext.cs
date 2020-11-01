using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _4TuneForum.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		#region Constructor

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		#endregion
	}
}