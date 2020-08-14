using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Models.Authors
{
    public class AuthorDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
