using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Checkout
{
    public partial class UsersListPage : System.Web.UI.Page, IUsersListView
    {
        public string NumberOfPersons
        {
            get
            {
                return NumberOfPersonsLbl.Text;
            }
            set
            {
                NumberOfPersonsLbl.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UsersListPresenter p = new UsersListPresenter(this, new Checkout.Model());
            p.GetUsersList(GridView1);
            if (!Page.IsPostBack)
            {
                RefreshData();
            }
            
            NumberOfPersons = p.allPersons.ToString();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            UsersListPresenter p = new UsersListPresenter(this, new Checkout.Model());
            p.GetUsersList(GridView1);
        }
        
        
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirState"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdr"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdr"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdr"] = "Asc";
                }
                GridView1.DataSource = dtrslt;
                GridView1.DataBind();
            }
        }

        public void RefreshData()
        {
            //UsersListPresenter p = new UsersListPresenter(this, new Checkout.Model());
            //p.GetUsersList(GridView1);
            DataTable sourceTable = GridView1.DataSource as DataTable;
            DataSet ds = GridView1.DataSource as DataSet;

            if (sourceTable.Rows.Count > 0)
            {
                GridView1.DataSource = sourceTable;
                GridView1.DataBind();
                ViewState["dirState"] = sourceTable;
                ViewState["sortdr"] = "Asc";
            }
            //else  //TODO
            //{
            //    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();
            //    int columncount = GridView1.Rows[0].Cells.Count;
            //    GridView1.Rows[0].Cells.Clear();
            //    GridView1.Rows[0].Cells.Add(new TableCell());
            //    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            //    GridView1.Rows[0].Cells[0].Text = "No Records Found";
            //}
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            RefreshData();
        }

        //TODO
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            UsersListPresenter p = new UsersListPresenter(this, new Checkout.Model());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            //Label labelCNPGridview = (Label)row.FindControl("CNP");
            TextBox textCNP = (TextBox)row.Cells[1].Controls[0];
            TextBox textName = (TextBox)row.Cells[2].Controls[0];
            TextBox textSurname = (TextBox)row.Cells[3].Controls[0];
            TextBox textBirthday = (TextBox)row.Cells[4].Controls[0];
            GridView1.EditIndex = -1;

            p.UpdatePersonData(Convert.ToInt32(textCNP.Text), textName.Text.ToString(), textSurname.Text.ToString(), textBirthday.Text.ToString());
            RefreshData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            RefreshData();
        }


        protected void btnGoToCustomer_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("HomeRoute");
        }
    }
}