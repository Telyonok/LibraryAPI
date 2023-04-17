using Library.BusinessLayer.Services.BookService;
using Library.DomainLayer.Models;

namespace Library.BusinessLayer.Interfaces
{
    public interface IBookService
    {
        Task AddBookAsync(BookRequest bookRequest);
        Task<List<Book>?> GetAllBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task<Book> GetBookAsync(string isbn);
        Task UpdateBookAsync(int id, BookRequest bookRequest);
        Task DeleteBookAsync(string isbn);
        Task DeleteBookAsync(int id);
    }
}
