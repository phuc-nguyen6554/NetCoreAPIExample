using ExampleAPI.Repository.Authors;
using ExampleAPI.Repository.Books;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI
{
    public static class ServiceExtension
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
