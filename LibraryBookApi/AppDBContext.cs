using LibraryBookApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection.Emit;

namespace LibraryBookApi
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Library> Libraries { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Book> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Library>()
                .HasMany(library => library.Books)
                .WithOne(book => book.Library)
                .HasForeignKey(book => book.LibraryId);
        }
        public void SeedData()
        {
            if (!Libraries.Any())
            {
                Libraries.AddRange(
                    new Library { Name = "Library A" },
                    new Library { Name = "Library B" },
                    new Library { Name = "Library C" }
                );

                SaveChanges();
            }

            if (!Books.Any())
            {
                Books.AddRange(
                    new Book { Title = "Book 1", LibraryId = 1 },
                    new Book { Title = "Book 2", LibraryId = 1 },
                    new Book { Title = "Book 3", LibraryId = 2 },
                    new Book { Title = "Book 4", LibraryId = 3 },
                    new Book { Title = "Book 5", LibraryId = 3 }
                );

                SaveChanges();
            }
        }
    }
}
