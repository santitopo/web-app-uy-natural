using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class BillModel
    {
        public Guid ReservationCode { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public double PricePaid { get; set; }
    }
}
