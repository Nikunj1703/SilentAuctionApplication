<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="Sorting.aspx.cs" Inherits="FinalProject3.Sorting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <link  rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
  
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
    <div class="container">
    <asp:Label ID="Label1" runat="server" ></asp:Label>

     <div id="mydiv" runat="server">

        <div class="form-top">
                        		<div class="form-top-left">
                        			<h1 style="color:white;font-weight:bolder">Update Winner Info</h1>
                        		</div>
                                
                        		<div class="form-top-right">
                        			<i class="glyphicon glyphicon-king"></i>
                        		</div>
                                <hr class="colorgraph"/>
         </div>

      
    
      
    <table id="example" style="background-color:wheat" class="table table-striped table-bordered" runat="server" >
        <thead>
            <tr>
                <th>Bid ID</th>
                <th>Name</th>
                <th>Email</th>
                <th>Cell Phone</th>
                <th>Item ID</th>
                <th>Bid Amount</th>
                 <th>Payment Status</th>
                 <th>Winning Status</th>
               
                <th style="width:250px">Edit/Update</th>
            </tr>
        </thead>
 
       
    </table>
    </div>
        </div>
</asp:Content>
