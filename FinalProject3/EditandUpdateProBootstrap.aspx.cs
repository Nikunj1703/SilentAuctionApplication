using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class EditandUpdateProBootstrap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginEmail"] != null)
            {
                Master.FindControl("MainSignUpId").Visible = false;
                Master.FindControl("MainLoginId").Visible = false;
                Master.FindControl("MainUpdateProfileId").Visible = false;
                Master.FindControl("MainLogoutId").Visible = true;
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
                if (Session["permissionLevel"].Equals("Steering Committee") && temp2.Equals("Yes"))
                {
                    Master.FindControl("MainAddAuctionItemId").Visible = true;
                }
                if (Session["permissionLevel"].Equals("Designer/Donor"))
                {
                    Master.FindControl("MainAddAuctionItemId").Visible = true;
                }
            }

            if (!IsPostBack)
            {
                TextBox1.ReadOnly = true;
                TextBox2.ReadOnly = true;
                TextBox3.ReadOnly = true;
                TextBox4.ReadOnly = true;
                TextBox5.ReadOnly = true;
                TextBox6.ReadOnly = true;
                TextBox7.ReadOnly = true;
                TextBox8.ReadOnly = true;
                TextBox9.ReadOnly = true;
                TextBox10.ReadOnly = true;
                TextBox10.CssClass.Replace("input", "form-control");
                TextBox11.ReadOnly = true;
                TextBox12.ReadOnly = true;

                RadioButton1.Enabled = false;
                RadioButton2.Enabled = false;
                RadioButton3.Enabled = false;
                RadioButton4.Enabled = false;



                TextBox1.CssClass = "input";
                TextBox2.CssClass = "input";
                TextBox3.CssClass = "input";
                TextBox4.CssClass = "input";
                TextBox5.CssClass = "input";
                TextBox6.CssClass = "input";
                TextBox7.CssClass = "input";
                TextBox8.CssClass = "input";
                TextBox9.CssClass = "input";
                //TextBox10.CssClass = "input";
                TextBox11.CssClass = "input";
                TextBox12.CssClass = "input";
                string useremail = Session["email"].ToString();

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
                        TextBox1.Text = record[0].ToString();
                        TextBox2.Text = record[1].ToString();
                        TextBox3.Text = record[2].ToString();
                        TextBox4.Text = record[3].ToString();
                        TextBox5.Text = record[4].ToString();
                        TextBox6.Text = record[5].ToString();
                        TextBox7.Text = record[6].ToString();
                        TextBox8.Text = record[7].ToString();
                        TextBox9.Text = record[8].ToString();
                        TextBox10.Text = record[9].ToString();
                        TextBox11.Text = record[10].ToString();
                        TextBox12.Text = record[11].ToString();
                        String tempImgPath = record[11].ToString();
                        tempImgPath = tempImgPath.Replace('~', '.');
                        String imgOnUi = "<img style = 'height:auto; width:auto;border-radius: 50%;' class='img-responsive' src='" + tempImgPath + "' />";
                        ImgUiDiv.InnerHtml += imgOnUi;
                        if (record[12].ToString() == "Yes")
                        {
                            RadioButton1.Checked = true;

                        }
                        else
                        {
                            RadioButton2.Checked = true;
                        }



                        if (record[13].ToString() == "Yes")
                        {
                            RadioButton3.Checked = true;
                        }

                        else
                        {
                            RadioButton4.Checked = true;
                        }

                    }

                    /* else
                                           {

                                              // Label2.ForeColor = System.Drawing.Color.Red;
                                               //Label2.Text = "Email does not exist in the system!";
                                           }*/

                }
                catch (SqlException ex)
                {
                    Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
                }

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            TextBox1.ReadOnly = false;
            TextBox2.ReadOnly = false;
            TextBox3.ReadOnly = false;
            TextBox4.ReadOnly = false;
            TextBox5.ReadOnly = false;
            TextBox6.ReadOnly = false;
            TextBox7.ReadOnly = false;
            TextBox8.ReadOnly = false;
            TextBox9.ReadOnly = false;
            //TextBox10.ReadOnly = false;
            TextBox11.ReadOnly = false;

            TextBox12.ReadOnly = false;
            RadioButton1.Enabled = true;
            RadioButton2.Enabled = true;
            RadioButton3.Enabled = true;
            RadioButton4.Enabled = true;
            //TextBox1.CssClass = "inputcolored";

            TextBox1.CssClass = TextBox1.CssClass.Replace("input", "form-control");
           
            TextBox2.CssClass = TextBox2.CssClass.Replace("input", "form-control");
            TextBox3.CssClass = TextBox3.CssClass.Replace("input", "form-control");
            TextBox4.CssClass = TextBox4.CssClass.Replace("input", "form-control");
            TextBox5.CssClass = TextBox5.CssClass.Replace("input", "form-control");
            TextBox6.CssClass = TextBox6.CssClass.Replace("input", "form-control");
            TextBox7.CssClass = TextBox7.CssClass.Replace("input", "form-control");
            TextBox8.CssClass = TextBox8.CssClass.Replace("input", "form-control");
            TextBox9.CssClass = TextBox9.CssClass.Replace("input", "form-control");
            TextBox10.CssClass = TextBox10.CssClass.Replace("input", "form-control");
            TextBox11.CssClass = TextBox11.CssClass.Replace("input", "form-control");
            TextBox12.CssClass = TextBox12.CssClass.Replace("input", "form-control");




        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string firstname = TextBox1.Text;
            string lastname = TextBox2.Text;
            string address = TextBox3.Text;
            string city = TextBox4.Text;
            string country = TextBox5.Text;
            string state = TextBox6.Text;
            string zip = TextBox7.Text;
            string homephone = TextBox8.Text;
            string cellphone = TextBox9.Text;
            string email = TextBox10.Text;
            string password = TextBox11.Text;
            string imagepath = TextBox12.Text;
            string enabletextmsg;
            string emailsubs;
            if (RadioButton1.Checked == true)
            {
                enabletextmsg = "Yes";
            }

            else
            {
                enabletextmsg = "No";
            }


            if (RadioButton3.Checked == true)
            {
                emailsubs = "Yes";
            }

            else
            {
                emailsubs = "No";
            }
            // ",email=" + email +
            SqlConnection connection = new SqlConnection("Data Source = itksqlexp8; Integrated Security = true");
            try
            {
                connection.Open();
                connection.ChangeDatabase("itk485nnrs");

                string str = "UPDATE signuptable SET firstname='" + firstname
                        + "',lastname='" + lastname + "',address='" + address + "',city='" + city + "', country='" + country + "', state='" + state +
                        "', zip='" + zip + "',homePhone='" + homephone + "',cellPhone='" + cellphone +
                       "',password='" + password + "',imagePath='" + imagepath +
                    "',enableTextMsg='" + enabletextmsg + "',subscribeEmail='" + emailsubs + "'WHERE email='" + email + "';";

                string sm = "UPDATE signintable SET password='" + password + "'WHERE email='" + email + "';";
                SqlCommand checklogin = new SqlCommand(str, connection);
                SqlCommand updatetable = new SqlCommand(sm, connection);
                checklogin.ExecuteNonQuery();
                updatetable.ExecuteNonQuery();

                Label2.Text = "Your profile has been saved succesfully";
            }

            catch (SqlException ex)
            {
                Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
            }

        }
    }
}