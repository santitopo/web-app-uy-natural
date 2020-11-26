using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ReservationReportRequestModel
    {
        public int TPointId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
