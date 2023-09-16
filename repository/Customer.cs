using System;
using System.Collections.Generic;
using System.Text;

namespace repository
{
    public class Customer : EntityBase
    {

        public string IdNo { get; set; }
        public string FullName { get; set; }
        public string EMail { get; set; }
    }
}
