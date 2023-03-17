using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BookController : ControllerBase
    {
        [HttpGet("Books/")]
        public Book GetBooks()
        {
            return new Book() { Title = "h" };
        }

        [HttpGet("Book/{id:int}")]
        public Book GetBookById(int id)
        {
            return new Book() { Title = id.ToString() };
        }
        
        [HttpGet("Book/{isbn}")]
        public Book GetBookByISBN(string isbn)
        {
            return new Book() { Title = "isbn" };
        }

        [HttpPost("AddBook/")]
        public IActionResult AddBook(Book book)
        {
            return Ok(book);
        }

        [HttpPut("UpdateBook/{id:int}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            return Ok(book);
        }

        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            return Ok("Deleted by Id");
        }

        [HttpDelete("DeleteBook/")]
        public IActionResult DeleteBook(Book book)
        {
            return Ok(book);
        }
    }
}
