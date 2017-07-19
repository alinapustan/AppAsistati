using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkout
{
    public class Presenter
    {
        IView _pView;
        IModel _pModel;
        public Presenter(IView PView, IModel PModel)
        {
            _pView = PView;
            _pModel = PModel;
        }

        //not used
        public void BindModalView()
        {
            List<String> ls = _pModel.SetInfo();
            _pView.LabelGetName = ls[0];
            _pView.NameTextBox = ls[1];
        }

        //ia datele de pe Web Form si le trimite modelului
        public string SavePersonData(double cnp, string name, string surname, string birthday)
        {
            string s = _pModel.SavePerson(cnp, name, surname, birthday);
            if (s == "CNP not unique")
            {

            }
            return s;
        }

        //ia din model ultima persoana salvata
        public void GetPersonData()
        {
            Person p = _pModel.GetPerson();
            _pView.LabelShowCNP = p.CNP.ToString() ;
            _pView.LabelShowName = p.Name;
            _pView.LabelShowSurname = p.Surname;
            _pView.LabelShowBirthday = p.Birthday;
        }

        public bool GetCNPValidation(double cnp)
        {
            bool isCNPUnique = _pModel.GetCNPValidation(cnp);
            return isCNPUnique;
        }
    }
}