using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private LibraryDbContext _db;

        public BookRepository(LibraryDbContext libraryDbContext)
        {
            this._db = libraryDbContext;    
        }

        public async Task AddBookAsync(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = _db.Books.Where(i => i.Id == id);
            _db.Remove(book);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return _db.Books.AsNoTracking().ToList();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return _db.Books.AsNoTracking().First(i => i.Id == id);
        }

        public async Task<Book> GetBookAsync(string isbn)
        {
            return _db.Books.AsNoTracking().First(i => i.ISBN == isbn);
        }

        public async Task UpdateBookAsync(int id, Book book)
        {
            var oldBook = _db.Books.First(i => i.Id == id);
            oldBook = book;
            await _db.SaveChangesAsync();
        }
    }
}
