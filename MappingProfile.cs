using AutoMapper;
using ExampleAPI.Models.Authors;
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
        }
    }
}
