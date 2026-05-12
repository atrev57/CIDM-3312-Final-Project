using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookReview>().HasKey(br => new { br.BookID, br.ReviewID });
    }

    public DbSet<Book> Books {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<Review> Reviews {get; set;}
    public DbSet<BookReview> BookReviews {get; set;}
}