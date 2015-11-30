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
    public partial class checkadminRequest : System.Web.UI.Page
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
            }
            else
            {
                Master.FindControl("MainSignUpId").Visible = true;
                Master.FindControl("MainLoginId").Visible = true;
                Master.FindControl("MainUpdateProfileId").Visible = false;
                Master.FindControl("MainLogoutId").Visible = false;
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
            string rowCount;


            connection.Open();
            connection.ChangeDatabase("itk485nnrs");

            string st = "Select count(*) FROM signuptable;";
            SqlCommand check = new SqlCommand(st, connection);

            SqlDataReader re = check.ExecuteReader();

            if (re.Read())
            {
                rowCount = re[0].ToString();
                Session["rowcount"] = rowCount;
                //Printing number of rows in the table
                // Response.Write(rowcount);
            }

            re.Close();

            int countofrows = Convert.ToInt32(Session["rowCount"].ToString());

            string str = "SELECT firstname,lastname,address,cellPhone,email,permission,access FROM signuptable Where (permission='Admin' OR permission='Steering Committee') and access='No';";
            SqlCommand checklogin = new SqlCommand(str, connection);
            SqlDataReader record = checklogin.ExecuteReader();

            for (int i = 0; i < countofrows; i++)
            {
                if (record.Read())
                {

                    Session["rowIndex"] = i;
                    HtmlTableRow row = new HtmlTableRow();

                    //firstname
                    HtmlTableCell cell1 = new HtmlTableCell();
                    cell1.InnerHtml = record[0].ToString();
                    cell1.Align = "center";
                    cell1.Attributes.Add("color", "white");
                    cell1.Attributes.Add("font-weight", "bolder");
                    row.Cells.Add(cell1);

                    //lastname
                    HtmlTableCell cell2 = new HtmlTableCell();
                    cell2.InnerHtml = record[1].ToString();
                    cell2.Align = "center";
                    row.Cells.Add(cell2);

                    //address
                    HtmlTableCell cell3 = new HtmlTableCell();
                    cell3.InnerHtml = record[2].ToString();
                    cell3.Align = "center";
                    row.Cells.Add(cell3);

                    //cell phone 
                    HtmlTableCell cell4 = new HtmlTableCell();
                    cell4.InnerHtml = record[3].ToString();
                    cell4.Align = "center";
                    row.Cells.Add(cell4);

                    //email
                    HtmlTableCell cell5 = new HtmlTableCell();
                    cell5.InnerHtml = record[4].ToString();
                    cell5.Align = "center";
                    Session["email" + i] = record[4].ToString();
                    row.Cells.Add(cell5);

                    //permission
                    HtmlTableCell cell6 = new HtmlTableCell();
                    cell6.InnerHtml = record[5].ToString();
                    cell6.Align = "center";
                    row.Cells.Add(cell6);


                    //access

                    CheckBox ch = new CheckBox();
                    ch.Visible = true;
                    ch.ID = "check" + i;
                    ch.EnableViewState = true;
                    if (record[6].ToString() == "No")
                    {
                        ch.Checked = false;
                    }


                    // ch.Enabled = false;

                    HtmlTableCell cell7 = new HtmlTableCell();
                    cell7.Controls.Add(ch);
                    cell7.Align = "center";
                    row.Cells.Add(cell7);

                    //Action(Save)
                    Button btnsave = new Button();
                    btnsave.Text = "Save";

                    btnsave.ID = "btnu" + i;
                    btnsave.CssClass = "btn btn-default";
                    btnsave.Click += new EventHandler(Btnsave_Click);
                    HtmlTableCell cell8 = new HtmlTableCell();

                    cell8.Controls.Add(btnsave);
                    row.Cells.Add(cell8);
                    example.Rows.Add(row);


                }

            }

            record.Close();

        }
        //save
        private void Btnsave_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string i = button.ID;
                string newstr = i.Substring(4);
                int k = Convert.ToInt32(newstr);

                //connection.ChangeDatabase("itk485nnrs");

                CheckBox cb = (CheckBox)admindiv.FindControl("check" + newstr);

                if (cb.Checked)
                {
                    string st = "Update signuptable SET access ='Yes' WHERE email='" + Session["email" + k].ToString() + "';";
                    SqlCommand checkagain = new SqlCommand(st, connection);

                    checkagain.ExecuteNonQuery();


                    cb.Checked = true;
                    cb.Enabled = false;

                    Label1.Text = @"<div style='margin-top:20px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Row has been updated! </div>";
                }

                else
                {
                    string st = "Update signuptable SET access ='No' WHERE email='" + Session["email" + k].ToString() + "';";
                    SqlCommand checkagain = new SqlCommand(st, connection);

                    checkagain.ExecuteNonQuery();


                    cb.Checked = false;
                    cb.Enabled = false;

                    Label1.Text = @"<div style='margin-top:20px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Row has been updated!  </div>";
                }

            }


        }

    }


}