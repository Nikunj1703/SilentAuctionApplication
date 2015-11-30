using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginEmail"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                //check if not admin then redirect to default
                if (!Session["permissionLevel"].Equals("Admin"))
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    //Master.FindControl("MainSearchId").Visible = true;
                }
            }

            if (Session["loginEmail"] != null)
            {
                Master.FindControl("MainSignUpId").Visible = false;
                Master.FindControl("MainLoginId").Visible = false;
                Master.FindControl("MainUpdateProfileId").Visible = true;
                Master.FindControl("MainLogoutId").Visible = true;
            }
            //From here
            string temp2 = Session["adminAccess"].ToString();
            //To here and one condition in if statment
            if (Session["permissionLevel"].Equals("Admin") && temp2.Equals("Yes"))
            {
                Master.FindControl("MainSearchId").Visible = true;
                Master.FindControl("MainAddAuctionItemId").Visible = true;
                Master.FindControl("EnterWinnerId").Visible = true;
                Master.FindControl("UpdateWinnerInfoId").Visible = true;
                Master.FindControl("CheckAdminRequestId").Visible = true;
                Master.FindControl("ViewReportId").Visible = true;
                Master.FindControl("SendInvoiceId").Visible = true;
            }
            if (Session["permissionLevel"].Equals("Steering Committee"))
            {
                Master.FindControl("MainAddAuctionItemId").Visible = true;
            }
            if (Session["permissionLevel"].Equals("Designer/Donor"))
            {
                Master.FindControl("MainAddAuctionItemId").Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "Finding Auction Items")
            {
                //  Response.Redirect("SearchAndEdit.aspx");
                Response.Redirect("SearchAucItem.aspx");

            }


            if (DropDownList1.SelectedItem.Text == "Finding Users")
            {

                //Response.Redirect("BuyerSearchEdit.aspx");
                Response.Redirect("SearchBuy.aspx");
            }
        }

    }
}