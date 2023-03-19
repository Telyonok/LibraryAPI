using AutoMapper;
using Library.Domain.Models;

namespace LibraryAPI.Helpers
{
    public class BookProfile : Profile
    {
        public BookProfile() 
        {
            CreateMap<BookRequest, Book>();
        }
    }
}
