using ExampleAPI.Models;
using ExampleAPI.Models.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Repository.Books
{
    public class BookRepository : RepositoryBase<Book>,IBookRepository
    {
        public BookRepository(NetCoreContext context) : base(context) { }

        public async override Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Set<Book>().Include(b => b.author).ToListAsync();
        }

        public async Task<Book> Get(long id)
        {
            return await _context.Set<Book>().FindAsync(id);
        }
    }
}
