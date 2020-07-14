using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooklistRazor.Model
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Name = "When Harry Met Sally",
                        //ReleaseDate = DateTime.Parse("1989-2-12"),
                        Author = "Romantic Comedy",
                        ISBN = "Deafault"
                    },

                    new Book
                    {
                        Name = "Ghostbusters ",
                        //ReleaseDate = DateTime.Parse("1984-3-13"),
                        Author = "Comedy",
                        ISBN = "Deafault"
                    },

                    new Book
                    {
                        Name = "Ghostbusters 2",
                        //ReleaseDate = DateTime.Parse("1986-2-23"),
                        Author = "Comedy",
                        ISBN = "Deafault"
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
