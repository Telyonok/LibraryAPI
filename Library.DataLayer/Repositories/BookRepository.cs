using Library.DataLayer.DatabaseData;
using Library.DomainLayer.Models;
using Library.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.DataLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBookAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _dbContext.Books.FirstAsync(i => i.Id == id);
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Book>?> GetAllBooksAsync()
        {
            return await _dbContext.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetBookAsync(int id)
        {
            return await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Book?> GetBookAsync(string isbn)
        {
            return await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(i => i.ISBN == isbn);
        }

        public async Task UpdateBookAsync(int id, Book book)
        {
            var oldBook = _dbContext.Books.First(i => i.Id == id);
            oldBook.Genre = book.Genre;
            oldBook.Title = book.Title;
            oldBook.Description = book.Description;
            oldBook.Author = book.Author;
            oldBook.ISBN = book.ISBN;
            oldBook.BorrowTime = book.BorrowTime;
            oldBook.ReturnTime = book.ReturnTime;
            await _dbContext.SaveChangesAsync();
        }
    }
}
