﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain
{
    public class Reservation
    {
        public int Code { get; set; }
        public Lodging Lodging { get; set; }
        public Client Client { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public State State {get; set;}
        public string StateDescription { get; set; }

        public Reservation()
        {

        }
    }
}
