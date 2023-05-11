using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Library.Domain.Models;
using MediatR;
using AutoMapper;
using Library.Application.Books.Queries.GetBooks;
using Library.Web.Models;
using Library.Application.Books.Queries.GetBookById;
using Library.Application.Books.Queries.GetBookByISBN;
using Library.Application.Books.Commands.AddBook;
using Library.Application.Books.Commands.UpdateBook;
using Library.Application.Books.Commands.DeleteBookById;
using Library.Application.Books.Commands.DeleteBookByISBN;

namespace Library.Web.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BookController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public BookController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _mediator = sender;
        }

        [HttpGet("Books/")]
        public async Task<ActionResult> GetBooksAsync()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            var booksResponse = _mapper.Map<List<BookResponse>>(books);
            return Ok(booksResponse);
        }

        [HttpGet("Book/{id:int}", Name = "GetBookById")]
        public async Task<ActionResult> GetBookByIdAsync(int id)
        {
            Book book = await _mediator.Send(new GetBookByIdQuery(id));
            var bookResponse = _mapper.Map<BookResponse>(book);
            return Ok(bookResponse);
        }

        [HttpGet("Book/{isbn}")]
        public async Task<ActionResult> GetBookByISBNAsync(string isbn)
        {
            Book book = await _mediator.Send(new GetBookByISBNQuery(isbn));
            var bookResponse = _mapper.Map<BookResponse>(book);
            return Ok(bookResponse);
        }

        [HttpPost("AddBook/")]
        [Authorize]
        public async Task<IActionResult> AddBookAsync(AddBookCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("UpdateBook/")]
        [Authorize]
        public async Task<IActionResult> UpdateBookAsync(UpdateBookCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("DeleteBookById/")]
        [Authorize]
        public async Task<IActionResult> DeleteBookByIdAsync(DeleteBookByIdCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("DeleteBookByISBN/")]
        [Authorize]
        public async Task<IActionResult> DeleteBookByISBNAsync(DeleteBookByISBNCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
