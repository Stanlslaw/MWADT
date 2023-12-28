using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace UWSR.Pages.Auth
{
    public class CreateModel : PageModel
    {
        private readonly UWSR.Data.AppDbContext _context;

        public CreateModel(UWSR.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public string Password { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (_context.Links == null || Password == null)
            {
                return Page();
            }
            if (Password == "1111")
            {
                HttpContext.Session.Set("isAdmin", Encoding.UTF8.GetBytes("true"));
            }
            return RedirectToPage("./Index");
        }
    }
}
