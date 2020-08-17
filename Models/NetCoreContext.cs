using ExampleAPI.Configurations;
using ExampleAPI.Models.Authors;
using ExampleAPI.Models.Books;
using ExampleAPI.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Models
{
    public class NetCoreContext : IdentityDbContext<ApplicationUser>
    {
        public NetCoreContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>().HasOne(b => b.author).WithMany(author => author.Books);

            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
