using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace Checkout
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);

        }

        public static void RegisterRoutes(RouteCollection routeCollection)
        {
            routeCollection.MapPageRoute("HomeRoute", "HomePage", "~/WebForms/Default.aspx");
            routeCollection.MapPageRoute("UsersListRoute", "UsersList", "~/WebForms/UsersListPage.aspx");
            //routeCollection.Ignore("{page}.aspx/{*webmethod}");

        }


    }
}