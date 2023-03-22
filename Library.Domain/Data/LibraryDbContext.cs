using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Domain.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
            Console.WriteLine("We are in!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(e => e.Id);
            modelBuilder.Entity<Book>().Property(e => e.Title).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(e => e.ISBN).IsRequired().HasMaxLength(17);
            modelBuilder.Entity<Book>().Property(e => e.Author).HasMaxLength(20);
            modelBuilder.Entity<Book>().Property(e => e.Description).HasMaxLength(200);
            modelBuilder.Entity<Book>().Property(e => e.BorrowTime).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Book>().Property(e => e.ReturnTime).HasDefaultValue(DateTime.Now.AddDays(14));
            modelBuilder.Entity<Book>().HasAlternateKey(e => e.ISBN);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
