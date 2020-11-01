using System.Threading.Tasks;
using _4TuneForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _4TuneForum.Pages
{
	public class DetailsModel : PageModel
	{
		#region Fields

		private readonly aspnet_4TuneForumContext _context;

		#endregion

		#region Properties

		public Topics Topics { get; set; }

		#endregion

		#region Constructor

		public DetailsModel(aspnet_4TuneForumContext context)
		{
			_context = context;
		}

		#endregion

		#region Public Methods

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Topics = await _context.Topics
				.Include(t => t.CreatorNavigation).FirstOrDefaultAsync(m => m.Id == id);

			if (Topics == null)
			{
				return NotFound();
			}

			return Page();
		}

		#endregion
	}
}