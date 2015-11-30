using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    
    public partial class SearchAucItem : System.Web.UI.Page
    {
        static string reportName = "";
        string alpha;
        string num;


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

            Label1.Visible = false;
            Label15.Visible = false;

        }

        protected void gridfill()
        {

            if (!String.IsNullOrEmpty(TextBox1.Text))
            {

                Regex r = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");

                Match m = r.Match(TextBox1.Text);

                alpha = m.Groups["Alpha"].Value;
                num = m.Groups["Numeric"].Value;

                string st = "SELECT * FROM auctionitemstable WHERE (itemType='" + alpha + "') AND (itemNumber='" + num + "');";


                SqlDataAdapter rd = new SqlDataAdapter(st, connection);
                DataSet ds = new DataSet();


                rd.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();

                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            }

            else
                if (RadioButtonList1.SelectedIndex != -1 && String.IsNullOrEmpty(TextBox1.Text))
            {


                string s = RadioButtonList1.SelectedItem.Text;

                if (s == "Gingerbread" || s == "Jingle Bell Junction")
                {
                    SearchAucItem.reportName = "Gingerbread_Items";
                    string str = "SELECT * FROM auctionitemstable WHERE (category='" + s + "');";
                    SqlDataAdapter rd = new SqlDataAdapter(str, connection);
                    DataSet ds = new DataSet();


                    rd.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                if (s == "Celebrity Place")
                {

                    SearchAucItem.reportName = "Celebrity Place_Items";
                    string str = "SELECT * FROM auctionitemstable WHERE category='Celebrity Place' OR category='Consignment items' OR category='Donated items' OR category='Purchased items' ;";
                    SqlDataAdapter rd = new SqlDataAdapter(str, connection);
                    DataSet ds = new DataSet();


                    rd.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                if (s == "Opening Night")
                {

                    SearchAucItem.reportName = "Opening Night_Items";
                    string str = "SELECT * FROM auctionitemstable WHERE category='Opening Night' OR category='Live Auction' OR category='Other items' OR category='Silent Auction' ;";
                    SqlDataAdapter rd = new SqlDataAdapter(str, connection);
                    DataSet ds = new DataSet();


                    rd.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

                }

                if (s == "Designer Items")
                {

                    SearchAucItem.reportName = "Designer Items_Items";
                    string str = "SELECT * FROM auctionitemstable WHERE category='Designer Items' OR category='Trees supplied by The Baby Fold'  OR category='All other designer items';";

                    SqlDataAdapter rd = new SqlDataAdapter(str, connection);
                    DataSet ds = new DataSet();


                    rd.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

                }

            }


            else
            {
                SearchAucItem.reportName = "Complete List_Items";
                string str = "SELECT * FROM auctionitemstable;";
                SqlDataAdapter rd = new SqlDataAdapter(str, connection);
                DataSet ds = new DataSet();


                rd.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }






        }

        //Button2 clicked
        protected void Button2_Click(object sender, EventArgs e)
        {

            // Case when textbox is empty and radio is not checked
            if (String.IsNullOrEmpty(TextBox1.Text) && RadioButtonList1.SelectedIndex == -1)
            {
                Label1.Visible = true;

                Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-danger fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Input Item Number And/Or select one category </div>";
                GridView1.Visible = false;

            }
            //Case when radio is checked and textbox is empty
            if (RadioButtonList1.SelectedIndex != -1 && String.IsNullOrEmpty(TextBox1.Text))
            {
                try
                {
                    string s = RadioButtonList1.SelectedItem.Text;
                    if (s == "Celebrity Place")
                    {
                        SearchAucItem.reportName = "Celebrity Place_Items";
                        connection.Open();
                        connection.ChangeDatabase("itk485nnrs");

                        string str = "SELECT * FROM auctionitemstable WHERE category='Celebrity Place' OR category='Consignment items' OR category='Donated items' OR category='Purchased items' ;";
                        SqlCommand checklogin = new SqlCommand(str, connection);
                        SqlDataReader record = checklogin.ExecuteReader();

                        if (record.HasRows)
                        {
                            GridView1.Visible = true;

                            GridView1.DataSource = record;
                            GridView1.DataBind();
                            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                            Label15.Visible = false;
                            Label1.Visible = true;
                            Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>Below is the search result. To make changes, click on the Edit button  </div>";

                            // record.Close();


                        }

                        else
                        {
                            GridView1.Visible = false;
                            Label1.Visible = false;
                            Label15.Visible = true;
                            Label15.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                        }

                    }

                    if (s == "Opening Night")
                    {
                        SearchAucItem.reportName = "Opening Night_Items";
                        connection.Open();
                        connection.ChangeDatabase("itk485nnrs");

                        string str = "SELECT * FROM auctionitemstable WHERE category='Opening Night' OR category='Live Auction' OR category='Other items' OR category='Silent Auction' ;";
                        SqlCommand checklogin = new SqlCommand(str, connection);
                        SqlDataReader record = checklogin.ExecuteReader();

                        if (record.HasRows)
                        {
                            GridView1.Visible = true;

                            GridView1.DataSource = record;
                            GridView1.DataBind();
                            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                            Label15.Visible = false;
                            Label1.Visible = true;
                            Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>Below is the search result. To make changes, click on the Edit button  </div>";

                            // record.Close();


                        }

                        else
                        {
                            GridView1.Visible = false;
                            Label1.Visible = false;
                            Label15.Visible = true;
                            Label15.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                        }
                    }

                    if (s == "Designer Items")
                    {
                        SearchAucItem.reportName = "Designer Items_Items";
                        connection.Open();
                        connection.ChangeDatabase("itk485nnrs");

                        string str = "SELECT * FROM auctionitemstable WHERE category='Designer Items' OR category='Trees supplied by The Baby Fold'  OR category='All other designer items';";
                        SqlCommand checklogin = new SqlCommand(str, connection);
                        SqlDataReader record = checklogin.ExecuteReader();

                        if (record.HasRows)
                        {
                            GridView1.Visible = true;

                            GridView1.DataSource = record;
                            GridView1.DataBind();
                            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                            Label15.Visible = false;
                            Label1.Visible = true;
                            Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>Below is the search result. To make changes, click on the Edit button  </div>";

                            // record.Close();


                        }

                        else
                        {
                            GridView1.Visible = false;
                            Label1.Visible = false;
                            Label15.Visible = true;
                            Label15.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                        }
                    }

                    if (s == "Gingerbread" || s == "Jingle Bell Junction")
                    {
                        connection.Open();
                        connection.ChangeDatabase("itk485nnrs");

                        string str = "SELECT * FROM auctionitemstable WHERE (category='" + s + "') ;";
                        SqlCommand checklogin = new SqlCommand(str, connection);
                        SqlDataReader record = checklogin.ExecuteReader();

                        if (record.HasRows)
                        {
                            GridView1.Visible = true;

                            GridView1.DataSource = record;
                            GridView1.DataBind();
                            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                            Label15.Visible = false;
                            Label1.Visible = true;
                            Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>Below is the search result. To make changes, click on the Edit button  </div>";

                            // record.Close();


                        }

                        else
                        {
                            GridView1.Visible = false;
                            Label1.Visible = false;
                            Label15.Visible = true;
                            Label15.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                        }
                    }

                }
                catch (SqlException ex)
                {
                    Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
                }
            }





            //Case when textbox is not empty and radio is not checked
            if (!String.IsNullOrEmpty(TextBox1.Text) && RadioButtonList1.SelectedIndex == -1)
            {
                //string selection = DropDownList2.SelectedItem.Text;

                Regex r = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");

                Match m = r.Match(TextBox1.Text);

                alpha = m.Groups["Alpha"].Value;
                num = m.Groups["Numeric"].Value;
                try
                {
                    connection.Open();
                    connection.ChangeDatabase("itk485nnrs");

                    string str = "SELECT * FROM auctionitemstable WHERE (itemType='" + alpha + "')AND (itemNumber='" + num + "');";
                    SqlCommand checklogin = new SqlCommand(str, connection);
                    SqlDataReader record = checklogin.ExecuteReader();

                    if (record.HasRows)
                    {
                        GridView1.Visible = true;
                        GridView1.DataSource = record;
                        GridView1.DataBind();
                        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                        Label15.Visible = false;
                        Label1.Visible = true;
                        Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>Below is the search result. To make changes, click on the Edit button  </div>";

                        // record.Close();


                    }

                    else
                    {
                        GridView1.Visible = false;
                        Label1.Visible = false;
                        Label15.Visible = true;
                        Label15.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                    }

                }
                catch (SqlException ex)
                {
                    Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
                }

            }

            //Case when string is not empty and radio is checked
            if (!String.IsNullOrEmpty(TextBox1.Text) && RadioButtonList1.SelectedIndex != -1)
            {
                string selection = RadioButtonList1.SelectedItem.Text;

                Regex r = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");

                Match m = r.Match(TextBox1.Text);

                alpha = m.Groups["Alpha"].Value;
                num = m.Groups["Numeric"].Value;
                try
                {
                    connection.Open();
                    connection.ChangeDatabase("itk485nnrs");

                    string str = "SELECT * FROM auctionitemstable WHERE (itemType='" + alpha + "')AND (itemNumber='" + num + "')AND (category='" + selection + "');";
                    SqlCommand checklogin = new SqlCommand(str, connection);
                    SqlDataReader record = checklogin.ExecuteReader();

                    if (record.HasRows)
                    {
                        GridView1.Visible = true;
                        GridView1.DataSource = record;
                        GridView1.DataBind();
                        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                        Label15.Visible = false;
                        Label1.Visible = true;
                        Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>Below is the search result. To make changes, click on the Edit button  </div>";

                        // record.Close();


                    }

                    else
                    {
                        GridView1.Visible = false;
                        Label1.Visible = false;
                        Label15.Visible = true;
                        Label15.Text = @" <div style = 'margin - top:10px' class='form - group alert alert-danger fade in'> <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>No such record found!</div>";
                    }

                }
                catch (SqlException ex)
                {
                    Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
                }

            }





        }


        //Reset button
        protected void Button4_Click(object sender, EventArgs e)
        {
            RadioButtonList1.SelectedIndex = -1;
            TextBox1.Text = String.Empty;
            Label1.Visible = false;
            Label15.Visible = false;
            GridView1.Visible = false;

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.Visible = true;
            //Session.RemoveAll();
            Session["itemType"] = null;
            Session["itemNum"] = null;
            Session["category"] = null;

            string typeofitem = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("Label16")).Text;
            
            Session["itemType"] = typeofitem;

            string numofitem = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("Label3")).Text;
            Session["itemNum"] = numofitem;

            string catofitem = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("Label4")).Text;
            Session["category"] = catofitem;


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
            string itemType = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label12")).Text;
            

            string itemNum = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label13")).Text;

            string categor = ((Label)GridView1.Rows[e.RowIndex].FindControl("Label14")).Text;
            string itemdes = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox5")).Text;
            string designer = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox6")).Text;
            string spprox = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox7")).Text;
            string minbd = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox8")).Text;
            string angelprice = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox9")).Text;
            string itemimagepath = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox10")).Text;
            string purchasprice = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox11")).Text;

            string qu = "UPDATE auctionitemstable SET itemDesc ='" + itemdes + "',designer='" + designer
           + "',estimatedValue='" + spprox + "',minBid='" + minbd + "',angelPrice='" + angelprice + "', itemImagePath='" + itemimagepath +
       "',purchasePrice='" + purchasprice + "'WHERE itemType='" + itemType + "'AND itemNumber='" + itemNum + "';";


            SqlCommand checklogin = new SqlCommand(qu, connection);
            checklogin.ExecuteNonQuery();
            GridView1.EditIndex = -1;


            /* Trial */

            //Case when radio is checked and textbox is empty
            if (RadioButtonList1.SelectedIndex != -1 && String.IsNullOrEmpty(TextBox1.Text))
            {
                string c = Session["category"].ToString();

                if (c == "Celebrity Place" || c == "Consignment items" || c == "Donated items" || c == "Purchased items")
                {

                    string str = "SELECT * FROM auctionitemstable WHERE category='Celebrity Place' OR category='Consignment items' OR category='Donated items' OR category='Purchased items' ;";
                    SqlCommand ch = new SqlCommand(str, connection);
                    SqlDataReader rcrd = ch.ExecuteReader();

                    if (rcrd.HasRows)
                    {
                        GridView1.Visible = true;
                        Label15.Visible = false;
                        Label1.Visible = true;
                        GridView1.DataSource = rcrd;
                        GridView1.DataBind();
                        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                        Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <Strong>Success!</Strong> Changes have been updated successfully. </div>";


                    }

                }
                if (c == "Opening Night" || c == "Live Auction" || c == "Other items" || c == "Silent Auction")
                {


                    string q2 = "SELECT * FROM auctionitemstable WHERE category='Opening Night' OR category='Live Auction' OR category='Other items' OR category='Silent Auction' ;";
                    SqlCommand ch = new SqlCommand(q2, connection);
                    SqlDataReader rcrd = ch.ExecuteReader();

                    if (rcrd.HasRows)
                    {
                        GridView1.Visible = true;
                        Label15.Visible = false;
                        Label1.Visible = true;
                        GridView1.DataSource = rcrd;
                        GridView1.DataBind();
                        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                        Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <Strong>Success!</Strong> Changes have been updated successfully. </div>";


                    }

                }
                if (c == "Designer Items" || c == "Trees supplied by The Baby Fold" || c == "All other designer items")
                {


                    string q3 = "SELECT * FROM auctionitemstable WHERE category='Designer Items' OR category='Trees supplied by The Baby Fold'  OR category='All other designer items';";

                    SqlCommand ch = new SqlCommand(q3, connection);
                    SqlDataReader rcrd = ch.ExecuteReader();

                    if (rcrd.HasRows)
                    {
                        GridView1.Visible = true;
                        Label15.Visible = false;
                        Label1.Visible = true;
                        GridView1.DataSource = rcrd;
                        GridView1.DataBind();
                        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                        Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <Strong>Success!</Strong> Changes have been updated successfully. </div>";


                    }

                }


                if (c == "Gingerbread" || c == "Jingle Bell Junction")
                {
                    string q4 = "SELECT * FROM auctionitemstable WHERE (category='" + c + "');";


                    SqlCommand ch = new SqlCommand(q4, connection);
                    SqlDataReader rcrd = ch.ExecuteReader();

                    if (rcrd.HasRows)
                    {
                        GridView1.Visible = true;
                        Label15.Visible = false;
                        Label1.Visible = true;
                        GridView1.DataSource = rcrd;
                        GridView1.DataBind();
                        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                        Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <Strong>Success!</Strong> Changes have been updated successfully. </div>";


                    }

                }

                /* Original */

                /* string sm = "SELECT * FROM auctionitemstable WHERE (itemType='" + Session["itemType"].ToString() + "') AND(itemNumber='" + Session["itemNum"].ToString() + "');";
             SqlCommand check = new SqlCommand(sm, connection);
             SqlDataReader record = check.ExecuteReader();

             if (record.HasRows)
             {
                 GridView1.Visible = true;
                 Label15.Visible = false;
                 Label1.Visible = true;
                 GridView1.DataSource = record;
                 GridView1.DataBind();
                 GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                 Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <Strong>Success!</Strong> Changes have been updated successfully. </div>";


             }*/




            }

            //Case when textbox is not empty and radio is not checked and both ckeced
            else if ((!String.IsNullOrEmpty(TextBox1.Text) && RadioButtonList1.SelectedIndex != -1) || (!String.IsNullOrEmpty(TextBox1.Text) && RadioButtonList1.SelectedIndex == -1))
            {

                string q5 = "SELECT * FROM auctionitemstable WHERE (itemType='" + Session["itemType"].ToString() + "')AND (itemNumber='" + Session["itemNum"].ToString() + "');";
                SqlCommand ch = new SqlCommand(q5, connection);
                SqlDataReader rcrd = ch.ExecuteReader();

                if (rcrd.HasRows)
                {
                    GridView1.Visible = true;
                    Label15.Visible = false;
                    Label1.Visible = true;
                    GridView1.DataSource = rcrd;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <Strong>Success!</Strong> Changes have been updated successfully. </div>";


                }



            }





            else
            {
                string q6 = "SELECT * FROM auctionitemstable;";
                SqlCommand cmd = new SqlCommand(q6, connection);
                SqlDataReader record = cmd.ExecuteReader();

                if (record.HasRows)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = record;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    Label15.Visible = false;
                    Label1.Visible = true;
                    Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> <Strong>Success!</Strong> Changes have been updated successfully. </div>";
                }
            }

        }
        //All button

        protected void Button1_Click(object sender, EventArgs e)
        {
            //button1WasClicked = true;
            try
            {
                connection.Open();
                connection.ChangeDatabase("itk485nnrs");

                string str = "SELECT * FROM auctionitemstable;";
                SqlCommand checklogin = new SqlCommand(str, connection);
                SqlDataReader record = checklogin.ExecuteReader();

                if (record.HasRows)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = record;
                    GridView1.DataBind();
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    Label15.Visible = false;
                    Label1.Visible = true;
                    Label1.Text = @"<div style='margin - top:10px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>Below is the search result. To make changes, click on the Edit button  </div>";

                }
            }
            catch (SqlException ex)
            {
                Response.Write("Error is " + ex.Number + " and the message is-" + ex.Message);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchMainPage.aspx");
        }

        //Export to excel
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename="+SearchAucItem.reportName+".xls");
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


        //protected void gridfillnew(string type,string typen,string category)
        //{
        //    connection.Open();

        //    string t = type;
        //    string  b = typen;
        //    string cat = category;


        //    string st = "SELECT * FROM auctionitemstable WHERE (itemType='" + t + "') AND (itemNumber='" + b + "')AND (category='" + cat + "');";

        //    SqlCommand checklogin = new SqlCommand(st, connection);
        //    SqlDataReader record = checklogin.ExecuteReader();
        //    //  SqlDataAdapter rm = new SqlDataAdapter(st, connection);
        //    //DataSet dsnew = new DataSet();


        //    // rm.Fill(dsnew);
        //    if (record.Read())
        //    {
        //        Response.Write("yes");
        //    }

        //    else
        //    {
        //        Response.Write("no");
        //    }
        //   // GridView1.DataSource = dsnew;
        //   // GridView1.DataBind();

        //}

    }


}


//string qu = "UPDATE hellotable SET firstname='" + firstname
//            + "',lastname='" + lastname + "',address='" + address + "',city='" + city + "', country='" + country +
//        "',enableTextMsg='" + enabletextmsg + "'WHERE Id='" + id + "';";
//SqlCommand checklogin = new SqlCommand(qu, connection);

//checklogin.ExecuteNonQuery();
//            GridView1.EditIndex = -1;
//            gridfill();