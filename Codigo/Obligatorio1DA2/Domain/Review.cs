using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public Client Client { get; set; }
        public Reservation Reservation { get; set; }

        public Review()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Review))
            {
                return false;
            }
            return 
                Description.Equals(((Review)obj).Description) &&
                Client.Equals(((Review)obj).Client) &&
                Score.Equals(((Review)obj).Score)&&
                Reservation.Equals(((Review)obj).Reservation);
        }
    }
}
