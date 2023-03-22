using Library.Domain.Abstractions;
using Library.Domain.Data;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        IServiceScopeFactory scopeFactory;

        public BookRepository(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public async Task AddBookAsync(Book book)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                await _db.Books.AddAsync(book);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(Book book)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                _db.Books.Remove(book);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                var book = await _db.Books.FirstAsync(i => i.Id == id);
                _db.Books.Remove(book);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Book>?> GetAllBooksAsync()
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                return await _db.Books.AsNoTracking().ToListAsync();
            }
        }

        public async Task<Book?> GetBookAsync(int id)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                return await _db.Books.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
        }

        public async Task<Book?> GetBookAsync(string isbn)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                return await _db.Books.AsNoTracking().FirstOrDefaultAsync(i => i.ISBN == isbn);
            }
        }

        public async Task UpdateBookAsync(int id, Book book)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
                var oldBook = _db.Books.First(i => i.Id == id);
                oldBook.Genre = book.Genre;
                oldBook.Title = book.Title;
                oldBook.Description = book.Description;
                oldBook.Author = book.Author;
                oldBook.ISBN = book.ISBN;
                oldBook.BorrowTime = book.BorrowTime;
                oldBook.ReturnTime = book.ReturnTime;
                await _db.SaveChangesAsync();
            }
        }
    }
}
