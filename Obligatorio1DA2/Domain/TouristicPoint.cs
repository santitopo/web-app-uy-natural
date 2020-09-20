using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TouristicPoint
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Region Region { get; set; }
        public List<Category> Categories { get; set; }
        public string Image { get; set; }

        public TouristicPoint()
        {

        }
    }
}
