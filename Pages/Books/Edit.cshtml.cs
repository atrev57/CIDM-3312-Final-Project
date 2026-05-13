using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIDM_3312_Final_Project;
using CIDM_3312_Final_Project.Models;

namespace CIDM_3312_Final_Project.Pages_Books
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // Add this to hold your enum options
        public SelectList StatusOptionsList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books.FirstOrDefaultAsync(m => m.BookID == id);
            if (book == null) return NotFound();
            
            Book = book;

            // Populate the dropdowns
            StatusOptionsList = new SelectList(Enum.GetValues(typeof(Book.StatusOptions)));
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email");
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Crucial: Ignore the User navigation property so validation passes
            ModelState.Remove("Book.User");

            if (!ModelState.IsValid)
            {
                // Must re-populate dropdowns if returning to the page
                StatusOptionsList = new SelectList(Enum.GetValues(typeof(Book.StatusOptions)));
                ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email");
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.BookID)) return NotFound();
                else throw;
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }
    }
}
