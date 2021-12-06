using AutoMapper;
using Entities.Models;
using Entities.ViewModels;

namespace book
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, GetAuthorsDto>();
            CreateMap<Author, ShowBooksAuthorDto>();
            CreateMap<Book, GetBookDto>();
            CreateMap<Book, ShowBookDto>();
            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<BookForCreationDto, Book>();
        }
    }
}
