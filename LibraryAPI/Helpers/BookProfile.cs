using AutoMapper;
using LibraryAPI.Models;

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
