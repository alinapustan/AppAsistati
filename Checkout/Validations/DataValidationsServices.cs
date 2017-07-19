using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkout
{
    public class DataValidationsServices
    {
        public FileServices fileservice = new FileServices();

        public bool IsCNPUnique(double cnp)
        {
            List<Person> allPersons = new List<Person>();
            bool isCNPUnique = true;
            allPersons = fileservice.Read();
            foreach (var p in allPersons)
            {
                if (p.CNP == cnp)
                    isCNPUnique = false;
            }
            return isCNPUnique;
        }
    }
}