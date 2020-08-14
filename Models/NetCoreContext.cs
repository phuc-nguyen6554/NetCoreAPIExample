using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public DbSet<Author> authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().HasOne(b => b.author).WithMany(author => author.Books);
        }
    }
}
