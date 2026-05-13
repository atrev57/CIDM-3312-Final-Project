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

    [BindProperty(SupportsGet = true)]
    public int PageNum {get; set;} = 1;
    public int PageSize {get; set;} = 5;
    public int TotalPages {get; set;}

    [BindProperty(SupportsGet = true)]
    public string CurrentSort {get; set;} = string.Empty;

    [BindProperty(SupportsGet = true)]
    public string CurrentSearch {get; set;} = string.Empty;

    public void OnGet()
    {
        //Search code
        var query = _context.Books
        .Include(b => b.BookReviews)
            .ThenInclude(br => br.Review)
        .AsQueryable();

        if (!string.IsNullOrEmpty(CurrentSearch))
        {
        query = query.Where(b => b.Title.Contains(CurrentSearch) || 
        b.Author.Contains(CurrentSearch));
        }

        //Sorting code
        query = CurrentSort switch
        {
        "title_asc"  => query.OrderBy(b => b.Title),
        "title_desc" => query.OrderByDescending(b => b.Title),
        "author_asc"  => query.OrderBy(b => b.Author),
        "author_desc" => query.OrderByDescending(b => b.Author),
        _ => query.OrderBy(b => b.Title) // Default sort
        };

        //Paging Support
        int totalRecords = query.Count();
        TotalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);

        if (PageNum < 1) PageNum = 1;

        Books = query
            .Skip((PageNum - 1) * PageSize)
            .Take(PageSize)
            .ToList();
    }
}
