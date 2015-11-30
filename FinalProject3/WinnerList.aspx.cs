using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class WinnerList : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("Data Source = itksqlexp8; Integrated Security = true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginEmail"] != null)
            {
                Master.FindControl("MainSignUpId").Visible = false;
                Master.FindControl("MainLoginId").Visible = false;
                Master.FindControl("MainUpdateProfileId").Visible = true;
                Master.FindControl("MainLogoutId").Visible = true;

                Label l1 = (Label)Master.FindControl("LoggedInNameId");
                l1.Text = Session["LoggedInNameId"].ToString();

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
            else
            {
                Master.FindControl("MainSignUpId").Visible = true;
                Master.FindControl("MainLoginId").Visible = true;
                Master.FindControl("MainUpdateProfileId").Visible = false;
                Master.FindControl("MainLogoutId").Visible = false;
            }
            string rowCount;


            connection.Open();
            connection.ChangeDatabase("itk485nnrs");

            string st = "Select count(*) FROM TempBidder;";
            SqlCommand check = new SqlCommand(st, connection);

            SqlDataReader re = check.ExecuteReader();

            if (re.Read())
            {
                rowCount = re[0].ToString();
                Session["rowcount"] = rowCount;
            }

            re.Close();

            int countofrows = Convert.ToInt32(Session["rowCount"].ToString());

            string str = "SELECT name,phoneNum FROM TempBidder Where winningStatus='winner' GROUP BY name,phoneNum";
            SqlCommand checklogin = new SqlCommand(str, connection);
            SqlDataReader record = checklogin.ExecuteReader();

            for (int i = 0; i < countofrows; i++)
            {
                if (record.Read())
                {

                    Session["rowIndex"] = i;
                    HtmlTableRow row = new HtmlTableRow();

                    //name
                    HtmlTableCell cell1 = new HtmlTableCell();
                    cell1.InnerHtml = record[0].ToString();
                    cell1.Align = "center";
                    Session["name" + i] = record[0].ToString();
                    row.Cells.Add(cell1);

                    //cellphone
                    HtmlTableCell cell2 = new HtmlTableCell();
                    cell2.InnerHtml = record[1].ToString();
                    cell2.Align = "center";
                    Session["cellphone" + i] = record[1].ToString();
                    row.Cells.Add(cell2);


                    //Action(Save)
                    Button btnsave = new Button();
                    btnsave.Text = "Go";

                    btnsave.ID = "btnu" + i;
                    btnsave.CssClass = "btn btn-default";
                    btnsave.Click += new EventHandler(Btnsave_Click);
                    HtmlTableCell cell3 = new HtmlTableCell();

                    cell3.Controls.Add(btnsave);
                    row.Cells.Add(cell3);
                    example.Rows.Add(row);

                }


            }

        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string i = button.ID;
                string newstr = i.Substring(4);
                int k = Convert.ToInt32(newstr);

                //connection.ChangeDatabase("itk485nnrs");

                string name = Server.UrlEncode(Session["name" + k].ToString());
                string phone = Server.UrlEncode(Session["cellphone" + k].ToString());
                Response.Redirect("SendInvoice.aspx?name=" + name + "&cellphone=" + phone);
            }
        }


    }


}