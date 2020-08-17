using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Models.Books
{
    public class BookDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public string AuthorName { get; set; }
    }
}
