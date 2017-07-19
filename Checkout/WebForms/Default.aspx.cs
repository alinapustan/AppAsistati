using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace Checkout
{
    public partial class Default : System.Web.UI.Page, IView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect(GetRouteUrl("HomeRoute", null));
            Presenter p = new Presenter(this, new Checkout.Model());
            Button3.Visible = false;

        }

        #region IView Members

        public string LabelGetName
        {
            get
            {
                return lblGetName.Text;
            }
            set
            {
                lblGetName.Text = value;
            }
        }
        public string LabelGetSurname
        {
            get
            {
                return lblGetSurname.Text;
            }
            set
            {
                lblGetSurname.Text = value;
            }
        }
        public DateTime LabelGetBirthday
        {
            get
            {
                return Convert.ToDateTime(lblbday.Text);
            }
            set
            {
                lblbday.Text = value.ToString();
            }
        }
        public string NameTextBox
        {
            get
            {
                return TextBox1.Text;
            }
            set
            {
                TextBox1.Text = value;
            }
        }
        public string SurnameTextBox
        {
            get
            {
                return TextBox1.Text;
            }
            set
            {
                TextBox1.Text = value;
            }
        }
        public string LabelShowCNP
        {
            get
            {
                return lblCNP.Text;
            }
            set
            {
                lblCNP.Text = value.ToString();
            }
        }
        public string LabelShowName
        {
            get
            {
                return lblName.Text;
            }
            set
            {
                lblName.Text = value;
            }
        }
        public string LabelShowSurname
        {
            get
            {
                return lblSurname.Text;
            }
            set
            {
                lblSurname.Text = value;
            }
        }
        public string LabelShowBirthday
        {
            get
            {
                return lblBirthday.Text;
            }
            set
            {
                lblBirthday.Text = value;
            }
        }
        public string LabelSuccess
        {
            get
            {
                return lblSuccess.Text;
            }
            set
            {
                lblSurname.Text = value;
            }
        }

        #endregion

        #region Buttons action

        //Save person data
        protected void Button1_Click(object sender, EventArgs e)
        {
            Presenter p = new Presenter(this, new Checkout.Model());
            // p.BindModalView();
            
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "somekey", "saveCheckData()", true);

            if (LabelGetBirthday.ToString().Length > 0 && TextBox1.Text.Length > 0 && TextBox2.Text.Length > 0 && TextBox3.Text.Length > 0)
            {
                //if (TextBox1.BorderColor.ToKnownColor().ToString() != Color.Red.Name && TextBox2.BorderColor.ToString() != Color.Red.Name && TextBox3.BorderColor.ToString()!= Color.Red.Name)
                if (TextBox3.Text.Length == 13 && lblCNPValidation.Text.Contains("Nr."))
                {
                    DateTime fullDate = Convert.ToDateTime(lblbday.Text);
                    var shortDate = fullDate.Date.ToShortDateString();

                    string s = p.SavePersonData(Convert.ToDouble(TextBox3.Text), TextBox1.Text, TextBox2.Text, shortDate); //name, surname, date

                    lblSuccess.Text = s;
                    lblSuccess.Visible = true;
                    Button1.Visible = false;
                    Button3.Visible = true; //show button for user to see his data
                    TextBox1.Text = string.Empty;
                    TextBox2.Text = string.Empty;
                    TextBox3.Text = string.Empty;
                    lblbday.Text = string.Empty;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Check the red boxes! :) " + "');", true);
                }
            }
            else if (lblbday.Text.Length == 0 || NameTextBox.Length == 0 || SurnameTextBox.Length == 0)
            {   //alerta pentru textbox-uri goale
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please fill in your info! :) " + "');", true);
            }

        }

        //show calendar
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible)
                Calendar1.Visible = false;
            else Calendar1.Visible = true;
        }

        //get data for last person saved 
        protected void Button3_Click(object sender, EventArgs e)
        {
            Presenter p = new Presenter(this, new Checkout.Model());
            p.GetPersonData();
            lblCNP.Visible = true;
            lblName.Visible = true;
            lblSurname.Visible = true;
            lblBirthday.Visible = true;
        }

        protected void MenuBtnToUsersList_Click(object sender, EventArgs e)
        {
            Response.Redirect(GetRouteUrl("UsersListRoute", null));
        }
        #endregion

        #region Others:Calendar

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lblbday.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar1_Load(object sender, EventArgs e)
        {
            lblday.Text = Calendar1.TodaysDate.ToShortDateString();
        }
        #endregion

        #region WebMethods 
        //leaga JS de metode din c#
        [WebMethod]
        public static string CNPValidation(double cnp)
        {
            //string result = GetCNP(cnp);
            string result = "dadada";
            return result;
        }

        public static string GetCNP(double cnp)
        {
            Default d = new Default();
            string r = d.GetCheckCNPResult(cnp);
            return r;
        }

        public string GetCheckCNPResult(double cnp)
        {
            string result = string.Empty;
            Presenter p = new Presenter(this, new Checkout.Model());
            string cnpString = cnp.ToString("0.####");
            if (cnp != 0)
            {
                if (!p.GetCNPValidation(cnp))
                    result = "CNP-ul exista deja!";
            }
            else
            {
                if (cnpString[0] == '0')
                    result = "CNP-ul nu poate incepe cu 0";
            }
            return result;
        }
        #endregion
    }
}