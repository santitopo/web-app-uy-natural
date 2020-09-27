using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TouristicPointsCategory> TouristicPoints { get; set; }

        public Category()
        {

        }
        public Category (string name)
        {
            Name = name;
        }
    }
}
