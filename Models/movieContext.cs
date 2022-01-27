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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<movieTemplate>().HasData(

                    new movieTemplate
                    {
                        MovieID = 1,
                        Category = "Action",
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
                        Category = "Family",
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
                        Category = "Historical",
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
