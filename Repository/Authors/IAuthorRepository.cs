using ExampleAPI.Contracts;
using ExampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Repository.Authors
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        public Task<Author> Get(long id);
    }
}
