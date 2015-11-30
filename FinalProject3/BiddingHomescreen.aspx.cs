using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject3
{
    public partial class BiddingHomescreen : System.Web.UI.Page
    {
        
        protected void LookUpForAdminAccess()
        {
            string adminAccess = "";

            try
            {
                SqlConnection connection = new SqlConnection("Data Source = itksqlexp8; Integrated Security = true");
                connection.Open();
                connection.ChangeDatabase("itk485nnrs");
                string tempEmail = Session["loginEmail"].ToString() ;
                string query =
                            "Select access from signuptable where email = '" + tempEmail + "'";
                SqlCommand command = new SqlCommand(query, connection);
               

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    adminAccess = reader["access"] + "";
                    connection.Close();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Some error occured: " + ex.Message);
            }
            Session["adminAccess"] = adminAccess;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loginEmail"] != null)
            {
                Master.FindControl("MainSignUpId").Visible = false;
                Master.FindControl("MainLoginId").Visible = false;
                Master.FindControl("MainUpdateProfileId").Visible = true;
                Master.FindControl("MainLogoutId").Visible = true;

                Label l1 = (Label)Master.FindControl("LoggedInNameId");
                l1.Text = Session["LoggedInNameId"].ToString();

                //From here
                LookUpForAdminAccess();
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
            else
            {
                Master.FindControl("MainSignUpId").Visible = true;
                Master.FindControl("MainLoginId").Visible = true;
                Master.FindControl("MainUpdateProfileId").Visible = false;
                Master.FindControl("MainLogoutId").Visible = false;
            }

            string connectionString = "Data Source=itksqlexp8;Initial Catalog=itk485nnrs;"
                                     + "Integrated Security=true";
            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT * from dbo.auctionitemstable";



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
                        int i = 1;
                        string htmlForImages = String.Empty;
                        do
                        {

                            string tempImgPath = Convert.ToString(reader["itemImagePath"]);
                            tempImgPath = tempImgPath.Substring(2);
                            string tempItemNum = Convert.ToString(reader["itemType"]) + Convert.ToString(reader["itemNumber"]);
                            string tempCategory = Convert.ToString(reader["category"]);
                            string tempMinBidAmt = Convert.ToString(reader["minBid"]);
                            string tempSponsor = Convert.ToString(reader["designer"]);
                            //htmlForImages = "<li><a href='auctionItemDetails.aspx'><img style='height:300px; width:300px' class='img-responsive' src='" + tempImgPath + "' /></a><div style='height:200px' class='special-info grid_1 simpleCart_shelfItem'><h5>" + Convert.ToString(reader["category"]) + "</h5><h5>Item Number:<span>"+ tempItemNum + "</span></h5><div class='item_add'><span class='item_price'><h6>Minimum Bid: <span>"+ Convert.ToString(reader["minBid"]) + "</span></h6></span></div><div class='item_add'><span class='item_price'><a href='auctionItemDetails.aspx?itemNum="+tempItemNum+"'>Bid Now</a></span></div></div></li>";

                           
                            if (((Session["permissionLevel"]!=null) && (Session["permissionLevel"].Equals("Admin") || Session["permissionLevel"].Equals("Steering Committee")))&& (Session["adminAccess"]!=null && Session["adminAccess"].Equals("Yes")))
                            {
                                htmlForImages = "<li color='white'><a href='auctionItemDetails.aspx'><img style='height:300px; width:300px' class='img-responsive' data-imagezoom='true' src='" + tempImgPath + "' /></a><div style='height:200px;margin-bottom:3%;background-color:#484848' class='special-info grid_1 simpleCart_shelfItem'><h5 color='white !important'>" + Convert.ToString(reader["category"]) + "</h5><h5 color='white' !important>Item Number:<span>" + tempItemNum + "</span></h5><div class='item_add'><span class='item_price'><h6 color='white' !important>Minimum Bid: <span>" + Convert.ToString(reader["minBid"]) + "</span></h6></span></div><div class='item_add'><span class='item_price'><a href='printBidSheet.aspx?itemNum=" + tempItemNum + "&category=" + tempCategory + "&minBidAmount=" + tempMinBidAmt + "&sponsor="+ tempSponsor + "'>Print BidSheet</a></span></div></div></li>";
                            }
                            else
                            {
                                htmlForImages = "<li color='white'><a href='auctionItemDetails.aspx'><img style='height:300px; width:300px' class='img-responsive' data-imagezoom='true' src='" + tempImgPath + "' /></a><div style='height:200px;margin-bottom:3%;background-color:#484848' class='special-info grid_1 simpleCart_shelfItem'><h5 color='white !important'>" + Convert.ToString(reader["category"]) + "</h5><h5 color='white' !important>Item Number:<span>" + tempItemNum + "</span></h5><div class='item_add'><span class='item_price'><h6 color='white' !important>Minimum Bid: <span>" + Convert.ToString(reader["minBid"]) + "</span></h6></span></div><div class='item_add'><span class='item_price'></span></div></div></li>";
                            }




                                ImagesDiv.InnerHtml += htmlForImages;
                           

                            i++;
                        } while (reader.Read());
                        String imgOnUi = "<img style = 'height:auto; width:auto;border-radius: 50%;' class='img-responsive' src='" + Session["profilePicTemp"].ToString() + "' />";
                        ImgUiDiv.InnerHtml += imgOnUi;
                    }
                    else
                    {
                        Label1.Text = "Some error";
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