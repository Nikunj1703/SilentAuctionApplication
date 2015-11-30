<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="EnterWinner.aspx.cs" Inherits="FinalProject3.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/AddAuctionItem.css" />
     <style>
        th{
            color:black;
            font-size:1.25em;
            width:650px;
            font-family:Georgia;
            font-weight:bold;
        }
        td{
            color:white;
            font-size:1em;
            font-family:Georgia;
            font-weight:bold;
            
        }
    </style>
     <div class="container">
                    
                    <div class="row">
                    	<div class="col-sm-3 book">
                    		
                    	</div>
                        <div class="col-sm-6 form-box">
                            <div class="form-top">
                        		<div class="form-top-left">
                                    <h1 style="color:white;font-weight:bolder">Enter Winner's Detail</h1>
                                </div>
                                <div class="form-top-right">
                        			<i class="glyphicon glyphicon-king"></i>
                        		</div>
                             </div>

                        <div class="form-bottom">
			                <div class="registration-form">
                            <table>
       
                                <tr>
                                    <td><asp:Label class="form-top-left" runat="server"><h3>Item Id</h3></asp:Label> </td>
                                    <td><asp:TextBox ID="TextBox5" ForeColor="Black" Font-Bold="true" Font-Size="Larger" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td><asp:Label class="form-top-left" runat="server"><h3>Name</h3></asp:Label> </td>
                                    <td><asp:TextBox ID="TextBox2" ForeColor="Black" Font-Bold="true" Font-Size="Larger" runat="server"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td><asp:Label class="form-top-left" runat="server"><h3>Phone number</h3></asp:Label> </td>
                                    <td><asp:TextBox ID="TextBox3" ForeColor="Black" Font-Bold="true" Font-Size="Larger" runat="server"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td><asp:Label class="form-top-left" runat="server"><h3>Bid Amount</h3></asp:Label> </td>
                                    <td><asp:TextBox ID="TextBox4" ForeColor="Black" Font-Bold="true" Font-Size="Larger" runat="server"></asp:TextBox></td>
                                </tr>
                                 <tr>
                                    <td><asp:Label class="form-top-left" runat="server"><h3>Payment Status</h3></asp:Label> </td>
                                    <td><asp:CheckBox ID="CheckBox1" class="checkbox"  runat="server" /></td>
                                </tr>
                                <tr><td> <asp:Button ID="Button1" runat="server" Text="Submit"   class="btn" CssClass="btn btn-info glyphicon-text-size btn-lg"  OnClick="Button1_Click" /></td></tr>
                            </table>
                            <div class="input-group">
                                <asp:Label ID="Label1" CssClass="navbar-text label label-success lab" Font-Size="Large" runat="server"></asp:Label>
                             </div>
                            </div>
                            </div>
                        </div>
                        <div class="col-sm-3 book">
                    		
                    	</div>
                    </div>
    </div>
   
   
    
   
</asp:Content>
