using System;
using Microsoft.EntityFrameworkCore;

namespace MyBooks.Model
{
    public class BooksAppContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookTag> BookTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                    .HasKey(bc => new { bc.BookId, bc.AuthorId });
            modelBuilder.Entity<BookAuthor>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(bc => bc.Author)
                .WithMany(c => c.BookAuthors)
                .HasForeignKey(bc => bc.AuthorId);

            modelBuilder.Entity<BookTag>()
                    .HasKey(bc => new { bc.BookId, bc.TagId });
            modelBuilder.Entity<BookTag>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookTags)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookTag>()
                .HasOne(bc => bc.Tag)
                .WithMany(c => c.BookTags)
                .HasForeignKey(bc => bc.TagId);

        }
    }
}
