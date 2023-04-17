using AutoMapper;
using Library.DomainLayer.Models;
using Library.BusinessLayer.Services.BookService;

namespace Library.BusinessLayer.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookRequest, Book>();
        }
    }
}