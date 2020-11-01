using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4TuneForum.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _4TuneForum.Pages
{
	public class IndexModel : PageModel
	{
		#region Fields

		private readonly aspnet_4TuneForumContext _context;

		#endregion

		#region Properties

		public IList<Topics> Topics { get; set; }

		#endregion

		#region Constructor

		public IndexModel(aspnet_4TuneForumContext context)
		{
			_context = context;
		}

		#endregion

		#region Public Methods

		public async Task OnGetAsync()
		{
			Topics = await _context.Topics.OrderByDescending(x=>x.CreationDate)
				.Include(t => t.CreatorNavigation).ToListAsync();
		}

		#endregion
	}
}