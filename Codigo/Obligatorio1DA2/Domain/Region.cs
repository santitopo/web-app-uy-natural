using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Region()
        {

        }

        public Region(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Region))
            {
                return false;
            }
            return Name == ((Region)obj).Name;
        }

    }
}
