using ExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Repository.Books
{
    public class BookRepository : RepositoryBase<Book>,IBookRepository
    {
        public BookRepository(NetCoreContext context) : base(context) { }
    }
}
