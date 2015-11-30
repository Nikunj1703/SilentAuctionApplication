<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="BidSheet.aspx.cs" Inherits="FinalProject3.BidSheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type='text/javascript' src="jsCart/jquery-1.11.3.js"></script>
    <script src="js/BidSheetJS.js"></script>
    <script src="js/BidSheetJS2.js"></script>
    <link href="css/BidSheet.css" rel='stylesheet' type='text/css' />
   
<div class="container">
    <div class="row clearfix">
        <div class="panel panel-default" >
          <div class="panel-body" runat="server" id="bidSheetPanelId" >
              <div class="row">
                  <div class="col-xs-3"></div>
                  <div class="col-xs-6 text-center">
                      <asp:Label ID="Label1" runat="server" style="text-align:center;font-size:x-large;font-weight:bold" Text=""></asp:Label>
                  </div>
                  <div class="col-xs-3"></div>
              </div>
             <div class="panel-footer" runat="server">
                 Category:&nbsp;<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 Item Number:&nbsp;<asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 Min. Bid:&nbsp;<asp:Label ID="Label4" runat="server" Text=""></asp:Label>
             </div>
          </div>
        </div>
    	
	</div>

    <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>Bid ID</th>
                <th>Name</th>
                <th>Phone Number</th>
                <th>Bid Amount</th>
            </tr>
        </thead>
 
       
 
        <tbody>
           
                <tr>
                    <td>Bid ID#</td>
                    <td>Minium Bid</td>
                    <td>XXXXXXXXXX</td>
                    <td id="minBidTD" runat="server"></td>
                </tr>
                <div id="dataTableId" runat="server">
                </div>
             <asp:ScriptManager ID="ScriptManager1" runat="server" />
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <tr>
                    <td><asp:TextBox ID="TextBox4" placeholder="BidID#" ReadOnly="true" class="form-control" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox1" placeholder="Name" class="form-control" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox2" placeholder="Phone Number" class="form-control" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox3" placeholder="Bid Amount" class="form-control" runat="server"></asp:TextBox></td>
                </tr>
            </tbody>
    </table>
	<asp:LinkButton ID="LinkButton2" class="btn btn-default pull-right" runat="server" OnClick="btnShow_OnClick">Download BidSheet</asp:LinkButton>
    <asp:LinkButton ID="LinkButton1" class="btn btn-default pull-right" runat="server" OnClick="LinkButton1_Click">Save</asp:LinkButton>
     </ContentTemplate>
    </asp:UpdatePanel>
</div>





















</asp:Content>
