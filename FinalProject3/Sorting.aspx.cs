using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace FinalProject3
{
    public partial class Sorting : System.Web.UI.Page
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


            // mydiv.Visible = false;

            string rowcount;


            connection.Open();
            connection.ChangeDatabase("itk485nnrs");

            string st = "Select count(*) FROM TempBidder;";
            SqlCommand check = new SqlCommand(st, connection);

            SqlDataReader re = check.ExecuteReader();

            if (re.Read())
            {
                rowcount = re[0].ToString();
                Session["rowcount"] = rowcount;
                //Printing number of rows in the table
                // Response.Write(rowcount);
            }


            re.Close();

            int countofrows = Convert.ToInt32(Session["rowcount"].ToString());

            string str = "SELECT t.bidId,t.name,t.email,t.phoneNum,t.itemId,t.bidAmount,paymentstatus,winningStatus FROM TempBidder t WHERE winningStatus='winner' ORDER BY LEFT(t.itemId, PATINDEX('%[0-9]%',t.itemId)-1), CONVERT(INT, SUBSTRING(t.itemId, PATINDEX('%[0-9]%', t.itemId), LEN(t.itemId))),t.bidAmount ASC;";

            //When anonymousbidder table is considered add this to the above query
            //UNION SELECT t.bidId,a.firstname,a.lastname,t.phoneNum,t.itemId,t.bidAmount,paymentstatus,winningStatus FROM TempBidder t,anonymousbiddertable a WHERE t.phoneNum=a.cellPhone

            SqlCommand checklogin = new SqlCommand(str, connection);



            SqlDataReader record = checklogin.ExecuteReader();

            for (int i = 0; i < countofrows; i++)
            {
                if (record.Read())
                {

                    Session["rowindex"] = i;
                    // Response.Write(Session["rowindex"].ToString());

                    HtmlTableRow row = new HtmlTableRow();

                    HtmlTableCell cell1 = new HtmlTableCell();
                    cell1.InnerHtml = record[0].ToString();
                    cell1.Align = "center";
                    
                    row.Cells.Add(cell1);

                    Session["bidId" + i] = record[0].ToString();



                    //name
                    HtmlTableCell cell2 = new HtmlTableCell();
                    cell2.InnerHtml = record[1].ToString();
                    cell2.Align = "center";
                    row.Cells.Add(cell2);

                    //email
                   


                    TextBox textboxemail = new TextBox();
                   textboxemail.ReadOnly = true;
                    textboxemail.ID = "textboxemail" + i;
                    textboxemail.Text = record[2].ToString();
                    Session["emailtosend"] = textboxemail.Text;
                   textboxemail.EnableViewState = true;
                    textboxemail.CssClass = "input";
                    HtmlTableCell cell3 = new HtmlTableCell();
                    textboxemail.Visible = true;
                    cell3.Controls.Add(textboxemail);
                    cell3.Align = "center";
                    row.Cells.Add(cell3);

                    //cellphone
                    HtmlTableCell cell4 = new HtmlTableCell();
                    cell4.InnerHtml = record[3].ToString();
                    cell4.Align = "center";
                    Session["phonenum" + i] = record[3].ToString();
                    row.Cells.Add(cell4);

                    //Item ID
                    HtmlTableCell cell5 = new HtmlTableCell();
                    cell5.InnerHtml = record[4].ToString();
                    cell5.Align = "center";
                    row.Cells.Add(cell5);



                    //Bid Amount
                    HtmlTableCell cell6 = new HtmlTableCell();
                    cell6.InnerHtml = record[5].ToString();
                    cell6.Align = "center";
                    row.Cells.Add(cell6);


                    //payment status using checkbox
                    CheckBox ch = new CheckBox();
                    ch.Visible = true;
                    ch.ID = "check" + i;
                    ch.EnableViewState = true;
                    if (record[6].ToString() == "paid")
                    {
                        ch.Checked = true;
                    }

                    else
                    {
                        ch.Checked = false;

                    }
                    ch.Enabled = false;

                    HtmlTableCell cell7 = new HtmlTableCell();
                    cell7.Controls.Add(ch);
                    cell7.Align = "center";
                    row.Cells.Add(cell7);

                    //winning status
                    TextBox textbox = new TextBox();
                    textbox.ReadOnly = true;
                    textbox.ID = "textbox" + i;
                    textbox.Text = record[7].ToString();
                    textbox.EnableViewState = true;
                    textbox.CssClass = "input";
                    HtmlTableCell cell8 = new HtmlTableCell();

                    cell8.Controls.Add(textbox);
                    cell8.Align = "center";
                    row.Cells.Add(cell8);


                    //Send message
                    
                    //Edit Update
                    Button btnedit = new Button();
                    btnedit.Text = "Edit";

                    btnedit.ID = "btn" + i;
                    btnedit.CssClass = "btn btn-default ";
                    btnedit.Click += new EventHandler(Btn1_Click);



                    Button btnupdate = new Button();
                    btnupdate.Text = "Update";
                    btnupdate.ID = "btnu" + i;
                    btnupdate.CssClass = "btn btn-default";
                    btnupdate.Click += new EventHandler(BtnupdateClickEvent);
                    HtmlTableCell cell9 = new HtmlTableCell();
                    
                    cell9.Controls.Add(btnedit);
                    cell9.Controls.Add(btnupdate);

                    row.Cells.Add(cell9);



                    example.Rows.Add(row);


                }

            }

            record.Close();

        }

        //Update button 
        private void BtnupdateClickEvent(object sender, EventArgs e)
        {
            mydiv.Visible = true;
            Button button = sender as Button;
            if (button != null)
            {
                string i = button.ID;
                string newstr = i.Substring(4);
                int k = Convert.ToInt32(newstr);

                //connection.ChangeDatabase("itk485nnrs");

                TextBox tb = (TextBox)mydiv.FindControl("textbox" + newstr);
                string newtxt = tb.Text;
                tb.CssClass = tb.CssClass.Replace("form-control", "input");

                TextBox tbemail = (TextBox)mydiv.FindControl("textboxemail" + newstr);
                string newtxtnew = tbemail.Text;
                tbemail.CssClass = tbemail.CssClass.Replace("form-control", "input");



                CheckBox cb = (CheckBox)mydiv.FindControl("check" + newstr);
                if (cb.Checked)
                {
                    string st = "Update TempBidder SET winningStatus ='" + newtxt + "',paymentStatus= 'paid',email = '" + newtxtnew + "' WHERE bidId='" + Session["bidId" + k].ToString() + "';";
                    SqlCommand checkagain = new SqlCommand(st, connection);

                    checkagain.ExecuteNonQuery();

                    tb.ReadOnly = true;
                    cb.Checked = true;
                    cb.Enabled = false;

                    Label1.Text = @"<div style='margin-top:20px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Row has been updated! </div>";
                }

                else
                {
                    string st = "Update TempBidder SET winningStatus ='" + newtxt + "',paymentStatus= 'Not Paid',email = '"+newtxtnew+"' WHERE bidId='" + Session["bidId" + k].ToString() + "';";
                    SqlCommand checkagain = new SqlCommand(st, connection);

                    checkagain.ExecuteNonQuery();

                    tb.ReadOnly = true;
                    cb.Checked = false;
                    cb.Enabled = false;

                    Label1.Text = @"<div style='margin-top:20px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Row has been updated!  </div>";
                }





            }


        }

        //Edit button

        private void Btn1_Click(object sender, EventArgs e)
        {
            mydiv.Visible = true;

            Button button = sender as Button;
            if (button != null)
            {
                string i = button.ID;
                // Response.Write(i);
                int p = i.IndexOf("n");
                string newstr = i.Substring(3);
                // Response.Write(newstr);
                // TextBox tb = (TextBox)Page.FindControl("textbox"+newstr);
                TextBox tb = (TextBox)mydiv.FindControl("textbox" + newstr);
                tb.ReadOnly = true;
                //tb.CssClass = tb.CssClass.Replace("input", "form-control");


                CheckBox cb = (CheckBox)mydiv.FindControl("check" + newstr);
                cb.Enabled = true;


                TextBox tbemail = (TextBox)mydiv.FindControl("textboxemail" + newstr);
                Session["emailtosend"] = tbemail.Text;
                tbemail.ReadOnly = false;   
                tbemail.CssClass = tbemail.CssClass.Replace("input", "form-control");
            }



            //string i= Session["rowindex"].ToString();




        }

        //sending sms
        private void button_Click(object sender, EventArgs e)
        {
            mydiv.Visible = true;
            Button button = sender as Button;
            if (button != null)
            {
                string i = button.ID;
                // Response.Write(i);
                //int p = i.IndexOf("b");
                string newstr = i.Substring(1);

                ServiceReference1.SUSMSClient s = new ServiceReference1.SUSMSClient();

                string[] st = new string[200];
                st = s.getCarriers();

                if (Session["phonenum" + newstr] != null)
                {
                    //Response.Write(Session["phonenum" + newstr].ToString());

                    string phonenum = "1" + Session["phonenum" + newstr].ToString();
                    TextBox tbemail = (TextBox)mydiv.FindControl("textboxemail" + newstr);
                    string newtxtnew = tbemail.Text;
                    Session["emailtosend"] = newtxtnew;
                    string message = "You have won the bid";
                    string add = s.sendSMS("t-mobile", phonenum, message);

                    Label1.Text = @"<div style='margin-top:20px' class='form - group alert alert-success fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> Message sent! </div>";

                    //Response.Write(add);

                    // Response.Write(addew);


                }

            }
           

           

           



        }

       
    }
}