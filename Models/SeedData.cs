using CIDM_3312_Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.Books.Any())
        {
            return;
        }

        //Adding Books, Users, and Reviews
        List<User> users = new List<User>
        {
            new User {Username = "lmyrkus0" , Email = "fdarcy0@usatoday.com"},
            new User {Username = "clyst1" , Email = "aogarmen1@webeden.co.uk"},
            new User {Username = "kjeannet2" , Email = "kbewshaw2@surveymonkey.com"},
            new User {Username = "kbondesen3" , Email = "mveronique3@mozilla.org"},
            new User {Username = "ceakle4" , Email = "lkennaird4@ucsd.edu"},
        };
        context.AddRange(users);
        context.SaveChanges();

        List<Book> books = new List<Book>
        {
            new Book {Title = "Ulysses", Author = "James Joyce", Status = Book.StatusOptions.Start },
            new Book {Title = "In Search of Lost Time", Author = " Marcel Proust", Status = Book.StatusOptions.Inprogress},
            new Book {Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Status = Book.StatusOptions.Done},
            new Book {Title = "The Catcher in the Rye", Author = "J. D. Salinger", Status = Book.StatusOptions.Inprogress},
            new Book {Title = "Moby-Dick", Author = " Herman Melville", Status = Book.StatusOptions.Start}
        };
        context.AddRange(books);
        context.SaveChanges();

        List<Review> reviews = new List<Review>
        {
            new Review {Score = 1, ReviewText = "Very boring, not a fun read."},
            new Review {Score = 2, ReviewText = "A bit better, story is still slow and boring."},
            new Review {Score = 3, ReviewText = "Not bad at all, but would not read again."},
            new Review {Score = 4, ReviewText = "Very fun! I enjoyed the story and the pace was good."},
            new Review {Score = 5, ReviewText = "Incredible book! Would absolutly recommend to all my friends!"}
        };
        context.AddRange(reviews);
        context.SaveChanges();

        List<BookReview> bookReviews = new List<BookReview>
        {
            //User 1
            //Note: Add at least one more for each user with dif BookID and Rev ID
            new BookReview {BookID = 1, ReviewID = 1},
            //User 2
            new BookReview {BookID = 2, ReviewID = 2},
            //User 3
            new BookReview {BookID = 3, ReviewID = 3},
            //User 4
            new BookReview {BookID = 4, ReviewID = 4},
            //User 5
            new BookReview {BookID = 5, ReviewID = 5}
        };
        context.AddRange(bookReviews);
        context.SaveChanges();
    } 
}