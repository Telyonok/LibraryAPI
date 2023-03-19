using Library.Domain.Models;

namespace Library.Domain.Abstractions
{
    public interface IBookService
    {
        Task AddBookAsync(BookRequest bookRequest);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task<Book> GetBookAsync(string isbn);
        Task UpdateBookAsync(int id, BookRequest bookRequest);
        Task DeleteBookAsync(BookRequest bookRequest);
        Task DeleteBookAsync(int id);
    }
}
