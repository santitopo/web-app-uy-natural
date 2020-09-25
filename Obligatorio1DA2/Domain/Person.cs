using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }

        public Person()
        {

        }

        public Person(string name, string surname,  string mail)
        {
            Name = name;
            Surname = surname;
            Mail = mail;
        }
    }
}
