using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIDM_3312_Final_Project;
using CIDM_3312_Final_Project.Models;

namespace CIDM_3312_Final_Project.Pages_Books
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = new();

        [BindProperty]
        public string UsernameInput { get; set; } = string.Empty;

        public SelectList StatusOptionsList { get; set; } = default!;

        public IActionResult OnGet()
        {
            StatusOptionsList = GetStatusList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            StatusOptionsList = GetStatusList();

            ModelState.Remove("Book.BookID");

            ModelState.Remove("Book.User"); 
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Find user by username
            var user = _context.Users
                .FirstOrDefault(u => u.Username == UsernameInput);

            // If not found, return error
            if (user == null)
            {
                ModelState.AddModelError("UsernameInput",
                    "User not found. Please create the user first.");

                return Page();
            }

            // Assign Foreign Key 
            Book.UserID = user.UserID;

            // Save book
            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private SelectList GetStatusList()
        {
            return new SelectList(Enum.GetValues(typeof(Book.StatusOptions)));
        }
    }
}