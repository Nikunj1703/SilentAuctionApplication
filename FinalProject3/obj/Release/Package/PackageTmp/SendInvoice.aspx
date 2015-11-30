<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="SendInvoice.aspx.cs" Inherits="FinalProject3.SendInvoice" %>
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
            background-color:black;
        }
        	</style>
    
    <div class="form-top">
                        		<div class="form-top-left">
                        			<h1 style="color:white;font-weight:bolder">Winners List</h1>
                        		</div>
                                
                        		<div class="form-top-right">
                        			<i class="glyphicon glyphicon-king"></i>
                        		</div>
                                <hr class="colorgraph"/>
         </div>
     <div class="form-bottom">
			                    <div class="registration-form">
    <table>
        <tr>
            <td> <asp:Label runat="server" ID="Label1">Name :</asp:Label></td>
            <td><asp:TextBox BackColor="Black" ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td> <asp:Label runat="server" ID="Label2">Phone : </asp:Label></td>
            <td> <asp:TextBox BackColor="Black" ID="TextBox2" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td> <asp:Label runat="server" ID="Label3">Email: </asp:Label></td>
            <td><asp:TextBox BackColor="Black" ID="TextBox3" runat="server"></asp:TextBox>
           
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>&nbsp&nbsp
               </td>
            <td> <asp:Button ID="Button3" runat="server" class="btn btn-success"  Text="Update Email" OnClick="Button3_Click" />
            </td>
            <td><asp:Label ID="Label4" runat="server" style="margin-left:-0.1%" CssClass="navbar-text label label-danger lab" Font-Size="Large"></asp:Label>
                <asp:Label ID="Label5" Visible="false" runat="server" style="margin-left:-0.1%" CssClass="navbar-text label label-success lab" Font-Size="Large"></asp:Label>
            </td>
            
                <!--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email Required" ControlToValidate="TextBox3" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></td>-->
        </tr>
    </table>
                                    </div></div>
   

   
    
           
     <div id="admindiv" runat="server">
     
    <table id="example" class="table table-striped table-bordered" runat="server" >
        <thead>
            <tr>
                <th>Bid ID</th>
                <th>Item ID</th>
                <th>Payment Status</th>
               <th>Bid Amount </th>
               
                 
            </tr>
        </thead>
 
       
    </table>
    </div>
    <asp:Button ID="Button1" runat="server" class="btn btn-warning" Text="Send SMS" OnClick="Button1_Click" />
     <asp:Button ID="Button2" runat="server" class="btn btn-success" Text="Send Email" OnClick="Button2_Click" /> <br />
   
    
</asp:Content>
