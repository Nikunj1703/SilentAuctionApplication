using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class GenerateReports : System.Web.UI.Page
    {
        static string reportName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginEmail"] != null)
            {
                Master.FindControl("MainSignUpId").Visible = false;
                Master.FindControl("MainLoginId").Visible = false;
                Master.FindControl("MainUpdateProfileId").Visible = true;
                Master.FindControl("MainLogoutId").Visible = true;
            }
            else
            {
                Master.FindControl("MainSignUpId").Visible = true;
                Master.FindControl("MainLoginId").Visible = true;
                Master.FindControl("MainUpdateProfileId").Visible = false;
                Master.FindControl("MainLogoutId").Visible = false;
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
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;"
                                   + "Integrated Security=true";
            string queryString = "";
            bool flag = true;
            if (RadioButtonList1.SelectedValue.Equals("Paid Items"))
            {
                GenerateReports.reportName = "Paid Items";
                flag = false;
                dataTableData.InnerHtml = "";
                nameId.Visible = true;
                phoneId.Visible = true;
                winStat.Visible = true;
                paymentStat.Visible = true;
               //sql to fetch paid items;
               queryString = "SELECT t.itemId,a.category, a.itemDesc, a.designer, a.minBid,a.estimatedValue,t.name, t.phoneNum,t.winningStatus, t.paymentStatus from dbo.TempBidder t, dbo.auctionitemstable a where t.itemId = CONVERT(varchar, a.itemType+CONVERT(varchar,a.itemNumber)) and t.paymentStatus ='Paid' ";
            }else if (RadioButtonList1.SelectedValue.Equals("Unpaid Items"))
            {
                GenerateReports.reportName = "Unpaid Items";
                flag = false;
                nameId.Visible = true;
                phoneId.Visible = true;
                winStat.Visible = true;
                paymentStat.Visible = true;
                dataTableData.InnerHtml = "";
                //sql to fetch unpaid items;
                queryString = "SELECT t.itemId,a.category, a.itemDesc, a.designer, a.minBid,a.estimatedValue,t.name, t.phoneNum,t.winningStatus, t.paymentStatus from dbo.TempBidder t, dbo.auctionitemstable a where t.itemId = CONVERT(varchar, a.itemType+CONVERT(varchar,a.itemNumber)) and t.paymentStatus ='Not Paid' ";
            }
            else if (RadioButtonList1.SelectedValue.Equals("Items with No Bid"))
            {
                GenerateReports.reportName = "Items with No Bid";
                nameId.Visible = false;
                phoneId.Visible = false;
                winStat.Visible = false;
                paymentStat.Visible = false;
                dataTableData.InnerHtml = "";
                //sql to fetch unpaid items;
                queryString = "SELECT * from dbo.auctionitemstable a where a.itemType+CONVERT(varchar,a.itemNumber) NOT IN (Select t.itemId from dbo.TempBidder t) ";
            }


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);


                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Label1.Visible = false;
                        dataTableHeader.Visible = true;
                        dataTableData.Visible = true;
                        Button5.Visible = true;
                        do
                        {
                            string htmlForDataTable = String.Empty;
                            if(!flag)
                                htmlForDataTable = "<tr><td>" + reader[0] + "</td><td>" + reader[1] + "</td><td>" + reader[2] + "</td><td>" + reader[3] + "</td><td>" + reader[4] + "</td><td>" + reader[5] + "</td><td>" + reader[6] + "</td><td>" + reader[7] + "</td><td>" + reader[8] + "</td><td>" + reader[9] + "</td></tr>";
                            else
                                htmlForDataTable = "<tr><td>" + reader[0]+ reader[1] + "</td><td>" + reader[2] + "</td><td>" + reader[3] + "</td><td>" + reader[4] + "</td><td>" + reader[6] + "</td><td>" + reader[5] + "</td></tr>";
                            dataTableData.InnerHtml += htmlForDataTable;
                        }while (reader.Read()) ;
                    }
                    else
                    {
                        Label1.Visible = true;
                        dataTableHeader.Visible = false;
                        Label1.Text = @"<div style='margin-top:20px' class='form - group alert alert-danger fade in'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a> No Record found! </div>";
                    }



                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
           
            Response.AppendHeader("content-disposition", "attachment; filename="+ GenerateReports.reportName+".xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/excel";
            this.EnableViewState = false;
           
            StringWriter stringwriter = new StringWriter();
            HtmlTextWriter htmltextwriter = new HtmlTextWriter(stringwriter);
            //Content of this grid view will be written in this object
            //dataTableData.RenderControl(htmltextwriter);
           
            TableMainDiv.RenderControl(htmltextwriter);
            string str = stringwriter.GetStringBuilder().ToString();
            
            Response.Write(str);
            
            Response.End();
        }
    }
}