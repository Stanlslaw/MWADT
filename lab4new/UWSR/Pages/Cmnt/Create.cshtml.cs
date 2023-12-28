using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using UWSR.Models;

namespace UWSR.Pages.Cmnt
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
        public Comment Comment { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int id)
        {
            HttpContext.Session.Set("CreateComment", Encoding.UTF8.GetBytes("true"));

            var link = _context.Links.Where(x => x.Id == id).FirstOrDefault();
            if (_context.Comments == null || Comment == null || link == null)
            {
                return Page();
            }
            Comment.SessionId = this.HttpContext.Session.Id;
            Comment.Link = link;
            _context.Comments.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Lnk/Index");
        }
    }
}
