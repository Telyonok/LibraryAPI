using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BookController : ControllerBase
    {
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("Books/")]
        public async Task<List<Book>> GetBooksAsync()
        {
            List<Book> books = await bookService.GetAllBooksAsync();
            return books;
        }

        [HttpGet("Book/{id:int}")]
        public async Task<Book> GetBookByIdAsync(int id)
        {
            Book book = await bookService.GetBookAsync(id);
            return book;
        }
        
        [HttpGet("Book/{isbn}")]
        public async Task<Book> GetBookByISBNAsync(string isbn)
        {
            Book book = await bookService.GetBookAsync(isbn);
            return book;
        }

        [HttpPost("AddBook/")]
        public async Task<IActionResult> AddBookAsync(Book book)
        {
            await bookService.AddBookAsync(book);
            return Ok();
        }

        [HttpPut("UpdateBook/{id:int}")]
        public async Task<IActionResult> UpdateBookAsync(int id, Book book)
        {
            await bookService.UpdateBookAsync(id, book);
            return Ok();
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBookByIdAsync(int id)
        {
            await bookService.DeleteBookAsync(id);
            return Ok("Deleted by Id");
        }

        [HttpDelete("DeleteBook/")]
        public async Task<IActionResult> DeleteBookAsync(Book book)
        {
            await bookService.DeleteBookAsync(book);
            return Ok();
        }
    }
}
