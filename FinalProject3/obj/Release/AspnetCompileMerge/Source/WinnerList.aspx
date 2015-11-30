<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="WinnerList.aspx.cs" Inherits="FinalProject3.WinnerList" %>
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
    <div id="admindiv" runat="server">
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
        <table id="example" class="table table-striped table-bordered" runat="server" >
        <thead>
            <tr>
                <th>Name</th>
                <th>Phone Number</th>
                <th>Action</th>
                 
            </tr>
        </thead>
 
       
    </table>
                                    </div>
             </div>
    </div>
    <asp:Label ID="Label1" runat="server" ></asp:Label>
</asp:Content>
