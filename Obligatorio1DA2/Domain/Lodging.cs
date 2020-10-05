using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Lodging
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TouristicPoint TouristicPoint{get; set;}
        public string Description { get; set; }
        public string Direction { get; set; }
        public string Phone { get; set; }
        public int Stars { get; set; }
        public double Price { get; set; }
        public string Images { get; set; }
        public bool IsDeleted { get; set; }
        public bool Capacity { get; set; }


        public Lodging()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Lodging))
            {
                return false;
            }
            return Name == ((Lodging)obj).Name 
                && Direction == ((Lodging)obj).Direction;
        }
    }
}
