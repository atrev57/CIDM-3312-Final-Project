using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CIDM_3312_Final_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace CIDM_3312_Final_Project.Pages_Books;

public class AddReviewModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<AddReviewModel> _logger;

    public AddReviewModel(AppDbContext context, ILogger<AddReviewModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    [BindProperty]
    public Review Review { get; set; } = default!;

    [BindProperty]
    public int SelectedBookID { get; set; }

    public SelectList BooksDropDown { get; set; } = default!;

    public void OnGet()
    {
        BooksDropDown = new SelectList(
            _context.Books.ToList(),
            "BookID",
            "Title"
        );
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            BooksDropDown = new SelectList(
                _context.Books.ToList(),
                "BookID",
                "Title"
            );

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                _logger.LogError($"Error: {error.ErrorMessage}");
            }

            return Page();
        }

        //Saves the review first
        _context.Reviews.Add(Review);
        _context.SaveChanges();

        //Links review to book (join table)
        var bookReview = new BookReview
        {
            BookID = SelectedBookID,
            ReviewID = Review.ReviewID
        };

        _context.BookReviews.Add(bookReview);
        _context.SaveChanges();

        return RedirectToPage("/Index");
    }
}