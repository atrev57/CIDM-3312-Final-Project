using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIDM_3312_Final_Project;
using CIDM_3312_Final_Project.Models;

namespace CIDM_3312_Final_Project.Pages_Books
{
    public class IndexModel : PageModel
    {
        private readonly CIDM_3312_Final_Project.Models.AppDbContext _context;

        public IndexModel(CIDM_3312_Final_Project.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.User).ToListAsync();
        }
    }
}
