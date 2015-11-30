using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class auctionItemDetails : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
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

            if (Request.QueryString["itemNum"] == null)
            {
                Response.Redirect("BiddingHomeScreen.aspx");
            }
            string fullItemNumber = Request.QueryString["itemNum"];
            string itemNum = Regex.Match(fullItemNumber, @"\d+").Value;
            string itemType = Regex.Match(fullItemNumber, @"\D+").Value;
            //Response.Write("itemNum: " + itemNum + " itemType: " + itemType);
            //Now, start coding here to extract data from db based on itemNum and itemType.


            string connectionString = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;"
                                    + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * from dbo.auctionitemstable where itemType = '"+itemType+"' and itemNumber = "+itemNum;



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
                       
                        string htmlForImages = String.Empty;
                        string tempImgPath = Convert.ToString(reader["itemImagePath"]);
                        tempImgPath = tempImgPath.Substring(2);
                        string tempItemNum = Convert.ToString(reader["itemType"]) + Convert.ToString(reader["itemNumber"]);
                        htmlForImages = "<img class='img-responsive' data-imagezoom='true' src='" + tempImgPath + "' />";
                        ImagesDiv.InnerHtml = htmlForImages;
                        string categoryName = Convert.ToString(reader["category"]);
                        string itemDesc = Convert.ToString(reader["itemDesc"]);
                        string minBid = Convert.ToString(reader["minBid"]);
                        if(minBid.Equals("Committee determines minimum bid"))
                        {
                            minBid = "To be determined";
                        }
                        string designer = Convert.ToString(reader["designer"]);
                        Label1.Text = fullItemNumber;
                        Label2.Text = categoryName;
                        Label3.Text = itemDesc;
                        Label4.Text = designer;
                        Label5.Text = minBid;
                        Session["bidCategory"] = categoryName;
                        Session["itemNumber"] = fullItemNumber;
                        Session["minBid"] = minBid;
                    }
                    else
                    {
                        Response.Write("Some error");
                    }


                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }






            connectionString = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;"
                                    + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            queryString = "SELECT MAX(bidAmount) as maxBid from dbo.TempBidder where itemId = '" + fullItemNumber+"'";



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

                        Label6.Text = Convert.ToString(reader["maxBid"]);

                    }
                    else
                    {
                        Response.Write("Some error");
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