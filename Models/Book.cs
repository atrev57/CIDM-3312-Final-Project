using System.ComponentModel.DataAnnotations;
namespace CIDM_3312_Final_Project;

public class Book
{
    public int BookID {get; set;} //Primary Key

    [StringLength(60, MinimumLength = 5)]
    public string Title {get; set;} = string.Empty;

    [StringLength(60, MinimumLength = 5)]
    public string Author {get; set;} = string.Empty;

    public enum StatusOptions
    {
        [Display(Name = "Started")]
        Start,
        [Display(Name = "In Progress")]
        Inprogress,
        [Display(Name = "Finished")]
        Done
    }
    [Display(Name = "Reading Status")]
    public StatusOptions Status {get; set;} //Dropdown box.

    [Display(Name = "Book Cover")]
    public string ImageURL {get; set;} = string.Empty;

    public int UserID {get; set;} //Foreign Key
    public User User {get; set;} = default!; //Nav Property to User

    public List<BookReview> BookReviews {get; set;} = default!; //Nav property to BookReview
}

public class BookReview
{
    public int BookID {get; set;} //Primary Key, Foreign key 1
    public int ReviewID {get; set;} //PK, FK2

    public Book Book {get; set;} = default!; //Nav property to Book
    public Review Review {get; set;} = default!; //Nav property to Review
}