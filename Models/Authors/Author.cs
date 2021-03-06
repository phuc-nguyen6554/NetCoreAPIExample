﻿using ExampleAPI.Models.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Models.Authors
{
    public class Author
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public List<Book> Books { get; set; }
    }
}
