//JF I think this is good

using Microsoft.EntityFrameworkCore;
using TeamProject.Controllers;

namespace TeamProject.Models
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> options)
            : base(options)
        { }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friends" },
                new Category { CategoryId = 3, Name = "Work" },
                new Category { CategoryId = 4, Name = "Other" }
            );

            modelBuilder.Entity<Manager>().HasData(
                new Manager
                {
                    ManagerId = 1,
                    FirstName = "Delores",
                    LastName = "Del Rio",
                    Phone = "555-987-6543",
                    Email = "delores@hotmail.com",
                    Organization = null,
                    CategoryId = 2
                },
                new Manager
                {
                    ManagerId = 2,
                    FirstName = "Efren",
                    LastName = "Herrera",
                    Phone = "555-456-7890",
                    Email = "efren@aol.com",
                    Organization = null, 
                    CategoryId = 3
                },
                new Manager
                {
                    ManagerId = 2,
                    FirstName = "Mary Ellen",
                    LastName = "Walton",
                    Phone = "555-123-4567",
                    Email = "MaryEllen@yahoo.com",
                    Organization = null,
                    CategoryId = 1
                }
            );
        }
    }
}