using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace FinalProject3
{
    public partial class AddAuctionItem : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Session["loginEmail"] != null)
            {
                Master.FindControl("MainSignUpId").Visible = false;
                Master.FindControl("MainLoginId").Visible = false;
                Master.FindControl("MainUpdateProfileId").Visible = true;
                Master.FindControl("MainLogoutId").Visible = true;
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
            }
        }

        protected string UploadFolderPath = "~/AutionItemImages/";
        protected void FileUploadComplete(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
            AsyncFileUpload1.SaveAs(Server.MapPath(this.UploadFolderPath) + filename);
        }


        public void CalculateBasedOnCat(Object Source, EventArgs E)
        {
            string categoryVal = DropDownList1.SelectedItem.Value;
            angelPrice.Attributes.Add("readonly", "readonly");
            if (categoryVal.Equals("Gingerbread"))
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.Visible = false;
                minBid.Value = "Committee determines minimum bid";
                minBid.Attributes.Add("readonly", "readonly");
                purchasePrice.Text = "";
                purchasePriceId.Visible = false;
                DropDownList3.SelectedIndex = 0;
                DropDownList3.Visible = false;
                DropDownList4.SelectedIndex = 0;
                DropDownList4.Visible = false;
                DropDownList5.SelectedIndex = 0;
                DropDownList5.Visible = false;
                angelPrice.Value = "No Angel Price";
            }
            if (categoryVal.Equals("Celebrity Place"))
            {
                minBid.Value = "";
                DropDownList2.Visible = true;
                DropDownList3.SelectedIndex = 0;
                DropDownList3.Visible = false;
                DropDownList4.SelectedIndex = 0;
                DropDownList4.Visible = false;
                angelPrice.Value = "No Angel Price";
            }
            if (categoryVal.Equals("Jingle Bell Junction"))
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.Visible = false;
                DropDownList4.SelectedIndex = 0;
                DropDownList4.Visible = false;
                purchasePrice.Text = "";
                purchasePriceId.Visible = false;
                minBid.Value = Convert.ToString(Convert.ToDouble(estimatedVal.Text) * 0.33);
                angelPrice.Value = "No Angel Price";
            }
            if (categoryVal.Equals("Opening Night"))
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.Visible = false;
                purchasePrice.Text = "";
                purchasePriceId.Visible = false;
                minBid.Value = "";
                DropDownList3.Visible = true;
                angelPrice.Value = "No Angel Price";
            }
            if (categoryVal.Equals("Designer Items"))
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.Visible = false;
                minBid.Value = "";
                //purchasePrice.Text = "";
                purchasePriceId.Visible = false;
                DropDownList3.SelectedIndex = 0;
                DropDownList3.Visible = false;
                DropDownList4.SelectedIndex = 0;
                DropDownList4.Visible = false;
                DropDownList5.Visible = true;
            }
        }

        public void DesignerItemDD(Object Source, EventArgs E)
        {
            string designerItemVal = DropDownList5.SelectedItem.Value;
            if (designerItemVal.Equals("Trees supplied by The Baby Fold"))
            {
                //purchasePrice.Text = "";
                purchasePriceId.Visible = true;
                angelPrice.Value = Convert.ToString(Convert.ToDouble(estimatedVal.Text) * 1.1);
            }
            if (designerItemVal.Equals("All other designer items"))
            {
                purchasePrice.Text = "";
                purchasePriceId.Visible = false;
                minBid.Value = Convert.ToString(Convert.ToDouble(estimatedVal.Text) * 0.33);
                angelPrice.Value = Convert.ToString(Convert.ToDouble(estimatedVal.Text) * 1.25);
            }
        }
        public void OpeningNightDD(Object Source, EventArgs E)
        {
            string openingNightCat = DropDownList3.SelectedItem.Value;
            if (openingNightCat.Equals("Live Auction"))
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.Visible = false;
                purchasePrice.Text = "";
                purchasePriceId.Visible = false;
                minBid.Value = "";
                DropDownList3.Visible = true;
                DropDownList4.Visible = true;
            }
            if (openingNightCat.Equals("Silent Auction"))
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.Visible = false;
                purchasePrice.Text = "";
                purchasePriceId.Visible = false;
                minBid.Value = "";
                DropDownList3.Visible = true;
                DropDownList4.SelectedIndex = 0;
                DropDownList4.Visible = false;
                minBid.Value = Convert.ToString(Convert.ToDouble(estimatedVal.Text) * 0.33);
            }
        }

        public void LiveAuctionDD(Object Source, EventArgs E)
        {
            string liveAuctionDDList = DropDownList4.SelectedItem.Value;
            if (liveAuctionDDList.Equals("Birthday Parties (or other cause donation)"))
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.Visible = false;
                purchasePrice.Text = "";
                purchasePriceId.Visible = false;
                minBid.Value = "";
                DropDownList3.Visible = true;
                DropDownList4.Visible = true;
                minBid.Value = Convert.ToString(estimatedVal.Text);
            }
            if (liveAuctionDDList.Equals("Other items"))
            {
                DropDownList2.SelectedIndex = 0;
                DropDownList2.Visible = false;
                purchasePrice.Text = "";
                purchasePriceId.Visible = false;
                minBid.Value = "";
                DropDownList3.Visible = true;
                DropDownList4.Visible = true;
                minBid.Value = "Committee determines minimum bid";
                minBid.Attributes.Add("readonly", "readonly");

            }
        }
        public void CelPlaceChanged(Object Source, EventArgs E)
        {

            string celPlace = DropDownList2.SelectedItem.Value;
            if (celPlace.Equals("Consignment items"))
            {
                minBid.Attributes.Remove("readonly");
                minBid.Attributes.Add("visible", "visible");
                minBid.Value = estimatedVal.Text;
            }
            else if (celPlace.Equals("Donated items"))
            {
                minBid.Attributes.Remove("readonly");
                minBid.Attributes.Add("visible", "visible");
                minBid.Value = Convert.ToString(Convert.ToDouble(estimatedVal.Text) * 0.33);
            }
            else if (celPlace.Equals("Purchased items"))
            {
                minBid.Attributes.Remove("readonly");
                minBid.Attributes.Add("visible", "visible");
                purchasePriceId.Visible = true;
            }
        }



        public void CalculateBasedOnPurchase(Object Source, EventArgs E)
        {
            if (purchasePrice.Text != "")
                minBid.Value = Convert.ToString(Convert.ToDouble(purchasePrice.Text) + 0.33 * Convert.ToDouble(estimatedVal.Text));
        }


        protected void AddAuctionItem_Click(object sender, EventArgs e)
        {


            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    string itemDescVal = itemDesc.Value;
                    string designerVal = designer.Value;
                    string estmVal = estimatedVal.Text;
                    string categoryVal = DropDownList1.SelectedItem.Value;
                    string celebVal = DropDownList2.SelectedItem.Value;
                    string openingNightVal = DropDownList3.SelectedItem.Value;
                    string liveAuctionVal = DropDownList4.SelectedItem.Value;
                    string designerItemVal = DropDownList5.SelectedItem.Value;
                    string purchasePriceVal = purchasePrice.Text;
                    string minBidVal = minBid.Value;
                    string angelPriceVal = angelPrice.Value;
                    string itemType = "";


                    string itemImagePath = this.UploadFolderPath + System.IO.Path.GetFileName(AsyncFileUpload1.FileName);


                    SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                    try
                    {
                        dbConnection.Open();
                        dbConnection.ChangeDatabase("itk485nnrs");
                    }
                    catch (SqlException exception)
                    {
                        if (exception.Number == 911) // non-existent DB
                        {
                            SqlCommand sqlCommand = new SqlCommand("CREATE DATABASE itk485nnrs", dbConnection);
                            sqlCommand.ExecuteNonQuery();
                            dbConnection.ChangeDatabase("itk485nnrs");
                        }
                        else
                            Response.Write("<p>Error code " + exception.Number
                                + ": " + exception.Message + "</p>");
                    }
                    finally
                    {
                        Console.Write("Successfully selected the database");
                    }
                    try
                    {
                        if (categoryVal.Equals("Centerpiece"))
                        {
                            itemType = "CP";
                        }
                        else if (categoryVal.Equals("Celebrity Place"))
                        {
                            itemType = "CT";
                        }
                        else if (categoryVal.Equals("Gingerbread"))
                        {
                            itemType = "G";
                        }
                        else if (categoryVal.Equals("Jingle Bell Junction"))
                        {
                            itemType = "JBJ";
                        }
                        else if (categoryVal.Equals("Large Tree"))
                        {
                            itemType = "ON";
                        }
                        else
                        {
                            itemType = "OT";
                        }


                        if (categoryVal.Equals("Celebrity Place") && celebVal.Equals("Consignment items"))
                        {
                            categoryVal = "Consignment items";
                        }
                        else if (categoryVal.Equals("Celebrity Place") && celebVal.Equals("Donated items"))
                        {
                            categoryVal = "Donated items";
                        }
                        else if (categoryVal.Equals("Celebrity Place") && celebVal.Equals("Purchased items"))
                        {
                            categoryVal = "Purchased items";
                        }


                        if (categoryVal.Equals("Opening Night") && openingNightVal.Equals("Silent Auction"))
                        {
                            categoryVal = "Silent Auction";
                        }
                        else if (categoryVal.Equals("Opening Night") && openingNightVal.Equals("Live Auction") && liveAuctionVal.Equals("Birthday Parties (or other cause donation)"))
                        {
                            categoryVal = "Birthday Parties (or other cause donation)";
                        }
                        else if (categoryVal.Equals("Opening Night") && openingNightVal.Equals("Live Auction") && liveAuctionVal.Equals("Other items"))
                        {
                            categoryVal = "Other items";
                        }

                        if (categoryVal.Equals("Designer Items") && designerItemVal.Equals("Trees supplied by The Baby Fold"))
                        {
                            categoryVal = "Trees supplied by The Baby Fold";
                        }
                        else if (categoryVal.Equals("Designer Items") && designerItemVal.Equals("All other designer items"))
                        {
                            categoryVal = "All other designer items";
                        }




                        string auctionItemQuery = "INSERT INTO auctionitemstable (itemType,category,itemDesc,designer,estimatedValue,minBid,angelPrice,itemImagePath,purchasePrice) VALUES('"
                            + itemType + "', '"
                            + categoryVal + "', '"
                             + itemDescVal + "', '"
                              + designerVal + "', '"
                               + estmVal + "', '"
                                + minBidVal + "', '"
                                 + angelPriceVal + "', '"
                                 + itemImagePath + "', '"
                            + purchasePriceVal + "')";

                        SqlCommand sqlCommand = new SqlCommand(auctionItemQuery, dbConnection);
                        sqlCommand.ExecuteNonQuery();
                        Response.Redirect(Request.RawUrl + "#success");
                        

                        //successModalBtn_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Some Exception Occured: " + ex.Message);
                    }

                    dbConnection.Close();
                }

            }

        }


    }
}