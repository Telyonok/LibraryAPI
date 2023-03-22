﻿using AutoMapper;
using FluentValidation;
using Library.Domain.Abstractions;
using Library.Domain.Models;
using Library.Domain.Helpers;
using Library.Domain.Exceptions;

namespace Library.BLL.Services
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepository;
        private IMapper mapper;
        private IValidator<BookRequest> validator;
        public BookService(IBookRepository bookRepository, IMapper mapper, IValidator<BookRequest> validator)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task AddBookAsync(BookRequest bookRequest)
        {
            Task validationTask = validator.ValidateAndThrowAsync(bookRequest);
            if (await bookRepository.GetBookAsync(bookRequest.ISBN) != null)
                throw new EntityAlreadyExistsException(string.Format(Constants.BookWithIsbnExistsMessage, bookRequest.ISBN));
            var book = mapper.Map<Book>(bookRequest);
            await validationTask;
            await bookRepository.AddBookAsync(book);
        }

        public async Task DeleteBookAsync(BookRequest bookRequest)
        {
            Book? book = await bookRepository.GetBookAsync(bookRequest.ISBN);
            if (book == null || !AreEqual(book, bookRequest))
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
            Task validationTask = validator.ValidateAndThrowAsync(bookRequest);
            Book? book = await bookRepository.GetBookAsync(id);
            if (book == null)
                throw new EntityNotFoundException(string.Format(Constants.BookIdNotFoundMessage, id));
            Book? bookByIsbn = await bookRepository.GetBookAsync(bookRequest.ISBN);
            if (bookByIsbn != null && bookByIsbn.Id != id)
                throw new EntityAlreadyExistsException(string.Format(Constants.BookWithIsbnExistsMessage, bookRequest.ISBN));
            await validationTask;
            var newBook = mapper.Map<Book>(bookRequest);
            await bookRepository.UpdateBookAsync(id, newBook);
        }

        private bool AreEqual(Book book, BookRequest bookRequest)
        {
            return bookRequest.ISBN == book.ISBN &&
                bookRequest.Author == book.Author &&
                bookRequest.Title == book.Title &&
                bookRequest.Description == book.Description;
        }
    }
}