using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookstoreDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookstoreDbContext>();
            
            //Check if there are any pending migrations and migrate them
            if(context.Database.GetPendingMigrations().Any())
            {
                //Commented this out because it was throwing an error saying that the Books table already exists
                context.Database.Migrate();
            }

            //Check if there are not any books
            if(!context.Books.Any())
            {
                //Add books if there are not any yet
                context.Books.AddRange(
                    new Book
                    {
                        ISBN = "978-0451419439",
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95M,
                        Pages = 1488
                    },
                    new Book
                    {
                        ISBN = "978-0743270755",
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorMiddleName = "Kearns",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58M,
                        Pages = 944
                    },
                    new Book
                    {
                        ISBN = "978-0553384611",
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54M,
                        Pages = 832
                    },
                    new Book
                    {
                        ISBN = "978-0812981254",
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald",
                        AuthorMiddleName = "C.",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54M,
                        Pages = 864
                    },
                    new Book
                    {
                        ISBN = "978-0812974492",
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33M,
                        Pages = 528
                    },
                    new Book
                    {
                        ISBN = "978-0804171281",
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael ",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95M,
                        Pages = 288
                    },
                    new Book
                    {
                        ISBN = "978-1455586691",
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99M,
                        Pages = 304
                    },
                    new Book
                    {
                        ISBN = "978-1455523023",
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66M,
                        Pages = 240
                    },
                    new Book
                    {
                        ISBN = "978-1591847984",
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorLastName = "Branson",
                        Publisher = "Portfolio",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16M,
                        Pages = 400
                    },
                    new Book
                    {
                        ISBN = "978-0553393613",
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        Classification = "Non-Fiction",
                        Category = "Thrillers",
                        Price = 15.03M,
                        Pages = 642
                    },
                    new Book
                    {
                        ISBN = "978-1432859329",
                        Title = "Blackmoore",
                        AuthorFirstName = "Julianne",
                        AuthorLastName = "Donaldson",
                        Publisher = "Shadow Mountain",
                        Classification = "Fiction",
                        Category = "Romance",
                        Price = 9.51M,
                        Pages = 320
                    },
                    new Book
                    {
                        ISBN = "978-2382261101",
                        Title = "How to Win Friends and Influence People",
                        AuthorFirstName = "Dale",
                        AuthorLastName = "Carnegie",
                        Publisher = "Pocket Books",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 10.38M,
                        Pages = 288
                    },
                    new Book
                    {
                        ISBN = "978-2382261101",
                        Title = "Grit",
                        AuthorFirstName = "Angela",
                        AuthorLastName = "Duckworth",
                        Publisher = "Scribner Book Company",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 19.04M,
                        Pages = 352
                    }
                );

                //Save the changes
                context.SaveChanges();
            }
        }
    }
}
