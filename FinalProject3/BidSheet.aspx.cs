using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


namespace FinalProject3
{
    public partial class BidSheet : System.Web.UI.Page
    {
        DataTable dTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            
                Master.FindControl("MainSignUpId").Visible = false;
                Master.FindControl("MainLoginId").Visible = false;
                Master.FindControl("MainUpdateProfileId").Visible = false;
                Master.FindControl("MainLogoutId").Visible = false;
                Master.FindControl("MainSearchId").Visible = false;
                Master.FindControl("MainDissmissId").Visible = true;
            
          
            // if (!IsPostBack)
            // {

            //Checking if user is already signed in the system then in bidsheet we will
            //pre-populate his name and phone number
            //Session["loginEmail"] = "nikunj.ratnaparkhi@gmail.com"; //Just for testing
            if (Session["loginEmail"] != null)
                {
                    string email = Convert.ToString(Session["loginEmail"]);


                    string connectionString2 = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;"
                                   + "Integrated Security=true";
                    // Provide the query string with a parameter placeholder.
                    string queryString2 = "SELECT * from dbo.signuptable where email = '" + email + "'";



                    using (SqlConnection connection = new SqlConnection(connectionString2))
                    {
                        // Create the Command and Parameter objects.
                        SqlCommand command = new SqlCommand(queryString2, connection);


                        // Open the connection in a try/catch block.
                        // Create and execute the DataReader, writing the result
                        // set to the console window.
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {

                                TextBox1.Text = Convert.ToString(reader["firstName"]);
                                TextBox2.Text = Convert.ToString(reader["cellPhone"]);
                            }



                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }


                }//if Session["loginEmail"] closes


                string SubCategory = Convert.ToString(Session["bidCategory"]);

                if(SubCategory.Equals("Consignment items") ||
                    SubCategory.Equals("Donated items") ||
                    SubCategory.Equals("Purchased items"))
                {
                    Label1.Text = "Sponsor: Celebrity Place";
                    bidSheetPanelId.Attributes.Add("style", "background-color:#589D3E");
                }
               
                if(SubCategory.Equals("Gingerbread"))
                {
                    Label1.Text = "Sponsor: Gingerbread";
                    bidSheetPanelId.Attributes.Add("style", "background-color:#EF5F21");
                }


                if (SubCategory.Equals("Jingle Bell Junction"))
                {
                    Label1.Text = "Sponsor: Jingle Bell Junction";
                    bidSheetPanelId.Attributes.Add("style", "background-color:#00ACED");
                }

                if (SubCategory.Contains("Birthday Parties") ||
                    SubCategory.Contains("Other items") ||
                    SubCategory.Equals("Silent Auction"))
                {
                    Label1.Text = "Sponsor: Opening Night";
                    bidSheetPanelId.Attributes.Add("style", "background-color:#D61F85");
                }

                if (SubCategory.Contains("Trees supplied") ||
                   SubCategory.Contains("All other designer"))
                {
                    Label1.Text = "Sponsor: Designer Items";
                    bidSheetPanelId.Attributes.Add("style", "background-color:#F89F1B");
                }

                Label2.Text = SubCategory;
                Label3.Text = Convert.ToString(Session["itemNumber"]);
                Label4.Text = Convert.ToString(Session["minBid"]);
                minBidTD.InnerText = Convert.ToString(Session["minBid"]);
                string itemNumberFull = Convert.ToString(Session["itemNumber"]);
                string connectionString = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;"
                                    + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            //string queryString = "SELECT * from dbo.TempBidder tBidder, dbo.signuptable sTable where itemId = '" + itemNumberFull + "' and tBidder.email = sTable.email ORDER BY tBidder.bidAmount";
            string queryString = "SELECT * from dbo.TempBidder tBidder where itemId = '" + itemNumberFull + "' ORDER BY tBidder.bidAmount";


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
                        while (reader.Read())
                        {

                            string htmlForDataTable = String.Empty;
                            htmlForDataTable = "<tr><td>" + reader["bidId"] + "</td><td>" + reader["name"] +"</td><td>" + reader["phoneNum"] + "</td><td>" + reader["bidAmount"] + "</td></tr>";
                            dataTableId.InnerHtml += htmlForDataTable;
                        }
                        


                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                //Session.Remove("bidCategory");
                //Session.Remove("itemNumber");
                //Session.Remove("minBid");
            //}
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string bidderName = TextBox1.Text;
            string bidderPhone = TextBox2.Text;
            string bidAmount = TextBox3.Text;

            dataTableId.InnerHtml = String.Empty;
            //Insert/update value in the table
            SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
            dbConnection.Open();
            dbConnection.ChangeDatabase("itk485nnrs");
            
            string email = "";
            if (Session["loginEmail"] != null)
            {
                email = Convert.ToString(Session["loginEmail"]);
            }
            string fullItemId = Convert.ToString(Session["itemNumber"]);
            string winningStatus = "Under Process";
            string paymentStatus = "Not Paid";

            string insertBidder = "INSERT INTO dbo.TempBidder VALUES('"
                            + email + "', '"
                            + fullItemId + "', '"
                            + winningStatus + "', '"
                            + paymentStatus + "', '"
                            + bidAmount + "', '"
                            + bidderPhone + "', '"
                            + bidderName + "')";

            try
            {
                SqlCommand sqlCommand = new SqlCommand(insertBidder, dbConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
            dbConnection.Close();


            //Fetching all data again
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;"
                                    + "Integrated Security=true";
            string queryString = "SELECT * from dbo.TempBidder tBidder where itemId = '" + fullItemId + "' ORDER BY tBidder.bidAmount";


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
                    while (reader.Read())
                    {

                        string htmlForDataTable = String.Empty;
                        htmlForDataTable = "<tr><td>" + reader["bidId"] + "</td><td>" + reader["name"] + "</td><td>" + reader["phoneNum"] + "</td><td>" + reader["bidAmount"] + "</td></tr>";
                        dataTableId.InnerHtml += htmlForDataTable;
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
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

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            string itemNumberFull = Convert.ToString(Session["itemNumber"]);
            // Response.AddHeader("Content-Type", "application/pdf");
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;"
                                    + "Integrated Security=true";
            string queryString = "SELECT * from dbo.TempBidder tBidder where itemId = '" + itemNumberFull + "' ORDER BY tBidder.bidAmount";


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
                    dTable.Columns.AddRange(new DataColumn[4] {
                            new DataColumn("BidId",typeof(string)),
                            new DataColumn("Name",typeof(string)),
                            new DataColumn("PhoneNumber",typeof(string)),
                            new DataColumn("BidAmount",typeof(string))
                    });
                    dTable.Rows.Add("Bid Id", "Name", "Phone Number", "Bid Amount");
                    
                    while (reader.Read())
                    {
                       dTable.Rows.Add(reader["bidId"], reader["name"], reader["phoneNum"], reader["bidAmount"]);
                    }
                    reader.Close();
                    using (StringWriter sw = new StringWriter())
                        {
                            using(HtmlTextWriter hw = new HtmlTextWriter(sw))
                            {
                                StringBuilder sb = new StringBuilder();
                                //sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                                //sb.Append("<tr><td align='center' style='background-color:#18B5F0' colspan='2'><b>BidId</b></td></tr>");
                                //sb.Append("<tr><td align='center' style='background-color:#18B5F0' colspan='2'><b>Name</b></td></tr>");
                                //sb.Append("<tr><td align='center' style='background-color:#18B5F0' colspan='2'><b>Phone Number</b></td></tr>");
                                //sb.Append("<tr><td align='center' style='background-color:#18B5F0' colspan='2'><b>Bid Amount</b></td></tr>");
                                //sb.Append("</table>");
                            //Generate table
                            sb.Append("<table>");
                            sb.Append("<tr>");

                            sb.Append("<th>");
                            sb.Append("");
                            sb.Append("</th>");

                            sb.Append("<th style='background-color:#00ff00'>");
                                sb.Append("<div style='color:red'><p>Festival of Trees - Bid Sheet</p></div>");
                            sb.Append("</th>");
                            sb.Append("<th>");
                            sb.Append("");
                            sb.Append("</th>");

                            sb.Append("</tr>");

                           

                            sb.Append("<tr>");
                            sb.Append("<td>");
                                sb.Append("Category: " + Convert.ToString(Session["bidCategory"]));
                            sb.Append("</td>");

                            sb.Append("<td>");
                                sb.Append("Minimum Bid: " + Convert.ToString(Session["minBid"]));
                            sb.Append("</td>");

                            sb.Append("<td>");
                                sb.Append("Item Number: " + itemNumberFull);
                            sb.Append("</td>");

                            sb.Append("</tr>");
                            sb.Append("</table>");

                            sb.Append("<table border='1'>");
                            //sb.Append("<tr>");
                            //foreach(DataColumn column in dTable.Columns)
                            //{
                            //    //sb.Append("<th style='background-color:#D20B0C; color:#ffffff'>");
                            //    //sb.Append(column.ColumnName);
                            //    //sb.Append("</th>");
                            //}
                            //sb.Append("</tr>");
                            foreach (DataRow row in dTable.Rows)
                            {
                                sb.Append("<tr>");
                                foreach(DataColumn column in dTable.Columns)
                                {
                                    sb.Append("<td>");
                                    sb.Append(row[column]);
                                    sb.Append("</td>");
                                }
                                sb.Append("</tr>");
                            }
                            sb.Append("</table>");


                            //Exporting to pdf
                            StringReader sr = new StringReader(sb.ToString());
                            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                            pdfDoc.Open();
                            htmlparser.Parse(sr);
                            pdfDoc.Close();
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=BidSheet_" + itemNumberFull + ".pdf");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.Write(pdfDoc);
                            Response.End();
                        }
                        }
                    



                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
   }
}