
using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {

        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().HasMany(b => b.Authors).WithMany(a => a.Books);

            modelBuilder.Entity<Book>().HasMany<Author>(b => b.Authors).WithMany(a => a.Books)
                .UsingEntity(x => x.ToTable("BookAuthor"));
            modelBuilder.Entity<Book>().HasKey(b => b.BookID);
            modelBuilder.Entity<Book>().Property(b => b.Name).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Year).IsRequired();

            modelBuilder.Entity<Author>().HasKey(a => a.AuthorID);
            modelBuilder.Entity<Author>().Property(a => a.Name).IsRequired();

            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        }

    }
}
