using System;
using System.Collections.Generic;

namespace Domain
{
    public class UserSession
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public virtual Administrator User { get; set; }
        public DateTime ConnectedAt { get; set; }
        public UserSession()
        {
            ConnectedAt = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is UserSession))
            {
                return false;
            }
            return Token == ((UserSession)obj).Token;
        }
    }
}
