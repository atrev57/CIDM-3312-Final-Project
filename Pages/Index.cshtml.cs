using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CIDM_3312_Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
    }

    public List<Book> Books { get;set; } = default!;

    public void OnGet()
    {
        Books = _context.Books
            .Include(b => b.BookReviews)
                .ThenInclude(br => br.Review)
            .ToList();
    }
}
