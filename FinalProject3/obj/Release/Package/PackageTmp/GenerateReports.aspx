<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="GenerateReports.aspx.cs" Inherits="FinalProject3.GenerateReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <link rel="stylesheet" type="text/css" href="css/AddAuctionItem.css" />
   
   
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" />
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <ContentTemplate>
    <div class="container">
       <div class="row">
                    	<div class="col-sm-2 book">
                    		
                    	</div>
                        <div class="col-sm-7 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h1 style="color:white;font-weight:bolder">Generate Reports</h1>
                        		</div>
                                
                        		<div class="form-top-right">
                        			<i class="glyphicon glyphicon-list-alt"></i>
                        		</div>
                                
                            </div>
                            <hr class="colorgraph"/>
                            <div class="form-bottom">
			                    <div class="registration-form">
                               
                                    <div class="form-group">
                         <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="radio-inline " TextAlign="Right" Font-Size="Medium" ForeColor="#999999" >
                               
                                                    <asp:ListItem Text="Gingerbread" Value="Paid Items">Paid Items</asp:ListItem> 
                                                    <asp:ListItem Text="Celebrity Place" Value="Unpaid Items">Unpaid Items</asp:ListItem>
                                                    <asp:ListItem Text="Opening Night" Value="Items with No Bid">Items with No Bid(Unsold Items)</asp:ListItem>
                         </asp:RadioButtonList>

                                         </div>
                                    <hr class="colorgraph"/>
                                    <div class="row" style="margin-bottom:20px;">

                                         <div class="col-xs-6 col-md-3"> <asp:Button ID="Button2" runat="server" Text="Search" CssClass="btn btn-info btn-block" OnClick="Button2_Click" /></div>
                                         <div class="col-xs-6 col-md-3"> <asp:Button ID="Button5" runat="server" CssClass="btn btn-warning " Visible="false" Text="Export To Excel" OnClick="Button5_Click"  /></div>
                                          
                                    </div>
                                       <asp:Label ID="Label5" runat="server"></asp:Label>   
                      
                                            <asp:Label ID="Label15" runat="server"></asp:Label>

                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                               </div>

























     <style>
             th{
            background-color:white;
            color:black;
            font-size:1.25em;
            width:650px;
            font-family:Georgia;
            font-weight:bold;
            text-align:center;
        }
             td{
            color:white;
            font-size:1em;
            font-family:Georgia;
            font-weight:bold;
            background-color:black;
        }
        	</style>
          <asp:Label ID="Label1" runat="server"></asp:Label>
<div runat="server" id="TableMainDiv">
    <table class="table table-striped table-bordered"  cellspacing="0" width="100%">
        <thead runat="server" id="dataTableHeader" visible="false">
            <tr>
                <th>Item ID</th>
                <th>Category</th>
                <th>Description</th>
                <th>Designer</th>
                <th>Minimum Bid</th>
                <th>Estimated Value</th>
                <th runat="server" visible="false" id="nameId">Name</th>
                <th runat="server" visible="false" id="phoneId">Phone</th>
                <th runat="server" visible="false" id="winStat">Winning Status</th>
                <th runat="server" visible="false" id="paymentStat">Payment Status</th>
            </tr>
        </thead>
 
       
 
        <tbody>
           
               <div id="dataTableData" runat="server" visible="false"></div>
                
                
            </tbody>
    </table>
	</div>
     </ContentTemplate>
    </asp:UpdatePanel>
    

















</asp:Content>
