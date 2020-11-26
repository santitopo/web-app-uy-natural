using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain
{
    public class Reservation
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public Lodging Lodging { get; set; }
        public Client Client { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public State State {get; set;}
        public string StateDescription { get; set; }
        public double Price { get; set; }

        public Reservation()
        {

        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Reservation))
            {
                return false;
            }
            return Code == ((Reservation)obj).Code;
        }
    }
}
