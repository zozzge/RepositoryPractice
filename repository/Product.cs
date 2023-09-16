using System;
using System.Collections.Generic;
using System.Text;

namespace repository
{
    public class Product: EntityBase
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
