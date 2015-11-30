using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class SignUpSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;"
                                      + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * from dbo.signuptable "
                                    + "WHERE email = @classFilter1";


            // Specify the parameter value.
            string paramValue1 = Session["loginEmail"].ToString(); ;


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
                        if (reader["access"].Equals("Yes"))
                            Response.Redirect("BiddingHomescreen.aspx");
                        else
                        {
                            if (Session["loginEmail"] != null)
                            {
                                Label1.Text = "Pending Resquest! <p>Your request will be approved by Admin. You can still log-in and be a part of <b>Festival of Trees</b></p>";
                                Master.FindControl("MainSignUpId").Visible = false;
                                Master.FindControl("MainLoginId").Visible = false;
                                Master.FindControl("MainUpdateProfileId").Visible = true;
                                Master.FindControl("MainLogoutId").Visible = true;
                            }
                        }
                            
                    }
                    else
                    {
                        Response.Write("Some error occured");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}