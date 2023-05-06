using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Interfaces
{
    public interface ILibraryDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
