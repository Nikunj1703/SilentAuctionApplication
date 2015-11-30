using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class SearchBuy : System.Web.UI.Page
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
            Button5.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox2.Text) && String.IsNullOrEmpty(TextBox3.Text) && String.IsNullOrEmpty(TextBox4.Text))
            {
                Label1.Visible = true;
                GridView1.Visible = false;
                Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-danger fade in'> <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
You must input Firstname, Lastname and Cellphone number</div>";


            }
            //firstname filled only
            if (!String.IsNullOrEmpty(TextBox2.Text) && String.IsNullOrEmpty(TextBox3.Text) && String.IsNullOrEmpty(TextBox4.Text))
            {
                string firstname = TextBox2.Text;
                connection.Open();
                connection.ChangeDatabase("itk485nnrs");

                string str = "SELECT * FROM signuptable WHERE (firstname='" + firstname + "') ;";
                SqlCommand checklogin = new SqlCommand(str, connection);
                SqlDataReader record = checklogin.ExecuteReader();


                if (record.HasRows)
                {

                    GridView1.Visible = true;
                    Label2.Visible = false;
                    Label1.Visible = true;
                    GridView1.DataSource = record;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

                    Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Below is the search result. To make changes, click on the Edit button. </div>";




                }


                else
                {
                    GridView1.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = true;
                    Label2.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                }
            }
            //firstname lastname filled
            if (!String.IsNullOrEmpty(TextBox2.Text) && !String.IsNullOrEmpty(TextBox3.Text) && String.IsNullOrEmpty(TextBox4.Text))
            {
                string firstname = TextBox2.Text;
                string lastname = TextBox3.Text;
                connection.Open();
                connection.ChangeDatabase("itk485nnrs");

                string str = "SELECT * FROM signuptable WHERE (firstname='" + firstname + "')AND(lastname='" + lastname + "') ;";
                SqlCommand checklogin = new SqlCommand(str, connection);
                SqlDataReader record = checklogin.ExecuteReader();

                if (record.HasRows)
                {
                    GridView1.Visible = true;
                    Label2.Visible = false;
                    Label1.Visible = true;
                    GridView1.DataSource = record;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Below is the search result. To make changes, click on the Edit button. </div>";
                }
                else
                {
                    GridView1.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = true;
                    Label2.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                }
            }
            //all three filled
            if (!String.IsNullOrEmpty(TextBox2.Text) && !String.IsNullOrEmpty(TextBox3.Text) && !String.IsNullOrEmpty(TextBox4.Text))
            {
                string firstname = TextBox2.Text;
                string lastname = TextBox3.Text;
                string cellphone = TextBox4.Text;
                connection.Open();
                connection.ChangeDatabase("itk485nnrs");

                string str = "SELECT * FROM signuptable WHERE (firstname='" + firstname + "')AND(lastname='" + lastname + "')AND(cellPhone='" + cellphone + "') ;";
                SqlCommand checklogin = new SqlCommand(str, connection);
                SqlDataReader record = checklogin.ExecuteReader();

                if (record.HasRows)
                {
                    GridView1.Visible = true;
                    Label2.Visible = false;
                    Label1.Visible = true;
                    GridView1.DataSource = record;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Below is the search result. To make changes, click on the Edit button. </div>";
                }
                else
                {
                    GridView1.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = true;
                    Label2.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                }
            }
            //cell phone and lastname filled
            if (String.IsNullOrEmpty(TextBox2.Text) && !String.IsNullOrEmpty(TextBox3.Text) && !String.IsNullOrEmpty(TextBox4.Text))
            {

                string lastname = TextBox3.Text;
                string cellphone = TextBox4.Text;
                connection.Open();
                connection.ChangeDatabase("itk485nnrs");

                string str = "SELECT * FROM signuptable WHERE (lastname='" + lastname + "')AND(cellPhone='" + cellphone + "') ;";
                SqlCommand checklogin = new SqlCommand(str, connection);
                SqlDataReader record = checklogin.ExecuteReader();

                if (record.HasRows)
                {
                    GridView1.Visible = true;
                    Label2.Visible = false;
                    Label1.Visible = true;
                    GridView1.DataSource = record;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Below is the search result. To make changes, click on the Edit button. </div>";
                }
                else
                {
                    GridView1.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = true;
                    Label2.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                }
            }
            //only cellphone filled
            if (String.IsNullOrEmpty(TextBox2.Text) && String.IsNullOrEmpty(TextBox3.Text) && !String.IsNullOrEmpty(TextBox4.Text))
            {

                string cellphone = TextBox4.Text;
                connection.Open();
                connection.ChangeDatabase("itk485nnrs");

                string str = "SELECT * FROM signuptable WHERE (cellPhone='" + cellphone + "') ;";
                SqlCommand checklogin = new SqlCommand(str, connection);
                SqlDataReader record = checklogin.ExecuteReader();


                if (record.HasRows)
                {
                    GridView1.Visible = true;
                    Label2.Visible = false;
                    Label1.Visible = true;
                    GridView1.DataSource = record;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Below is the search result. To make changes, click on the Edit button. </div>";
                }
                else
                {
                    GridView1.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = true;
                    Label2.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                }
            }
            //only lastname filled
            if (String.IsNullOrEmpty(TextBox2.Text) && !String.IsNullOrEmpty(TextBox3.Text) && String.IsNullOrEmpty(TextBox4.Text))
            {

                string lastname = TextBox3.Text;

                connection.Open();
                connection.ChangeDatabase("itk485nnrs");

                string str = "SELECT * FROM signuptable WHERE (lastname='" + lastname + "') ;";
                SqlCommand checklogin = new SqlCommand(str, connection);
                SqlDataReader record = checklogin.ExecuteReader();

                if (record.HasRows)
                {
                    GridView1.Visible = true;
                    Label2.Visible = false;
                    Label1.Visible = true;
                    GridView1.DataSource = record;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Below is the search result. To make changes, click on the Edit button. </div>";
                }
                else
                {
                    GridView1.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = true;
                    Label2.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                }
            }

            //firstname and cellphone

            if (!String.IsNullOrEmpty(TextBox2.Text) && String.IsNullOrEmpty(TextBox3.Text) && !String.IsNullOrEmpty(TextBox4.Text))
            {

                string firstname = TextBox2.Text;
                string cellphone = TextBox4.Text;
                connection.Open();
                connection.ChangeDatabase("itk485nnrs");

                string str = "SELECT * FROM signuptable WHERE (firstname='" + firstname + "')AND(cellPhone='" + cellphone + "') ;";
                SqlCommand checklogin = new SqlCommand(str, connection);
                SqlDataReader record = checklogin.ExecuteReader();

                if (record.HasRows)
                {
                    GridView1.Visible = true;
                    Label2.Visible = false;
                    Label1.Visible = true;
                    GridView1.DataSource = record;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Below is the search result. To make changes, click on the Edit button. </div>";
                }
                else
                {
                    GridView1.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = true;
                    Label2.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                }
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox2.Text = String.Empty;
            TextBox3.Text = String.Empty;
            TextBox4.Text = String.Empty;
            Label1.Visible = false;
            Label2.Visible = false;
            GridView1.Visible = false;

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.Visible = true;
            //Session.RemoveAll();
            Session["emailbuyer"] = null;
            Session["firstname"] = null;
            Session["cellphone"] = null;
            Session["lastname"] = null;

            string email = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("Label12")).Text;
            Session["emailbuyer"] = email;

            string fname = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("Label3")).Text;
            Session["firstname"] = fname;

            string lname = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("Label4")).Text;
            Session["lastname"] = lname;

            string cell = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("Label11")).Text;
            Session["cellphone"] = cell;

            GridView1.EditIndex = e.NewEditIndex;
            connection.Open();
            connection.ChangeDatabase("itk485nnrs");

            gridfill();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            connection.Open();
            connection.ChangeDatabase("itk485nnrs");

            gridfill();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            connection.Open();
            connection.ChangeDatabase("itk485nnrs");
            string fname = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox6")).Text;
            string lname = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox5")).Text;
            string address = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox7")).Text;
            string city = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox8")).Text;
            string country = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox9")).Text;
            string state = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox10")).Text;
            string zip = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox11")).Text;
            string homephone = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox12")).Text;
            string cellphone = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox13")).Text;
            //string email = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label18")).Text;
            string password = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox15")).Text;
            string imagepath = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox16")).Text;
            string enabletxtmsg = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox17")).Text;
            string subscribeemail = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox18")).Text;
            string permission = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox19")).Text;

            string qu = "UPDATE signuptable SET firstname ='" + fname + "',lastname='" + lname
              + "',address='" + address + "',city='" + city + "',country='" + country + "', state='" + state +
          "',zip='" + zip + "',homePhone='" + homephone +
          "',cellPhone='" + cellphone + "',password='" + password +
          "',imagePath='" + imagepath + "',enableTextMsg='" + enabletxtmsg +
          "',subscribeEmail='" + subscribeemail + "',permission='" + permission + "'WHERE email='" + Session["emailbuyer"].ToString() + "';";


            SqlCommand checklogin = new SqlCommand(qu, connection);
            checklogin.ExecuteNonQuery();
            GridView1.EditIndex = -1;

            // connection.Close();

            string sm = "SELECT * FROM signuptable WHERE (email='" + Session["emailbuyer"].ToString() + "');";
            SqlCommand check = new SqlCommand(sm, connection);
            SqlDataReader record = check.ExecuteReader();

            if (record.HasRows)
            {
                GridView1.Visible = true;
                Label2.Visible = false;
                Label1.Visible = true;
                GridView1.DataSource = record;
                GridView1.DataBind();
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <Strong>Success!</Strong> Changes have been updated successfully. </div>";


            }

        }
        protected void gridfill()
        {

            string str = "SELECT * FROM signuptable WHERE (email='" + Session["emailbuyer"].ToString() + "');";

            SqlDataAdapter rd = new SqlDataAdapter(str, connection);
            DataSet dsnew = new DataSet();


            rd.Fill(dsnew);
            GridView1.DataSource = dsnew;
            GridView1.DataBind();

            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}

            ////firstname lastname filled
            //if (!String.IsNullOrEmpty(TextBox2.Text) && !String.IsNullOrEmpty(TextBox3.Text) && String.IsNullOrEmpty(TextBox4.Text))
            //{
            //    string firstname = Session["firstname"].ToString();
            //    string lastname = Session["lastname"].ToString();


            //    string str = "SELECT * FROM signuptable WHERE (firstname='" + firstname + "')AND(lastname='" + lastname + "') ;";

            //    SqlDataAdapter rd = new SqlDataAdapter(str, connection);
            //    DataSet ds = new DataSet();


            //    rd.Fill(ds);
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();

            //    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}
            ////all filled
            //if (!String.IsNullOrEmpty(TextBox2.Text) && !String.IsNullOrEmpty(TextBox3.Text) && !String.IsNullOrEmpty(TextBox4.Text))
            //{
            //    string firstname = Session["firstname"].ToString();
            //    string lastname = Session["lastname"].ToString();
            //    string cellphone = Session["cellphone"].ToString();


            //    string str = "SELECT * FROM signuptable WHERE (firstname='" + firstname + "')AND(lastname='" + lastname + "')AND(cellPhone='" + cellphone + "') ;";
            //    SqlDataAdapter rd = new SqlDataAdapter(str, connection);
            //    DataSet ds = new DataSet();


            //    rd.Fill(ds);
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();

            //    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //}

            //// cell phone and lastname filled
            //if (String.IsNullOrEmpty(TextBox2.Text) && !String.IsNullOrEmpty(TextBox3.Text) && !String.IsNullOrEmpty(TextBox4.Text))
            //{

            //    string lastname = Session["lastname"].ToString();
            //    string cellphone = Session["cellphone"].ToString();


            //    string str = "SELECT * FROM signuptable WHERE (lastname='" + lastname + "')AND(cellPhone='" + cellphone + "') ;";
            //    SqlDataAdapter rd = new SqlDataAdapter(str, connection);
            //    DataSet ds = new DataSet();


            //    rd.Fill(ds);
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();

            //    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //}

            ////only cellphone filled
            //if (String.IsNullOrEmpty(TextBox2.Text) && String.IsNullOrEmpty(TextBox3.Text) && !String.IsNullOrEmpty(TextBox4.Text))
            //{

            //    string cellphone = Session["cellphone"].ToString();


            //    string str = "SELECT * FROM signuptable WHERE (cellPhone='" + cellphone + "') ;";
            //    SqlDataAdapter rd = new SqlDataAdapter(str, connection);
            //    DataSet ds = new DataSet();


            //    rd.Fill(ds);
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();

            //    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //}

            ////firstname and cellphone

            //if (!String.IsNullOrEmpty(TextBox2.Text) && String.IsNullOrEmpty(TextBox3.Text) && !String.IsNullOrEmpty(TextBox4.Text))
            //{

            //    string firstname = Session["firstname"].ToString();
            //    string cellphone = Session["cellphone"].ToString();


            //    string str = "SELECT * FROM signuptable WHERE (firstname='" + firstname + "')AND(cellPhone='" + cellphone + "') ;";

            //    SqlDataAdapter rd = new SqlDataAdapter(str, connection);
            //    DataSet ds = new DataSet();


            //    rd.Fill(ds);
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();

            //    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //}

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            connection.ChangeDatabase("itk485nnrs");

            string str = "SELECT * FROM signuptable ;";
            SqlCommand checklogin = new SqlCommand(str, connection);
            SqlDataReader record = checklogin.ExecuteReader();

            if (record.HasRows)
            {
                GridView1.Visible = true;
                Label2.Visible = false;
                Label1.Visible = true;
                GridView1.DataSource = record;
                GridView1.DataBind();
                Button5.Visible = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Below is the search result. To make changes, click on the Edit button. </div>";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchMainPage.aspx");
        }
        //Export to excel
        protected void Button5_Click(object sender, EventArgs e)
        {
            GridView1.Columns[15].Visible = false;
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Buyers.xls");
            Response.ContentType = "application/excel";

            StringWriter stringwriter = new StringWriter();
            HtmlTextWriter htmltextwriter = new HtmlTextWriter(stringwriter);
            //Content of this grid view will be written in this object
            GridView1.RenderControl(htmltextwriter);
            Response.Write(stringwriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
    }

}