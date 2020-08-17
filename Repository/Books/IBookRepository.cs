using ExampleAPI.Contracts;
using ExampleAPI.Models;
using ExampleAPI.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Repository.Books
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        public Task<Book> Get(long id);
    }
}
