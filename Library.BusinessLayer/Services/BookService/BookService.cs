using AutoMapper;
using FluentValidation;
using Library.BusinessLayer.Interfaces;
using Library.DataLayer.Interfaces;
using Library.DomainLayer.Exceptions;
using Library.DomainLayer.Helpers;
using Library.DomainLayer.Models;

namespace Library.BusinessLayer.Services.BookService
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepository;
        private IMapper mapper;
        private IValidator<Book> validator;
        public BookService(IBookRepository bookRepository, IMapper mapper, IValidator<Book> validator)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task AddBookAsync(BookRequest bookRequest)
        {
            if (await bookRepository.GetBookAsync(bookRequest.ISBN) != null)
                throw new EntityAlreadyExistsException(string.Format(Constants.BookWithIsbnExistsMessage, bookRequest.ISBN));
            var book = mapper.Map<Book>(bookRequest);
            await validator.ValidateAndThrowAsync(book);
            await bookRepository.AddBookAsync(book);
        }

        public async Task DeleteBookAsync(string isbn)
        {
            Book? book = await bookRepository.GetBookAsync(isbn);
            if (book == null)
                throw new EntityNotFoundException(Constants.BookNotFoundMessage);
            await bookRepository.DeleteBookAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            Book? book = await bookRepository.GetBookAsync(id);
            if (book == null)
                throw new EntityNotFoundException(string.Format(Constants.BookIdNotFoundMessage, id));
            await bookRepository.DeleteBookAsync(id);
        }

        public async Task<List<Book>?> GetAllBooksAsync()
        {
            return await bookRepository.GetAllBooksAsync();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            var book = await bookRepository.GetBookAsync(id);
            if (book == null)
                throw new EntityNotFoundException(string.Format(Constants.BookIdNotFoundMessage, id));
            return book;
        }

        public async Task<Book> GetBookAsync(string isbn)
        {
            var book = await bookRepository.GetBookAsync(isbn);
            if (book == null)
                throw new EntityNotFoundException(string.Format(Constants.BookIsbnNotFoundMessage, isbn));
            return book;
        }

        public async Task UpdateBookAsync(int id, BookRequest bookRequest)
        {
            Book? book = await bookRepository.GetBookAsync(id);
            if (book == null)
                throw new EntityNotFoundException(string.Format(Constants.BookIdNotFoundMessage, id));
            Book? bookByIsbn = await bookRepository.GetBookAsync(bookRequest.ISBN);
            if (bookByIsbn != null && bookByIsbn.Id != id)
                throw new EntityAlreadyExistsException(string.Format(Constants.BookWithIsbnExistsMessage, bookRequest.ISBN));
            var newBook = mapper.Map<Book>(bookRequest);
            await validator.ValidateAndThrowAsync(newBook);
            await bookRepository.UpdateBookAsync(id, newBook);
        }
    }
}
