using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        Task AddBookAsync(Book book);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task<Book> GetBookAsync(string isbn);
        Task<Book> UpdateBookAsync(int id, Book book);
    }
}
