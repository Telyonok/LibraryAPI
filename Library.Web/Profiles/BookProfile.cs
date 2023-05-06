using AutoMapper;
using Library.Domain.Models;
using Library.Web.Models;

namespace Library.Web.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookResponse>();
        }
    }
}