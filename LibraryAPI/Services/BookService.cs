using LibraryAPI.Models;
using LibraryAPI.Repositories;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task AddBookAsync(Book book)
        {
            await bookRepository.AddBookAsync(book);
        }

        public async Task DeleteBookAsync(Book book)
        {
            await bookRepository.DeleteBookAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await bookRepository.DeleteBookAsync(id);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await bookRepository.GetAllBooksAsync();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await bookRepository.GetBookAsync(id);
        }

        public async Task<Book> GetBookAsync(string isbn)
        {
            return await bookRepository.GetBookAsync(isbn);
        }

        public async Task UpdateBookAsync(int id, Book book)
        {
            await bookRepository.UpdateBookAsync(id, book);
        }
    }
}
