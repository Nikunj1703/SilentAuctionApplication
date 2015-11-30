using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net.Mime;

namespace FinalProject3
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                country.DataSource = GetCountryInfo();
                country.DataBind();
                country.Items.Insert(0, "Select Country");
            }
            
            //country.Items.Insert(0, "Select Country");
        }

     
        public void CheckUniqueEmail(Object Source, EventArgs E)
        {
            


            string connectionString = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;"
                                       + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * from dbo.signuptable "
                                    + "WHERE email = @classFilter1";


            // Specify the parameter value.
            string paramValue1 = email.Text;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@classFilter1", paramValue1);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Label4.Text = "";
                        emailErrorId.Visible = true;
                        emailErrorId2.Visible = false;
                        Label4.Text = "EmailId Already Exists.";
                    }
                    else
                    {
                        Label5.Text = "";
                        emailErrorId2.Visible = true;
                        emailErrorId.Visible = false;
                        Label5.Text = "Valid- Go Ahead!";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }





        protected string UploadFolderPath = "~/ProfilePics/";
       
       
        protected void FileUploadComplete(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
            AsyncFileUpload1.SaveAs(Server.MapPath(this.UploadFolderPath) + filename);
        }

       

        public List<string> GetCountryInfo()
        {
            List<string> list = new List<string>();
            foreach(CultureInfo info in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo inforeg = new RegionInfo(info.LCID);
                if (!list.Contains(inforeg.EnglishName))
                {
                    list.Add(inforeg.EnglishName);
                    list.Sort();
                }
            }
            return list;
        }

        protected void CreateProfile_Click(object sender, EventArgs e)
        {




            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    string first = firstName.Text;
                    string last = lastName.Text;
                    string addressTxt = address.Text;
                    string cityTxt = city.Text;
                    string stateTxt = state.Text;
                    string countryTxt = country.SelectedItem.Value;
                    string zipTxt = zip.Text;
                    string homePhNo = homePhone.Text;
                    string cellPhNo = cellPhone.Text;
                    string enableTextMsg = "No";
                    string permission = DropDownList1.SelectedItem.Value;
                    string access = "Yes";
                    if(permission.Equals("Steering Committee") || permission.Equals("Admin"))
                    {
                        access = "No";
                    }
                    if (RadioButton1.Checked)
                    {
                        enableTextMsg = "Yes";
                    }

                    string subscribeEmail = "No";
                    if (RadioButton3.Checked)
                    {
                        subscribeEmail = "Yes";
                    }

                    string imageAddress = this.UploadFolderPath+ System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
                    string pass = password.Text;
                    string emailAddress = email.Text;
                  
                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                    try
                    {
                        dbConnection.Open();
                        dbConnection.ChangeDatabase("itk485nnrs");
                    }
                    catch (SqlException exception)
                    {
                        if (exception.Number == 911) // non-existent DB
                        {
                            SqlCommand sqlCommand = new SqlCommand("CREATE DATABASE itk485nnrs", dbConnection);
                            sqlCommand.ExecuteNonQuery();
                            dbConnection.ChangeDatabase("itk485nnrs");
                        }
                        else
                            Response.Write("<p>Error code " + exception.Number
                                + ": " + exception.Message + "</p>");
                    }
                    finally
                    {
                        Console.Write("Successfully selected the database");
                    }
                    try
                    {
                        string SQLString = "SELECT * FROM signuptable";
                        SqlCommand checkIDTable = new SqlCommand(SQLString, dbConnection);
                        SqlDataReader idRecords = checkIDTable.ExecuteReader();

                       
                        idRecords.Close();
                    }
                    catch (SqlException exception)
                    {
                        if (exception.Number == 208) // object/table does not exist
                        {
                            SqlCommand sqlCommand = new SqlCommand("CREATE TABLE signuptable ( firstname VARCHAR(50), lastname VARCHAR(50),addressVARCHAR(200),city VARCHAR(50),country VARCHAR(50),state VARCHAR(50),zip VARCHAR(10),homePhone VARCHAR(50),cellPhone VARCHAR(50),email VARCHAR(50),password VARCHAR(50),imagePath VARCHAR(200),enableTextMsg VARCHAR(50),subscribeEmail VARCHAR(50), access VARCHAR(50))", dbConnection);
                            sqlCommand.ExecuteNonQuery();

                            sqlCommand = new SqlCommand("CREATE TABLE signintable (email VARCHAR(50) PRIMARY KEY, password VARCHAR(50))", dbConnection);
                            sqlCommand.ExecuteNonQuery();
                            Console.Write("Successfully created the table");
                        }
                        else
                            Response.Write("<p>Error code " + exception.Number
                                + ": " + exception.Message + "</p>");
                    }
                    finally
                    {
                        string loginDetails = "INSERT INTO signintable VALUES('"
                            + emailAddress + "', '"
                            + pass + "')";

                        string signUpDetails = "INSERT INTO signuptable VALUES('"
                            + first + "', '"
                            + last + "', '"
                             + addressTxt + "', '"
                              + cityTxt + "', '"
                               + countryTxt + "', '"
                                + stateTxt + "', '"
                                 + zipTxt + "', '"
                                 + homePhNo + "', '"
                                 + cellPhNo + "', '"
                                 + emailAddress + "', '"
                                 + pass + "', '"
                                 + imageAddress + "', '"
                                 + enableTextMsg + "', '"
                                 + subscribeEmail + "', '"
                                 + permission + "', '"
                            + access + "')";

                        SqlCommand sqlCommand = new SqlCommand(loginDetails, dbConnection);
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand = new SqlCommand(signUpDetails, dbConnection);
                        sqlCommand.ExecuteNonQuery();
                        string tempImgPath1 = imageAddress.ToString().Replace('~', '.');
                        Session["profilePicTemp"] = tempImgPath1;

                        Label l1 = (Label)Master.FindControl("LoggedInNameId");
                        l1.Text = "Welcome " + first + "!";
                        Session["LoggedInNameId"] = l1.Text;
                    }


                  

                    string connectionString = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;"
                                      + "Integrated Security=true";
                    // Provide the query string with a parameter placeholder.
                    string queryString = "SELECT * from dbo.signuptable "
                                            + "WHERE email = @classFilter1";


                    // Specify the parameter value.
                    string paramValue1 = emailAddress;

                    // Create and open the connection in a using block. This
                    // ensures that all resources will be closed and disposed
                    // when the code exits.
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Create the Command and Parameter objects.
                        SqlCommand command = new SqlCommand(queryString, connection);
                        command.Parameters.AddWithValue("@classFilter1", paramValue1);

                        // Open the connection in a try/catch block.
                        // Create and execute the DataReader, writing the result
                        // set to the console window.
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                Literal1.Text += "<p>Thanks for Signing-up.<br/>Your information is sent to your email address.</p>";
                                string emailBody = "First Name: " + reader["firstname"] + "<br/>Last Name: " + reader["lastname"] + "<br/>Email: " + reader["email"] + "<br/>Password: " + reader["password"]; ;

                                //Sending Email
                                string myEmail = "nratnap@ilstu.edu";
                                string myName = "Nikunj";
                                MailAddress messageFrom = new MailAddress(myEmail, myName);
                                MailMessage emailMessage = new MailMessage();
                                emailMessage.IsBodyHtml = true;
                                emailMessage.From = messageFrom;

                                MailAddress messageTo = new MailAddress(emailAddress, first);
                                emailMessage.To.Add(messageTo.Address);




                                string messageSubject = "Welcome to Festival of Trees: Silent Bidding";
                                emailMessage.Subject = messageSubject;
                                string htmlBody = "<html><body><h3>Hello User,</h3><p>You are our valuable customer. Feel free to get in-touch with us. Our representatives are always happy to help you.</br> Please find below your infomation</br>" + emailBody + "</p><h3/><br/>Thanks,<br/>IT485 Team</h3><br><img src=\"cid:Pic1\"></body></html>";
                                AlternateView avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);

                                // Create a LinkedResource object for each embedded image
                                LinkedResource pic1 = new LinkedResource((Server.MapPath("~/logo.jpg")), MediaTypeNames.Image.Jpeg);
                                pic1.ContentId = "Pic1";
                                avHtml.LinkedResources.Add(pic1);
                                emailMessage.AlternateViews.Add(avHtml);
                                SmtpClient mailClient = new SmtpClient("smtp.ilstu.edu");
                                mailClient.UseDefaultCredentials = true;// false;
                                mailClient.Send(emailMessage);
                                Literal1.Text += "<br/>Your password and registration details are sent to your email address";
                                Session["loginEmail"] = email.Text;
                                Session["permissionLevel"] = permission;
                                Response.Redirect("SignUpSuccess.aspx");
                                Response.Redirect(Request.RawUrl + "#success");
                                

                            }
                            else
                            {
                                Literal1.Text = "<p>Please Try Again!</p>";
                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    dbConnection.Close();
                }
            }





















        }

       



    }

   
   }