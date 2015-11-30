using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (Session["loginEmail"] != null)
            {
                TextBox1.Text = Convert.ToString(Session["loginEmail"]);
                Page.Validate();
                if (Page.IsValid)
                {
                    string useremail = TextBox1.Text;


                    SqlConnection connection = new SqlConnection("Data Source = itksqlexp8; Integrated Security = true");
                    try
                    {
                        connection.Open();
                        connection.ChangeDatabase("itk485nnrs");

                        string str = "SELECT * FROM signuptable WHERE (email='" + useremail + "')";
                        SqlCommand checklogin = new SqlCommand(str, connection);
                        SqlDataReader record = checklogin.ExecuteReader();

                        if (record.Read())
                        {
                            Label2.Visible = false;

                            record.Close();
                            Session["email"] = TextBox1.Text;
                            Response.Redirect("EditandUpdateProBootstrap.aspx");

                        }

                        else
                        {

                            
                           
                            Label2.Text = "Email does not exist in the system!";
                        }

                    }
                    catch (SqlException ex)
                    {
                        Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
                    }

                }

                else
                {
                    Label2.ForeColor = System.Drawing.Color.Red;
                    Label2.Text = "Invalid email!";
                }

            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {




        }


    }
    
}
