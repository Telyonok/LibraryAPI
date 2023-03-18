using LibraryAPI.Filters;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    [BookExceptionHandlerFilter]
    public class BookController : ControllerBase
    {
        private IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("Books/")]
        public async Task<ActionResult<List<Book>>> GetBooksAsync()
        {
            List<Book> books = await bookService.GetAllBooksAsync();
            if (books.Count == 0)
                return NoContent();
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
        public async Task<IActionResult> AddBookAsync(BookRequest bookRequest)
        {
            await bookService.AddBookAsync(bookRequest);
            return Ok("Successfully added a book");
        }

        [HttpPut("UpdateBook/{id:int}")]
        public async Task<IActionResult> UpdateBookAsync(int id, BookRequest bookRequest)
        {
            await bookService.UpdateBookAsync(id, bookRequest);
            return Ok("Successfully updated by Id");
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBookByIdAsync(int id)
        {
            await bookService.DeleteBookAsync(id);
            return Ok("Successfully deleted by Id");
        }

        [HttpDelete("DeleteBook/")]
        public async Task<IActionResult> DeleteBookAsync(BookRequest bookRequest)
        {
            await bookService.DeleteBookAsync(bookRequest);
            return Ok("Successfully deleted by BookRequest");
        }
    }
}
