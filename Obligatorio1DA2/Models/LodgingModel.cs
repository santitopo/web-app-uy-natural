using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class LodgingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TPointId { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
        public string Phone { get; set; }
        public int Stars { get; set; }
        public double Price { get; set; }
        public string Images { get; set; }
        public bool IsFull { get; set; }

        public Lodging ToEntity() => new Lodging()
        {
            Name = this.Name,
            Description = this.Description,
            Direction = this.Direction,
            Phone = this.Phone,
            Stars = this.Stars,
            Price = this.Price,
            Images = this.Images,
            IsDeleted = false,
            Capacity = false
        };

    }
}
