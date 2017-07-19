using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Checkout
{
    public class UsersListPresenter
    {
        IUsersListView _pView;
        IModel _pModel;
        public int allPersons = 0;
        public UsersListPresenter(IUsersListView PView, IModel PModel)
        {
            _pView = PView;
            _pModel = PModel;
        }

        public DataTable GetUsersList(GridView g)
        {
            DataTable table = new DataTable();
            table.Columns.Add("CNP");
            table.Columns.Add("Name");
            table.Columns.Add("Surname");
            table.Columns.Add("Birthday");

            using (StreamReader sr = new StreamReader(@"C:\Users\alina.pustan\Documents\Visual Studio 2017\Projects\Checkout\Checkout\App_Data\Persons.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] parts = sr.ReadLine().Split('#');
                    table.Rows.Add(parts[0], parts[1], parts[2], parts[3]);
                    allPersons++;
                }
            }
            g.DataSource = table;
            g.DataBind();

            return table;
        }

        public void UpdatePersonData(int cnp, string name, string surname, string birthday)
        {
            _pModel.UpdatePerson(cnp, name, surname, birthday);
        }
    }
}