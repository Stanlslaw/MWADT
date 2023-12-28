using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UWSR.Data;
using UWSR.Models;

namespace UWSR.Pages.Lnk
{
    public class IndexModel : PageModel
    {
        private readonly UWSR.Data.AppDbContext _context;

        public IndexModel(UWSR.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Link> Link { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Links != null)
            {
                Link = await _context.Links.ToListAsync();
            }
        }
    }
}
