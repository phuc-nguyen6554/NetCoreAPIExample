using ExampleAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Repository.Authors
{
    public class AuthorRepository : RepositoryBase<Author> , IAuthorRepository
    {
        public AuthorRepository(NetCoreContext context) : base(context) {
        }

        public async override Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Set<Author>().Include(author => author.Books).ToListAsync();
        }

        public async Task<Author> Get(long id)
        {
            return await _context.Set<Author>().FindAsync(id);
        }
    }
}
