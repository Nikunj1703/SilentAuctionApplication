using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loginEmail"] != null) {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }



        }
    }
}