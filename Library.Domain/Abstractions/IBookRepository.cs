﻿using Library.Domain.Models;

namespace Library.Domain.Abstractions
{
    public interface IBookRepository
    {
        Task AddBookAsync(Book book);
        Task<List<Book>?> GetAllBooksAsync();
        Task<Book?> GetBookAsync(int id);
        Task<Book?> GetBookAsync(string isbn);
        Task UpdateBookAsync(int id, Book book);
        Task DeleteBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}