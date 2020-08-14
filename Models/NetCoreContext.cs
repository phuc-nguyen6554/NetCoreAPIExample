using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Models
{
    public class NetCoreContext : DbContext
    {
        public NetCoreContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> books { get; set; }
    }
}
