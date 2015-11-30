using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class bidAnonymous : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    // Reading from Web.Config
                    //string connectionString = ConfigurationManager.ConnectionStrings["ConservationSchoolConnectionString"].ConnectionString;
                    //SqlConnection dbConnection = new SqlConnection(connectionString);

                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                    //                SqlConnection dbConnection = new SqlConnection("Data Source=BLLIM-LT;Integrated Security=true");
                    //                SqlConnection dbConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Integrated Security=true");
                    try
                    {
                        dbConnection.Open();
                        dbConnection.ChangeDatabase("itk485nnrs");
                        //string SQLString1 = "INSERT INTO userLogin VALUES( '" + fnameId.Text + "','" + lnameId.Text + "')";
                        string SQLString1 = "INSERT INTO anonymousbiddertable  VALUES( '" + fnameId.Text + "','" + lnameId.Text + "','" + cellId.Text + "')";
                        SqlCommand checkIDTable1 = new SqlCommand(SQLString1, dbConnection);


                        checkIDTable1.ExecuteNonQuery();




                        Session["firstname"] = fnameId.Text;
                        Session["lastname"] = lnameId.Text;
                        Session["cellPhoneNo"] = cellId.Text;
                        Response.Redirect("bidOnline.aspx");


                        //SqlDataReader idRecords = checkIDTable.ExecuteReader();
                        //if (idRecords.Read())
                        //{
                        //    Response.Write("Hello, " + username.Text);
                        //    idRecords.Close();
                        //}
                        //else
                        //{
                        //    Response.Write("**Invalid Match **");
                        //    //Label1.Text = "<p>**Invalid Match **</p>";
                        //    idRecords.Close();
                        //}
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
}