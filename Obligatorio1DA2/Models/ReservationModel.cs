using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ReservationModel
    {
        public int LodgingId { get; set; }
        public string Checkin { get; set; }
        public string Checkout { get; set; }
        public int AdultsNum { get; set; }
        public int ChildsNum { get; set; }
        public int BabiesNum { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }

    }
}
