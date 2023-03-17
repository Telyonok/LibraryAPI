using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class LibraryDbContext : DbContext
    {

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(e => e.Id);
            modelBuilder.Entity<Book>().Property(e => e.Title).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(e => e.ISBN).IsRequired().HasMaxLength(17);
            modelBuilder.Entity<Book>().Property(e => e.Author).HasMaxLength(20);
            modelBuilder.Entity<Book>().Property(e => e.Description).HasMaxLength(200);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
    }
}
