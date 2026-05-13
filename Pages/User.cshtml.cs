using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIDM_3312_Final_Project.Models;

namespace CIDM_3312_Final_Project.Pages_Users;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<User> Users { get; set; } = new();

    [BindProperty]
    public User AppUser { get; set; } = new();

    
    public void OnGet()
    {
        Users = _context.Users.ToList();
    }
    //Create User
    public IActionResult OnPostCreate()
    {
        
        ModelState.Remove("AppUser.UserID");
        ModelState.Remove("AppUser.Books"); 

        if (!ModelState.IsValid)
        {
            Users = _context.Users.ToList();
            return Page();
        }

        _context.Users.Add(AppUser);
        _context.SaveChanges();

        return RedirectToPage();
    }

    //Load edits
    public IActionResult OnGetEdit(int id)
    {
        Users = _context.Users.ToList();

        var user = _context.Users.FirstOrDefault(u => u.UserID == id);

        if (user == null)
        {
            return RedirectToPage();
        }

        AppUser = user;

        return Page();
    }

    //save edits
    public IActionResult OnPostEdit()
    {
        
        ModelState.Remove("AppUser.Books"); 

        if (!ModelState.IsValid)
        {
            Users = _context.Users.ToList();
            return Page();
        }

        _context.Attach(AppUser).State = EntityState.Modified;
        _context.SaveChanges();

        return RedirectToPage();
    }

    //delete users
    public IActionResult OnPostDelete(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.UserID == id);

        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        return RedirectToPage();
    }
}