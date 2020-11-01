using System;
using System.Linq;
using System.Threading.Tasks;
using _4TuneForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _4TuneForum.Pages
{
	public class CreateModel : PageModel
	{
		#region Fields

		private readonly aspnet_4TuneForumContext _context;

		#endregion

		#region Properties

		[BindProperty]
		public Topics Topics { get; set; }

		#endregion

		#region Constructor

		public CreateModel(aspnet_4TuneForumContext context)
		{
			_context = context;
		}

		#endregion

		#region Public Methods

		public IActionResult OnGet()
		{
			ViewData["Creator"] = new SelectList(_context.AspNetUsers.Where(x => x.UserName == User.Identity.Name),
				"Id", "Id");
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			Topics.CreationDate = DateTime.Now;
			_context.Topics.Add(Topics);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}

		#endregion
	}
}