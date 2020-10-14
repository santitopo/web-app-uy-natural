using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class LodgingSearchModel
    {
        public int TPointId { get; set; }
        public string Checkin { get; set; }
        public string Checkout { get; set; }
        public int AdultsNum { get; set; }
        public int ChildsNum { get; set; }
        public int BabiesNum { get; set; }
    }
}
