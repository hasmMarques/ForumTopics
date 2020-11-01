using System.Threading.Tasks;
using _4TuneForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _4TuneForum.Pages
{
	public class DeleteModel : PageModel
	{
		#region Fields

		private readonly aspnet_4TuneForumContext _context;

		#endregion

		#region Properties

		[BindProperty]
		public Topics Topics { get; set; }

		#endregion

		#region Constructor

		public DeleteModel(aspnet_4TuneForumContext context)
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

			if (Topics.CreatorNavigation.UserName != User.Identity.Name)
				return Unauthorized();

			if (Topics == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Topics = await _context.Topics.FindAsync(id);

			if (Topics != null)
			{
				_context.Topics.Remove(Topics);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}

		#endregion
	}
}