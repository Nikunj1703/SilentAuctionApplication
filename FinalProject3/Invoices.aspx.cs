using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Data.SqlClient;

namespace FinalProject3
{
    public partial class Invoices : Page
    {
        readonly DatabaseComponents _databaseComponents = new DatabaseComponents();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Remove this when session functionality has been implemented.
            //     Session["email"] = "nivedita.mits@gmail.com";
            Session["email"] = email.Text;
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            IList<UserBidInformation> userBidInformationList = _databaseComponents.GetInformation(Session["name"].ToString(),Session["phone"].ToString());
            Email sendEmail = new Email();

            sendEmail.RecepientEmail = (email.Text).Trim();
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

            foreach (UserBidInformation details in userBidInformationList)
            {
                sendEmail.EmailBody += " <tr><td>" + details.BidId + "</td>"
                                          + "<td>" + details.Email + "</td>"
                                          + "<td>" + details.Name + "</td>"
                                          + "<td>" + details.BidAmount + "</td>"
                                          + "<td>" + details.PhoneNumber + "</td>"
                                          + "<td>" + details.PaymentStatus + "</td>"
                                          + "</tr>";
            }

            sendEmail.EmailBody += "</table>"
                                + "<pre style = 'color:red' align='left'>Thank You For Your Generosity <br/>"
                                + "Sincerely,<br/>"
                                + "Co-Chair</pre><br/>"
                                + "<hr>"
                                + "<h4 style = 'color:green' ><i> A portion of your purchase is tax deductable.For each item, the amount of your purchase preice which is in excess of the fair market value for that item may be an allowable charitable deduction.According to federal guidelines youa re able to deduct $ 0.00 as a charitable contribution.</i> </h4>"
                                + "</body></html>";

            var result = sendEmail.SendEmail(sendEmail);
            Response.Write(result ? "Email Sent successfully" : "Failed to send email!");
            //After clicking on the Send Email button we are redirecting the user to a page that will show all the bids that has been placed by him/her.
            //We are showing all the bids here, however, if we want to show only won bids then we need to put condition in the query written for the gridview on
            //ShowBidToUser.aspx page. 
            //Response.Redirect("ShowBidToUser.aspx", false);
        }
    }
}
