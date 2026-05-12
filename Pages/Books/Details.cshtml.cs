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
    public class DetailsModel : PageModel
    {
        private readonly CIDM_3312_Final_Project.Models.AppDbContext _context;

        public DetailsModel(CIDM_3312_Final_Project.Models.AppDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FirstOrDefaultAsync(m => m.BookID == id);

            if (book is not null)
            {
                Book = book;

                return Page();
            }

            return NotFound();
        }
    }
}
