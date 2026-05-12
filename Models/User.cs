using System.ComponentModel.DataAnnotations;
namespace CIDM_3312_Final_Project;

public class User
{
    public int UserID {get; set;} //Primary Key

    [Required]
    public string Username {get; set;} = string.Empty;
    
    [EmailAddress]
    [Required]
    public string Email {get; set;} = string.Empty;

    public List<Book> Books {get; set;} = default!; //Nav Property to Book
}