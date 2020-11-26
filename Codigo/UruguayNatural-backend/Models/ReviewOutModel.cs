using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ReviewOutModel
    {
        public string Description { get; set; }
        public int Score { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
    }
}
