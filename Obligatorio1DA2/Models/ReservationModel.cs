using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int LodgingId { get; set; }
        public int ClientId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int StateId { get; set; }
        public string StateDescription { get; set; }

    }
}
