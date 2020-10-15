using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Administrator : Person
    {
        public string Password { get; set; }

        public Administrator()
        {

        }

        public Administrator(string name, string surname, string mail, string password) : base(name, surname, mail)
        {
            Password = password;
        }

    }
}
