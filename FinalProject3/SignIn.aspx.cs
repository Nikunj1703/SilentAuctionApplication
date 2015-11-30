using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;

namespace FinalProject3
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int tempVal = Convert.ToInt32(Session["counterVal"].ToString());

            


        }


        protected void Button_Click(object sender, EventArgs e)
        {



            SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Initial Catalog=itk485nnrs;Integrated Security=true");

            try
            {
                dbConnection.Open();

                string databaseUserID = "SELECT * FROM signintable WHERE email= '" + email.Text + " 'and password='" + password.Text + "'";


                SqlCommand checkTable = new SqlCommand(databaseUserID, dbConnection);
                SqlDataReader record = checkTable.ExecuteReader();

               
               


                if (record.Read())
                {
                    // Label1.Text = "Successfully signed in";
                    //Response.Write("Successfully signed in");
                    Session["loginEmail"] = email.Text;
                    //record.Close();
                    record.Close();
                }
                else
                {

                    //Label1.Text = "**Invalid user ID or Password**";
                    //Response.Write("**Invalid user ID or Password**");
                    Label1.Text = @"<div style='margin-top:20px' class='form - group alert alert-danger fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Invalid user ID or Password </div>";


                    int counter = 0;
                    bool nag = false;
                    //Session["counter"] = 0;
                    // if nag counter established before, start nagging if over threshold or increment counter
                    if (Session["counter"] != null)
                    {

                        counter = Convert.ToInt32(Session["counter"].ToString());
                        if (counter > 1)
                        {
                            nag = true;
                            counter = 1;
                        }
                        else
                        {
                            ++counter;
                            Session["counter"] = counter;
                        }



                    }
                    else
                    {
                        ++counter;
                        Session["counter"] = counter;


                    }
                    //Session["counterVal"] = counter;
                    if (nag)
                        Literal1.Visible = true;
                }
                SqlDataReader record2 = null; 
                try
                {
                    string findAdmin = "SELECT firstname, permission, imagePath FROM signuptable WHERE email= '" + email.Text + " '";
                    SqlCommand checkTable2 = new SqlCommand(findAdmin, dbConnection);
                     record2 = checkTable2.ExecuteReader();
                    if (record2.Read())
                    {
                        String permissionLevel = record2["permission"].ToString();
                        Session["permissionLevel"] = permissionLevel;
                        String tempS = Session["permissionLevel"].ToString();

                        Label l1 = (Label)Master.FindControl("LoggedInNameId");
                        l1.Text = "Welcome " + record2["firstname"]+"!";
                        Session["LoggedInNameId"] = l1.Text;

                        string tempImgPath1 = record2["imagePath"].ToString().Replace('~', '.');
                        Session["profilePicTemp"] = tempImgPath1;

                        Console.Write(tempS);
                        record2.Close();
                        
                    }
                    Response.Redirect("BiddingHomescreen.aspx",false);
                }
                catch(Exception ex)
                {
                   // Response.Write("Some error occured : "+ex.Message);
                }

                
                record.Close();
            }



            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                        + ": " + exception.Message + "</p>");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["forgotemail"] = TextBox1.Text;

            if (Session["forgotemail"] != null)
            {
                SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Initial Catalog=itk485nnrs;Integrated Security=true");
                try
                {
                    dbConnection.Open();
                    dbConnection.ChangeDatabase("itk485nnrs");

                    string databaseUserID = "SELECT password FROM signintable WHERE email= '" + TextBox1.Text + "'";


                    SqlCommand checkTable = new SqlCommand(databaseUserID, dbConnection);
                    SqlDataReader record = checkTable.ExecuteReader();
                    if (record.Read())
                    {

                        MailMessage mail = new MailMessage();
                        string subject = "Password recovery";
                        string to = TextBox1.Text;

                        string body = @"Your password is " + record["password"].ToString() + "";

                        mail.To.Add(to);
                        mail.From = new MailAddress("rkpande@ilstu.edu");
                        mail.Body = body;
                        mail.Subject = subject;

                        SmtpClient mailClient = new SmtpClient("smtp.ilstu.edu");
                        // Credentials are necessary if the server requires the client 
                        // to authenticate before it will send e-mail on the client's behalf.
                        // Do this in the web.config file

                        mailClient.UseDefaultCredentials = true;// false;
                        mailClient.Send(mail);







                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password has been sent to your email')", true);
                        Response.Redirect(Request.RawUrl + "#success");
                        record.Close();

                    }
                    else
                    {

                        //Label1.Text = "**Invalid user ID or Password**";
                        //Response.Write("**Invalid email**");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid email')", true);


                    }
                }

                catch (SqlException exception)
                {
                    Response.Write("<p>Error code " + exception.Number
                            + ": " + exception.Message + "</p>");
                }


            }


        }
    }
}
