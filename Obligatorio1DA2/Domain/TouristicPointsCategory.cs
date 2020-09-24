using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TouristicPointsCategory
    {
        public int TouristicPointId { get; set; }
        public TouristicPoint TouristicPoint { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
