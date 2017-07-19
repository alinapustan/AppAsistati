using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public interface IModel
    {
        List<String> SetInfo();
        string SavePerson(double cnp, string name, string surname, string birthday);
        Person GetPerson();
        void UpdatePerson(double cnp, string name, string surname, string birthday);
        bool GetCNPValidation(double cnp);
    }
}
