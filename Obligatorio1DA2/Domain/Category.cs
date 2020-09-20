using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Category
    {
        public string Name { get; set; }

        public Category()
        {

        }
        public Category (string name)
        {
            Name = name;
        }
    }
}
