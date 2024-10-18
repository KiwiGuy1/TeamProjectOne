//JF I think this is good

using Microsoft.EntityFrameworkCore;
using System;
using TeamProject.Controllers;

namespace TeamProject.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friends" },
                new Category { CategoryId = 3, Name = "Work" },
                new Category { CategoryId = 4, Name = "Other" }
            );

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    FirstName = "Delores",
                    LastName = "Del Rio",
                    Phone = "555-987-6543",
                    Email = "delores@hotmail.com",
                    Organization = null,
                    CategoryId = 2,
                    DateAdded = DateTime.Now
                },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "Efren",
                    LastName = "Herrera",
                    Phone = "555-456-7890",
                    Email = "efren@aol.com",
                    Organization = null, 
                    CategoryId = 3,
                    DateAdded = DateTime.Now
                },
                new Contact
                {
                    ContactId = 3,
                    FirstName = "Mary Ellen",
                    LastName = "Walton",
                    Phone = "555-123-4567",
                    Email = "MaryEllen@yahoo.com",
                    Organization = null,
                    CategoryId = 1,
                    DateAdded = DateTime.Now
                }
            );
        }
    }
}