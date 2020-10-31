using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class TouristicPointOutModel
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }

        public Region Region { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }
}
