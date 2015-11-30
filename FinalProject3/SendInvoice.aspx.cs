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
    public partial class SendInvoice : System.Web.UI.Page
    {

        SqlConnection connection = new SqlConnection("Data Source = itksqlexp8; Integrated Security = true");
        readonly DatabaseComponents _databaseComponents = new DatabaseComponents();
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

            Button3.Visible = false;
            string name = Request.QueryString["name"].ToString();

            string phone = Request.QueryString["cellphone"].ToString();

            TextBox4.Visible = false;
            TextBox1.Text = name;
            TextBox2.Text = phone;

            TextBox1.CssClass = "input";
            TextBox2.CssClass = "input";
            TextBox3.CssClass = "input";

            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            TextBox3.ReadOnly = true;



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
            Session["firstnameForEmail"] = name;
            Session["phoneForEmail"] = phone;
            string str = "SELECT bidId,ItemId,email,paymentStatus,bidAmount FROM TempBidder Where winningStatus='winner' and name= '" + name + "' and phoneNum= '" + phone + "';";
            SqlCommand checklogin = new SqlCommand(str, connection);
            SqlDataReader record = checklogin.ExecuteReader();


            for (int i = 0; i < countofrows; i++)
            {
                if (record.Read())
                {

                    TextBox3.Text = record[2].ToString();

                    if (!String.IsNullOrEmpty(TextBox3.Text))
                    {
                        Session["newemail"]=TextBox3.Text;
                    }

                    Session["rowIndex"] = i;
                    HtmlTableRow row = new HtmlTableRow();

                    //Bid ID
                    HtmlTableCell cell1 = new HtmlTableCell();
                    cell1.InnerHtml = record[0].ToString();
                    cell1.Align = "center";
                    row.Cells.Add(cell1);

                    //Item ID
                    HtmlTableCell cell2 = new HtmlTableCell();
                    cell2.InnerHtml = record[1].ToString();
                    cell2.Align = "center";
                    row.Cells.Add(cell2);

                    //Payment Status
                    HtmlTableCell cell3 = new HtmlTableCell();
                    cell3.InnerHtml = record[3].ToString();
                    cell3.Align = "center";
                    row.Cells.Add(cell3);



                    //Bid Amount
                    HtmlTableCell cell4 = new HtmlTableCell();
                    cell4.InnerHtml = record[4].ToString();
                    cell4.Align = "center";
                    row.Cells.Add(cell4);

                    example.Rows.Add(row);

                }
            }

            record.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.SUSMSClient s = new ServiceReference1.SUSMSClient();

            string[] st = new string[200];
            st = s.getCarriers();

            {
                //Response.Write(Session["phonenum" + newstr].ToString());

                string phonenum = "1" + TextBox2.Text;


                string message = "You have won the bid";
                string add = s.sendSMS("t-mobile", phonenum, message);

                Label4.Text = @"<div style='margin-top:20px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Message sent! </div>";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            if (Session["newemail"]==null)
            {
                Label4.Text = "Please enter the bidder's email!";
                TextBox3.Visible = false;
                TextBox4.Visible = true;
                Button3.Visible = true;

            }

           else
            {

                //string str = "SELECT email FROM TempBidder Where winningStatus='winner' and name= '" + TextBox1.Text+ "' and phoneNum= '" + TextBox2.Text + "';";
                //SqlCommand checklogin = new SqlCommand(str, connection);
                //SqlDataReader record = checklogin.ExecuteReader();

                //if (record.Read())
                //{
                //    Session["newemail"] = record[0].ToString();
                //}
                
                string name = Session["firstnameForEmail"].ToString();
                string phone = Session["phoneForEmail"].ToString();
                IList<UserBidInformation> userBidInformationList = _databaseComponents.GetInformation(name,phone);
                Email sendEmail = new Email();

                sendEmail.RecepientEmail = (Session["newemail"].ToString().Trim());
                sendEmail.Subject = "Thanks for bidding";
                sendEmail.EmailBody = "<html>"
                                    + "<head>"
                                    + " <title></title>"
                                    + "</head>"
                                    + "<h1 style='color: red' align='center'>Festival of Trees</h1>"
                                    + "<h3 style='color: green' align='center'>The best way to start your  holidays</h3>"
                                    + "<center> <img src = 'http://grinnell.lib.ia.us/wp-content/uploads/2014/10/Festival-of-Trees-Logo.jpg' alt='Logo' style='width:200px; height:200px;' align='middle'/></center>"
                                    + "<h2 align = 'center' style = 'color:red' > Invoices </h2>"
                                    + "<h4 style = 'color:green' align = 'center'><i> We appreciate your support of the Festival of Trees on behalf of the Baby Fold. During the event you purchased the following items: </i></h4>"
                                    + "<table style='width:100%' align='center' cellpadding='2' cellspacing='2' border='2' bgcolor='#EAEAEA'>"
                                    + "<tr>"
                                    + "<th>BidID</th>"
                                    + " <th>Email</th>"
                                    + "<th>Name</th>"
                                    + "<th>Bid Amount</th>"
                                    + "<th>Phone Number</th>"
                                    + "<th>Payment status</th>"
                                    + "</tr>";
                double totalBidAmount = 0;
                foreach (UserBidInformation details in userBidInformationList)
                {
                    sendEmail.EmailBody += " <tr><td>" + details.BidId + "</td>"
                                              + "<td>" + details.Email + "</td>"
                                              + "<td>" + details.Name + "</td>"
                                              + "<td>" + details.BidAmount + "</td>"
                                              + "<td>" + details.PhoneNumber + "</td>"
                                              + "<td>" + details.PaymentStatus + "</td>"
                                              + "</tr>";
                    totalBidAmount += Convert.ToDouble(details.BidAmount);
                }

                sendEmail.EmailBody += "</table><h3>Your Total Expenditure: "+ totalBidAmount + "</h3>"
                                    + "<pre style = 'color:red' align='left'>Thank You For Your Generosity <br/>"
                                    + "Sincerely,<br/>"
                                    + "Co-Chair</pre><br/>"
                                    + "<hr>"
                                    + "<h4 style = 'color:green' ><i> A portion of your purchase is tax deductable.For each item, the amount of your purchase preice which is in excess of the fair market value for that item may be an allowable charitable deduction.According to federal guidelines youa re able to deduct $ 0.00 as a charitable contribution.</i> </h4>"
                                    + "</body></html>";

                var result = sendEmail.SendEmail(sendEmail);
                //Response.Write(result ? "Email Sent successfully" : "Failed to send email!");
                Label4.Visible = false;
                Label5.Visible = true;
                Label5.Text = "Email Sent successfully";

                //After clicking on the Send Email button we are redirecting the user to a page that will show all the bids that has been placed by him/her.
                //We are showing all the bids here, however, if we want to show only won bids then we need to put condition in the query written for the gridview on
                //ShowBidToUser.aspx page. 
                //Response.Redirect("ShowBidToUser.aspx", false);


                //foreach (string car in st)
                //{
                //    Response.Write(car + "<br/>");
                //}







            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            //connection.Open();
            
            connection.ChangeDatabase("itk485nnrs");
            string email = TextBox4.Text;
            Session["newemail"] = TextBox4.Text;

            string str = "UPDATE TempBidder SET email ='" + email + "'WHERE name = '" + TextBox1.Text + "' and phoneNum='" + TextBox2.Text + "'; ";


            SqlCommand checklogin = new SqlCommand(str, connection);

            checklogin.ExecuteNonQuery();
            Label4.Text = "Email Saved Succesfully!";

            TextBox3.Text= TextBox4.Text;
            TextBox3.Visible = true;
        }

    }



}


