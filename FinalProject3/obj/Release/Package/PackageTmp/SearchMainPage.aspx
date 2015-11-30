<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="SearchMainPage.aspx.cs" Inherits="FinalProject3.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <link rel="stylesheet" type="text/css" href="css/AddAuctionItem.css" />





    <br /> <br /> <br />
         <div class="container">
                    
                    <div class="row">
                    	<div class="col-sm-3 book">
                    		
                    	</div>
                        <div class="col-sm-5 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h1 style="color:white;font-weight:bolder">Search Items & Users</h1>
                        		</div>
                        		<div class="form-top-right">
                        			<i class="glyphicon glyphicon-search"></i>
                        		</div>
                            </div>

                            <div class="form-bottom">
			                    <div class="registration-form">
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="selectpicker form-control input-lg">
                                        <asp:ListItem>Select option</asp:ListItem>
                                        <asp:ListItem>Finding Auction Items</asp:ListItem>
                                        <asp:ListItem>Finding Users</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <asp:Button ID="Button1" runat="server" Text="Go!" type="button" class="btn btn-primary btn-block " OnClick="Button1_Click" />

                            </div>
                        </div>
                    </div>   
</asp:Content>
