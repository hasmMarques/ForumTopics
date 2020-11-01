using System.Linq;
using System.Threading.Tasks;
using _4TuneForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _4TuneForum.Pages
{
	public class EditModel : PageModel
	{
		#region Fields

		private readonly aspnet_4TuneForumContext _context;

		#endregion

		#region Properties

		[BindProperty]
		public Topics Topics { get; set; }

		#endregion

		#region Constructor

		public EditModel(aspnet_4TuneForumContext context)
		{
			_context = context;
		}

		#endregion

		#region Public Methods

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
				return NotFound();

			Topics = await _context.Topics
				.Include(t => t.CreatorNavigation).FirstOrDefaultAsync(m => m.Id == id);

			if (Topics.CreatorNavigation.UserName != User.Identity.Name)
				return Unauthorized();

			if (Topics == null)
				return NotFound();

			ViewData["Creator"] = new SelectList(_context.AspNetUsers, "Id", "Id");
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
				return Page();

			_context.Attach(Topics).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TopicsExists(Topics.Id))
					return NotFound();

				throw;
			}

			return RedirectToPage("./Index");
		}

		#endregion

		#region Private Methods

		private bool TopicsExists(int id)
		{
			return _context.Topics.Any(e => e.Id == id);
		}

		#endregion
	}
}