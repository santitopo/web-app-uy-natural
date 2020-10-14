using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Client : Person
    {
        public Client()
        {

        }

        public Client(string name, string surname, string mail): base (name, surname, mail)
        {

        }
    }
}
