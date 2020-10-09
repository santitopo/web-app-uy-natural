using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ReservationUpdateModel
    {
        public int ReservationId{ get; set; }
        public int StateId { get; set; }
        public string StateDescription { get; set; }

    }
}
