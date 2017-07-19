using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkout
{
    class Model : IModel
    {
        public List<Person> personsList;
        public FileServices fileService = new FileServices();
        public DataValidationsServices dataValidations = new DataValidationsServices();

        public Model()
        {
            personsList = new List<Person>();
        }
        
        public List<String> SetInfo()
        {
            List<String> l = new List<string>();
            l.Add("Enter Name:");
            l.Add("Use capital letter only");
            return l;
        }

        public Person GetPerson()
        {
            personsList = fileService.Read();
            Person p1 = personsList.Last();
            return p1;
        }

        public void UpdatePerson(double cnp, string name, string surname, string birthday)
        {
            fileService.UpdatePersonInFile(cnp, name, surname, birthday);
        }

        public string SavePerson(double cnp, string name, string surname, string birthday)
        {
            string s = string.Empty;
            try
            {
                if (dataValidations.IsCNPUnique(cnp))
                {
                    Person p = new Person(cnp, name, surname, birthday);
                    personsList.Add(p);
                    fileService.Write(personsList);
                    s = "Person added";
                }
                else s = "CNP not unique";
            }
            catch
            {
                s = "Fail";
            }
            return s;
        }

        public bool GetCNPValidation(double cnp)
        {
            bool isCNPUnique = dataValidations.IsCNPUnique(cnp);
            return isCNPUnique;
        }
    }
}