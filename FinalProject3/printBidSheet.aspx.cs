using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class printBidSheet : System.Web.UI.Page
    {
        DataTable dTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            string itemNumberFull = Request.QueryString["itemNum"];
            // Response.AddHeader("Content-Type", "application/pdf");
            string connectionString = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;"
                                    + "Integrated Security=true";
            string queryString = "SELECT * from dbo.TempBidder tBidder where itemId = '" + itemNumberFull + "'";


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
                    dTable.Columns.AddRange(new DataColumn[3] {
                            new DataColumn("Name",typeof(string)),
                            new DataColumn("PhoneNumber",typeof(string)),
                            new DataColumn("BidAmount",typeof(string))
                    });
                    dTable.Rows.Add("Name", "Phone Number", "Bid Amount");
                    dTable.Rows.Add(" ", " ", " ");
                    dTable.Rows.Add("  ", " ", " ");
                    dTable.Rows.Add(" ", "  ", " ");
                    //int i = 15;
                    //while (i>0)
                    //{
                    //    dTable.Rows.Add("","","","");
                    //    i--;
                    //}
                    reader.Close();
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
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
                            sb.Append("<div style='color:red'><p style='text-align:center'>Festival of Trees - Bid Sheet</p><br/>");
                            sb.Append("<p style='text-align:center'>"+Request.QueryString["sponsor"].ToString()+"</p></div>");
                            sb.Append("</th>");
                            sb.Append("<th>");
                            sb.Append("");
                            sb.Append("</th>");

                            sb.Append("</tr>");



                            sb.Append("<tr>");
                            sb.Append("<td>");
                            sb.Append("Category: " + Request.QueryString["category"]);
                            sb.Append("</td>");

                            sb.Append("<td>");
                            sb.Append("Minimum Bid: " + Request.QueryString["minBidAmount"]);
                            sb.Append("</td>");

                            sb.Append("<td>");
                            sb.Append("Item Number: " + itemNumberFull);
                            sb.Append("</td>");

                            sb.Append("</tr>");
                            sb.Append("</table>");

                            sb.Append("<table border='1'");
                            //sb.Append("<tr>");
                            //foreach(DataColumn column in dTable.Columns)
                            //{
                            //    //sb.Append("<th style='background-color:#D20B0C; color:#ffffff'>");
                            //    //sb.Append(column.ColumnName);
                            //    //sb.Append("</th>");
                            //}
                            //sb.Append("</tr>");
                            int i = 10;
                            while (i>0)
                            {
                                sb.Append("<tr>");
                                int j = 1;
                                foreach (DataColumn column in dTable.Columns)
                                {
                                    
                                    if(i == 10)
                                    {
                                        
                                        if(j == 1)
                                        {
                                            sb.Append("<td>Name</td>");
                                            
                                        }
                                        if(j == 2)
                                        {
                                            sb.Append("<td>Phone Number</td>");
                                            
                                        }
                                        if(j == 3)
                                        {
                                            sb.Append("<td>Bid Amount</td>");
                                            
                                        }
                                        j++;

                                    }
                                    else
                                    {
                                        sb.Append("<td>___________</td>");
                                    }

                                }
                                sb.Append("</tr>");
                                i--;
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