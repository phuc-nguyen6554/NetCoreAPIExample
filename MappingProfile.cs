using AutoMapper;
using ExampleAPI.Models.Authors;
using ExampleAPI.Models.Books;
using ExampleAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<CreateAuthorDTO, Author>();

            CreateMap<Book, BookDTO>().ForMember(b => b.AuthorName, opt => opt.MapFrom(b => b.author.Name));
            CreateMap<CreateBookDTO, Book>();

            CreateMap<RegistrationUserModel, ApplicationUser>();
            CreateMap<ApplicationUser, ReturnUserDTO>();
        }
    }
}
