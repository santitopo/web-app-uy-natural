using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Review
    {
        public Lodging Lodging { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public Client Client { get; set; }
    }
}
