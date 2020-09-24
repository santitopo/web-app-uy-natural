using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class BillModel
    {
        public int Code { get; set; }
        public State State { get; set; }
        public string StateDescription { get; set; }
    }
}
