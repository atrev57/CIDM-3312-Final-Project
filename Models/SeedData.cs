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
            new Book {
                Title = "Ulysses",
                Author = "James Joyce",
                Status = Book.StatusOptions.Start,
                ImageURL = "img/Ulysses.jpg",
                User = users[0]
            },

            new Book {
                Title = "In Search of Lost Time",
                Author = "Marcel Proust",
                Status = Book.StatusOptions.Inprogress,
                ImageURL = "/img/ISOLT.jpg",
                User = users[1]
            },

            new Book {
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Status = Book.StatusOptions.Done,
                ImageURL = "img/Gatsby.jpg",
                User = users[2]
            },

            new Book {
                Title = "The Catcher in the Rye",
                Author = "J. D. Salinger",
                Status = Book.StatusOptions.Inprogress,
                ImageURL = "img/Catcher.jpg",
                User = users[3]
            },

            new Book {
                Title = "Moby Dick",
                Author = "Herman Melville",
                Status = Book.StatusOptions.Start,
                ImageURL = "img/MobyDick.jpg",
                User = users[4]
            },
            new Book {
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                Status = Book.StatusOptions.Done,
                ImageURL = "img/placeholder.png",
                User = users[0]
            },

            new Book {
                Title = "1984",
                Author = "George Orwell",
                Status = Book.StatusOptions.Done,
                ImageURL = "img/placeholder.png",
                User = users[1]
            },

            new Book {
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Status = Book.StatusOptions.Start,
                ImageURL = "img/placeholder.png",
                User = users[2]
            },

            new Book {
                Title = "War and Peace",
                Author = "Leo Tolstoy",
                Status = Book.StatusOptions.Inprogress,
                ImageURL = "img/placeholder.png",
                User = users[3]
            },

            new Book {
                Title = "Crime and Punishment",
                Author = "Fyodor Dostoevsky",
                Status = Book.StatusOptions.Done,
                ImageURL = "img/placeholder.png",
                User = users[4]
            },

            new Book {
                Title = "The Hobbit",
                Author = "J. R. R. Tolkien",
                Status = Book.StatusOptions.Start,
                ImageURL = "img/placeholder.png",
                User = users[0]
            },

            new Book {
                Title = "Brave New World",
                Author = "Aldous Huxley",
                Status = Book.StatusOptions.Inprogress,
                ImageURL = "img/placeholder.png",
                User = users[1]
            },

            new Book {
                Title = "Jane Eyre",
                Author = "Charlotte Bronte",
                Status = Book.StatusOptions.Done,
                ImageURL = "img/placeholder.png",
                User = users[2]
            },

            new Book {
                Title = "The Odyssey",
                Author = "Homer",
                Status = Book.StatusOptions.Start,
                ImageURL = "img/placeholder.png",
                User = users[3]
            },

            new Book {
                Title = "Frankenstein",
                Author = "Mary Shelley",
                Status = Book.StatusOptions.Inprogress,
                ImageURL = "img/placeholder.png",
                User = users[4]
            },

            new Book {
                Title = "The Brothers Karamazov",
                Author = "Fyodor Dostoevsky",
                Status = Book.StatusOptions.Done,
                ImageURL = "img/placeholder.png",
                User = users[0]
            },

            new Book {
                Title = "Anna Karenina",
                Author = "Leo Tolstoy",
                Status = Book.StatusOptions.Start,
                ImageURL = "img/placeholder.png",
                User = users[1]
            },

            new Book {
                Title = "Don Quixote",
                Author = "Miguel de Cervantes",
                Status = Book.StatusOptions.Inprogress,
                ImageURL = "img/placeholder.png",
                User = users[2]
            },

            new Book {
                Title = "Wuthering Heights",
                Author = "Emily Bronte",
                Status = Book.StatusOptions.Done,
                ImageURL = "img/placeholder.png",
                User = users[3]
            },

            new Book {
                Title = "Dracula",
                Author = "Bram Stoker",
                Status = Book.StatusOptions.Start,
                ImageURL = "img/placeholder.png",
                User = users[4]
            },

            new Book {
                Title = "The Divine Comedy",
                Author = "Dante Alighieri",
                Status = Book.StatusOptions.Inprogress,
                ImageURL = "img/placeholder.png",
                User = users[0]
            },

            new Book {
                Title = "Les Miserables",
                Author = "Victor Hugo",
                Status = Book.StatusOptions.Done,
                ImageURL = "img/placeholder.png",
                User = users[1]
            },

            new Book {
                Title = "The Iliad",
                Author = "Homer",
                Status = Book.StatusOptions.Start,
                ImageURL = "img/placeholder.png",
                User = users[2]
            },

            new Book {
                Title = "Fahrenheit 451",
                Author = "Ray Bradbury",
                Status = Book.StatusOptions.Inprogress,
                ImageURL = "img/placeholder.png",
                User = users[3]
            },

            new Book {
                Title = "The Picture of Dorian Gray",
                Author = "Oscar Wilde",
                Status = Book.StatusOptions.Done,
                ImageURL = "img/placeholder.png",
                User = users[4]
            }
        };
        context.AddRange(books);
        context.SaveChanges();

        List<Review> reviews = new List<Review>
        {
            new Review {Score = 1, ReviewText = "Very boring, not a fun read."},
            new Review {Score = 2, ReviewText = "A bit better, story is still slow and boring."},
            new Review {Score = 3, ReviewText = "Not bad at all, but would not read again."},
            new Review {Score = 4, ReviewText = "Very fun! I enjoyed the story and the pace was good."},
            new Review {Score = 5, ReviewText = "Incredible book! Would absolutely recommend to all my friends!"},

            new Review {Score = 5, ReviewText = "Amazing character development."},
            new Review {Score = 4, ReviewText = "Very entertaining from start to finish."},
            new Review {Score = 3, ReviewText = "Good story but dragged in the middle."},
            new Review {Score = 2, ReviewText = "Hard to stay interested."},
            new Review {Score = 1, ReviewText = "Did not enjoy this book at all."},

            new Review {Score = 5, ReviewText = "One of my favorite books ever."},
            new Review {Score = 4, ReviewText = "Well written and enjoyable."},
            new Review {Score = 3, ReviewText = "Average overall experience."},
            new Review {Score = 2, ReviewText = "The pacing felt very slow."},
            new Review {Score = 1, ReviewText = "Confusing and difficult to follow."},

            new Review {Score = 5, ReviewText = "Beautiful writing style."},
            new Review {Score = 4, ReviewText = "Great themes and storytelling."},
            new Review {Score = 3, ReviewText = "Some parts were enjoyable."},
            new Review {Score = 2, ReviewText = "Not my preferred genre."},
            new Review {Score = 1, ReviewText = "Would not recommend this book."},

            new Review {Score = 5, ReviewText = "A masterpiece of literature."},
            new Review {Score = 4, ReviewText = "Solid book with memorable moments."},
            new Review {Score = 3, ReviewText = "It was okay overall."},
            new Review {Score = 2, ReviewText = "Expected much more from it."},
            new Review {Score = 5, ReviewText = "Could not put this book down."}
        };
        context.AddRange(reviews);
        context.SaveChanges();

        List<BookReview> bookReviews = new List<BookReview>
        {
            //User 1
            new BookReview {BookID = 1, ReviewID = 1},
            new BookReview {BookID = 3, ReviewID = 2},
            new BookReview {BookID = 5, ReviewID = 3},

            //User 2
            new BookReview {BookID = 2, ReviewID = 4},
            new BookReview {BookID = 4, ReviewID = 5},
            new BookReview {BookID = 1, ReviewID = 6},

            //User 3
            new BookReview {BookID = 3, ReviewID = 7},
            new BookReview {BookID = 5, ReviewID = 8},
            new BookReview {BookID = 2, ReviewID = 9},

            //User 4
            new BookReview {BookID = 4, ReviewID = 10},
            new BookReview {BookID = 1, ReviewID = 11},
            new BookReview {BookID = 3, ReviewID = 12},

            //User 5
            new BookReview {BookID = 5, ReviewID = 13},
            new BookReview {BookID = 2, ReviewID = 14},
            new BookReview {BookID = 4, ReviewID = 15}
        };
        context.AddRange(bookReviews);
        context.SaveChanges();
    } 
}