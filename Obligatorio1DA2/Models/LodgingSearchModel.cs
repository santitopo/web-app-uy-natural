using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class LodgingSearchModel
    {
        public int TPointId { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int AdultsNum { get; set; }
        public int ChildsNum { get; set; }
        public int BabiesNum { get; set; }
    }
}
