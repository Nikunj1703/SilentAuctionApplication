using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginEmail"] != null)
            {
                Master.FindControl("MainSignUpId").Visible = false;
                Master.FindControl("MainLoginId").Visible = false;
                Master.FindControl("MainUpdateProfileId").Visible = true;
                Master.FindControl("MainLogoutId").Visible = true;
                if (Session["permissionLevel"].Equals("Admin"))
                {
                    Master.FindControl("MainSearchId").Visible = true;
                    Master.FindControl("MainAddAuctionItemId").Visible = true;
                    Master.FindControl("EnterWinnerId").Visible = true;
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
            else
            {
                Master.FindControl("MainSignUpId").Visible = true;
                Master.FindControl("MainLoginId").Visible = true;
                Master.FindControl("MainUpdateProfileId").Visible = false;
                Master.FindControl("MainLogoutId").Visible = false;
            }

        }

        string emailFromSignUpTable = "";
        protected string LookUpEmailBasedOnPhoneName()
        {
            string phone = TextBox3.Text;
            string name = TextBox2.Text;
            
            try
            {
                SqlConnection connection = new SqlConnection("Data Source = itksqlexp8; Integrated Security = true");
                connection.Open();
                connection.ChangeDatabase("itk485nnrs");
                string query =
                            "Select email from signuptable where cellPhone = '"+phone+"' and firstname='"+name+"'";
                SqlCommand command = new SqlCommand(query, connection);

                
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    emailFromSignUpTable = reader["email"]+"";
                    connection.Close();
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                Response.Write("Some error occured: "+ex.Message);
            }
            return emailFromSignUpTable;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            
            string itemId = TextBox5.Text;
            string name = TextBox2.Text;
            string phonenumber = TextBox3.Text;
            string bidamount = TextBox4.Text;
            string paymentstatus;
            string winningstatus = "winner";
            string email = LookUpEmailBasedOnPhoneName();



            if (CheckBox1.Checked)
            {
                paymentstatus = "Paid";
                
            }
            else
            {
                paymentstatus = "Not Paid";

            }


            SqlConnection connection = new SqlConnection("Data Source = itksqlexp8; Integrated Security = true");
            connection.Open();
            connection.ChangeDatabase("itk485nnrs");


            string str= "INSERT INTO dbo.TempBidder VALUES('"
                            + email + "', '"
                            + itemId + "', '"
                            + winningstatus + "', '"
                            + paymentstatus + "', '"
                            + bidamount + "', '"
                            + phonenumber + "', '"
                            + name + "')";


          //  string st = "INSERT INTO TempBidder (itemId,winningStatus,paymentstatus,bidAmount,phoneNum,name) VALUES('" + itemId + "', '" +winningstatus+"', '" +paymentstatus+ "', '" +bidamount+ "', '" +phonenumber+"', '" +name + "');";
            SqlCommand s = new SqlCommand(str, connection);
            s.ExecuteNonQuery();

            Label1.Text = "The details have been saved";



        }
    }
}