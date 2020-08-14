using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Models
{
    public class Book
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }
    }
}
