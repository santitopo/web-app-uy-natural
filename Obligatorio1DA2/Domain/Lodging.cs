using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Lodging
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
        public string Phone { get; set; }
        public int Stars { get; set; }
        public double Price { get; set; }
        public string Images { get; set; }

        public Lodging()
        {

        }
    }
}
