using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Checkout
{
    public class FileServices
    {
        //Writes a persons details into file
        string filePath = @"C:\Users\alina.pustan\Documents\Visual Studio 2017\Projects\Checkout\Checkout\App_Data\Persons.txt";
        public void Write(List<Person> persons)
        {
            foreach (var p in persons)
            {
                string person = p.CNP +"#" + p.Name + "#" + p.Surname + "#" + p.Birthday;
                using (StreamWriter outputfile = new StreamWriter(filePath, true))
                {
                    outputfile.WriteLine(person);
                }
            }
        }

        //read all the persons in the file and returns a list of persons
        public List<Person> Read()
        {
            List<Person> persons = new List<Person>();
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                string[] personData = line.Split('#');
                Person pp = new Person(Convert.ToDouble(personData[0]), personData[1], personData[2], personData[3]);
                persons.Add(pp);
            }
            file.Close();

            return persons;
        }

        public void UpdatePersonInFile(double cnp, string name, string surname, string bday)
        {
            Person toDelete = new Person();
            Person toAdd = new Person();
            int pozitie = -1;
            List<Person> persons = Read();
            for (int i=0; i<persons.Count();i++)
            {
                if (persons[i].CNP == cnp)
                {
                    toAdd.CNP = cnp;
                    toAdd.Name = name;
                    toAdd.Surname = surname;
                    toAdd.Birthday = bday;
                    pozitie = i;
                    toDelete.CNP = persons[i].CNP;
                    toDelete.Name = persons[i].Name;
                    toDelete.Surname = persons[i].Surname;
                    toDelete.Birthday = persons[i].Birthday;
                    persons.Remove(toDelete);
                    persons.Insert(pozitie, toAdd);
                    Write(persons);
                    break;
                }
            }
        }
    }
}