<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" EnableViewState="false" AutoEventWireup="true" CodeBehind="AddAuctionItem.aspx.cs" Inherits="FinalProject3.AddAuctionItem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link rel="stylesheet" type="text/css" href="css/AddAuctionItem.css" />
         <div class="container">
                    
                    <div class="row">
                    	<div class="col-sm-3 book">
                    		
                    	</div>
                        <div class="col-sm-6 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h1 style="color:white;font-weight:bolder">Add Auction Item</h1>
                            		<p>Make your contribution</p>
                        		</div>
                        		<div class="form-top-right">
                        			<i class="glyphicon glyphicon-shopping-cart"></i>
                        		</div>
                            </div>
                            <div class="form-bottom">
			                    <div class="registration-form">
                                    <asp:ScriptManager ID="ScriptManager1"  runat="server"></asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                    <div class="form-group">
			                        	<label class="sr-only"  for="form-last-name">Item Description</label>
			                        	<input type="text" runat="server" style="color:black;font-size:x-large;font-weight:bolder;font-family:Georgia"  name="form-last-name" placeholder="Item Description" class="form-last-name form-control" id="itemDesc"/>
			                        </div>
                                     <div class="form-group">
			                        	<label class="sr-only" for="form-last-name">Designer</label>
			                        	<input type="text" runat="server" style="color:black;font-size:x-large;font-weight:bolder;font-family:Georgia"  name="form-last-name" placeholder="Designer" class="form-last-name form-control" id="designer"/>
			                        </div>
                                    <div class="form-group">
			                        	<label class="sr-only" for="form-last-name">Estimated Value</label>
                                         <asp:TextBox ID="estimatedVal" style="color:black;font-size:x-large;font-weight:bolder;font-family:Georgia"  placeholder="Estimated Value" AutoPostBack="true"
                                                      class="form-last-name form-control" runat="server">
                                                    </asp:TextBox>
			                        </div>
                                   
			                    	        <div class="form-group">
			                    		        <asp:DropDownList class="form-control" style="color:black;font-size:x-large;font-weight:bolder;font-family:Georgia;height:auto"  ID="DropDownList1" AutoPostBack="true"
                                                    OnSelectedIndexChanged="CalculateBasedOnCat" runat="server">
                                                    <asp:ListItem>Select Category</asp:ListItem>
                                                    <asp:ListItem>Gingerbread</asp:ListItem>
                                                    <asp:ListItem>Celebrity Place</asp:ListItem>
                                                    <asp:ListItem>Jingle Bell Junction</asp:ListItem>
                                                    <asp:ListItem>Opening Night</asp:ListItem>
                                                    <asp:ListItem>Designer Items</asp:ListItem>
			                    		        </asp:DropDownList>
                                                </div>
                                            <div class="form-group">
                                                 <asp:DropDownList class="form-control" style="color:black;font-size:x-large;font-weight:bolder;font-family:Georgia;height:auto" ID="DropDownList2"
                                                      OnSelectedIndexChanged="CelPlaceChanged" AutoPostBack="true"
                                                      Visible="false" runat="server">
                                                     <asp:ListItem>Select Item</asp:ListItem>
                                                    <asp:ListItem>Consignment items</asp:ListItem>
                                                    <asp:ListItem>Donated items</asp:ListItem>
                                                    <asp:ListItem>Purchased items</asp:ListItem>
                                                </asp:DropDownList>
			                                </div>

                                         <div class="form-group">
                                                 <asp:DropDownList class="form-control" style="color:black;font-size:x-large;font-weight:bolder;font-family:Georgia;height:auto" ID="DropDownList3"
                                                      OnSelectedIndexChanged="OpeningNightDD" AutoPostBack="true"
                                                      Visible="false" runat="server">
                                                     <asp:ListItem>Select Item</asp:ListItem>
                                                    <asp:ListItem>Live Auction</asp:ListItem>
                                                    <asp:ListItem>Silent Auction</asp:ListItem>
                                                </asp:DropDownList>
			                              </div>

                                          <div class="form-group">
                                                 <asp:DropDownList class="form-control" style="color:black;font-size:x-large;font-weight:bolder;font-family:Georgia;height:auto" ID="DropDownList4"
                                                      OnSelectedIndexChanged="LiveAuctionDD" AutoPostBack="true"
                                                      Visible="false" runat="server">
                                                     <asp:ListItem>Select Item</asp:ListItem>
                                                    <asp:ListItem>Birthday Parties (or other cause donation)</asp:ListItem>
                                                    <asp:ListItem>Other items</asp:ListItem>
                                                </asp:DropDownList>
			                              </div>
                                         <div class="form-group">
                                                 <asp:DropDownList class="form-control" style="color:black;font-size:x-large;font-weight:bolder;font-family:Georgia;height:auto" ID="DropDownList5"
                                                      OnSelectedIndexChanged="DesignerItemDD" AutoPostBack="true"
                                                      Visible="false" runat="server">
                                                     <asp:ListItem>Select Item</asp:ListItem>
                                                    <asp:ListItem>Trees supplied by The Baby Fold</asp:ListItem>
                                                    <asp:ListItem>All other designer items</asp:ListItem>
                                                </asp:DropDownList>
			                              </div>





                                             <div class="form-group" id="purchasePriceId" runat="server" visible="false">
			                        	        <label class="sr-only" for="form-last-name">Purchase Price</label>
                                                    <asp:TextBox ID="purchasePrice" style="color:black;font-size:x-large;font-weight:bolder;font-family:Georgia" placeholder="Purchase Price" AutoPostBack="true"
                                                        OnTextChanged="CalculateBasedOnPurchase"
                                                        class="form-last-name form-control" runat="server">
                                                    </asp:TextBox>
			                        	       
			                                 </div>

                                   


			                         <div class="form-group">
			                        	<label class="sr-only" for="form-last-name">Minimum Bid</label>
			                        	<input type="text" runat="server" name="form-last-name" style="color:black;font-size:x-large;font-weight:bolder;font-family:Georgia" placeholder="Minimum Bid" class="form-last-name form-control" id="minBid"/>
			                        </div>
                                    <div class="form-group">
			                        	<label class="sr-only" for="form-last-name">Angel Price</label>
			                        	<input type="text" runat="server" name="form-last-name" style="color:black;font-size:x-large;font-weight:bolder;font-family:Georgia" placeholder="Angel Price" class="form-last-name form-control" id="angelPrice"/>
			                        </div>




                                        
                                <script type="text/javascript">
                                function uploadStarted() {
                                    $get("imgDisplay").style.display = "none";
                                    $get("progressId").style.visibility = "visible";
                                }
                                function uploadComplete(sender, args) {
                                    var imgDisplay = $get("imgDisplay");
                                    imgDisplay.src = "images/loader.gif";
                                    imgDisplay.style.cssText = "";
                                    var img = new Image();
                                    img.onload = function () {
                                        imgDisplay.style.cssText = "height:200px;width:200px";
                                        imgDisplay.src = img.src;
                                        progressId.style.visibility = "hidden";
                                    };
                                    img.src = "<%= ResolveUrl(UploadFolderPath) %>" + args.get_fileName();
                                }
                                </script>


                                <div class="row">
                                    <div class="col-sm-3">
                                       
                                        <cc1:asyncfileupload onclientuploadcomplete="uploadComplete" runat="server" id="AsyncFileUpload1"
                                            width="200px"  completebackcolor="White" uploadingbackcolor="#CCFFFF"
                                             style="margin-left:15%" onuploadedcomplete="FileUploadComplete" onclientuploadstarted="uploadStarted" />
                                    </div>
                                    <div class="col-sm-3">
                                        <!--<asp:Image ID="imgLoader" runat="server" ImageUrl="~/images/loader.gif" />-->
                                          <div class="progress" id="progressId" style="visibility:collapse">
                                              <div class="progress-bar progress-bar-success progress-bar-striped active" role="progressbar"
                                              aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width:100%;height:120%">
                                                Loading...
                                              </div>
                                        </div>
                                    </div>
                                    
                                     <div class="col-sm-6">
                                        <img id="imgDisplay" alt="" src="" style="display:none" />
                                    </div>
                                </div><br />

















                                     </ContentTemplate>
			                        </asp:UpdatePanel>


			                        
                                    <asp:Button ID="Button1" runat="server" OnClick="AddAuctionItem_Click"  class="btn" CssClass="btn btn-info glyphicon-text-size btn-lg" Text="Give it to us!" ></asp:Button>
			                        <!--<script type="text/javascript" src="js/jquery-1.11.3.js"></script>-->
                                    <script type="text/javascript">
                                        var str;
                                        str = window.location.href;
                                        var res = str.substr(str.lastIndexOf("#") + 1, 7);
                                        if (res == "success") {
                                                $(window).load(function(){
                                                    $('#success').modal('show');
                                                });
                                        }
                                    </script>


                                     <!--<a class="btn btn-success" id="successModalID" href="#success" data-toggle="modal"></a>-->
                                    
                                    
                                    <!-- Modal -->
                                    <div class="modal fade" id="success" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header modal-header-success">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                                    <h1><i class="glyphicon glyphicon-thumbs-up"></i> Item Added for the Auction</h1>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-danger pull-left" data-dismiss="modal">Close</button>
                                                </div>
                                            </div><!-- /.modal-content -->
                                        </div><!-- /.modal-dialog -->
                                  </div><!-- /.modal -->

                                        


                                </div>
		                    </div>
                        </div>
                    </div>
                </div>


</asp:Content>
