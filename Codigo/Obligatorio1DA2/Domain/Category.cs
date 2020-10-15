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

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Category))
            {
                return false;
            }
            return Name == ((Category)obj).Name;
        }
    }
}
