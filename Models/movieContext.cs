using System;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Models
{
    public class movieContext : DbContext
    {
        public movieContext(DbContextOptions<movieContext> options) : base (options)
        {

        }

        public DbSet<movieTemplate> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
 
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                    new Category { CategoryId=1, CategoryName="Action/Adventure"},
                    new Category { CategoryId = 2, CategoryName = "Historical" },
                    new Category { CategoryId = 3, CategoryName = "Comedy" },
                    new Category { CategoryId = 4, CategoryName = "Drama" },
                    new Category { CategoryId = 5, CategoryName = "Family" },
                    new Category { CategoryId = 6, CategoryName = "Horror/Suspense" },
                    new Category { CategoryId = 7, CategoryName = "Television" },
                    new Category { CategoryId = 8, CategoryName = "VHS" },
                    new Category { CategoryId = 9, CategoryName = "Miscellaneous" }
                );

            mb.Entity<movieTemplate>().HasData(

                    new movieTemplate
                    {
                        MovieID = 1,
                        CategoryId = 1,
                        Title = "Inception",
                        Year = 2010,
                        Director = "Christopher Nolan",
                        Rating = "PG-13",
                        Edited = false,
                        Notes = "Mind-blowing"

                    },
                    new movieTemplate
                    {
                        MovieID = 2,
                        CategoryId = 5,
                        Title = "Coco",
                        Year = 2017,
                        Director = "Lee Unkrich",
                        Rating = "PG",
                        Edited = false,
                        LentTo = "Carol",
                        Notes = "Watch in spanish."
                    },
                    new movieTemplate
                    {
                        MovieID = 3,
                        CategoryId = 2,
                        Title = "Jojo Rabbit",
                        Year = 2019,
                        Director = "Taika Waititi",
                        Rating = "PG-13",
                        Edited = false
                    }
                );
        }
    }
}
