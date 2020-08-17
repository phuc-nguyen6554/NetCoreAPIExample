using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Models.Books
{
    public class CreateBookDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public float ?Price { get; set; }
        public long AuthorID { get; set; }
    }
}
