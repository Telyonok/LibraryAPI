using Library.Application.Interfaces;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ISBN).IsRequired().HasMaxLength(17);
            builder.Property(e => e.Author).HasMaxLength(20);
            builder.Property(e => e.Description).HasMaxLength(200);
            builder.Property(e => e.BorrowTime).HasDefaultValue(DateTime.Now);
            builder.Property(e => e.ReturnTime).HasDefaultValue(DateTime.Now.AddDays(14));
            builder.HasAlternateKey(e => e.ISBN);
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.PasswordHash).IsRequired();
        }
    }
}
