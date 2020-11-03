using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ReviewModel
    {
        public string Description { get; set; }
        public int Score { get; set; }
        public Guid ReservationCode { get; set; }
    }
}
