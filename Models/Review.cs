using System.ComponentModel.DataAnnotations;
namespace CIDM_3312_Final_Project;

public class Review
{
    public int ReviewID {get; set;} //Primary Key

    [Range(1,5)]
    public decimal Score {get; set;}

    [Display(Name = "Review")]
    public string ReviewText {get; set;} = string.Empty;
    
    public List<BookReview> BookReviews {get; set;} = default!; //Nav property to BookReview
}
