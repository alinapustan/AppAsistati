using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkout
{
    public class Person
    {
        public double CNP { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }

        public Person(double cnp, string name, string surname, string birthday)
        {
            CNP = cnp;
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public Person()
        {
            CNP = -1;
            Name = string.Empty;
            Surname = string.Empty;
            Birthday = string.Empty;
        }
    }
}