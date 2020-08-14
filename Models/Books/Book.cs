using ExampleAPI.Models.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Models.Books
{
    public class Book
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }

        public long AuthorID { get; set; }
        public Author author { get; set; }
    }
}
