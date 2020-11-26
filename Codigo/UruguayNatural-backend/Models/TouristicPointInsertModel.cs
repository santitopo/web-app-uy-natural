using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class TouristicPointInsertModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int RegionId { get; set; }
        public int[] Categories { get; set; }


        public TouristicPoint ToEntity() => new TouristicPoint()
        {
            Name = this.Name,
            Description = this.Description,
            Image = this.Image
        };
    }
}
