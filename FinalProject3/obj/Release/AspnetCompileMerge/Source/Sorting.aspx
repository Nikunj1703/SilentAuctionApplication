<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="Sorting.aspx.cs" Inherits="FinalProject3.Sorting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <link  rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
  
       <link href="css/UpdateProfile.css" rel="stylesheet" />
    <style>
        .form-top {
	        overflow: hidden;
	        padding: 0 25px 15px 25px;
	        background: #444;
	        background: rgba(0, 0, 0, 0.35);
	        -moz-border-radius: 4px 4px 0 0; -webkit-border-radius: 4px 4px 0 0; border-radius: 4px 4px 0 0;
	        text-align: left;
        }
        h3 {
	        font-size: 22px;
            font-weight: 300;
            color: #555;
            line-height: 30px;
        }
        .form-top-left {
	        float: left;
	        width: 75%;
	        padding-top: 25px;
        }
        .form-top-right {
	        float: left;
	        width: 25%;
	        padding-top: 5px;
	        font-size: 66px;
	        color: #fff;
	        line-height: 100px;
	        text-align: right;
	        opacity: 0.3;
        }

.form-top-left h3 { margin-top: 0; color: #fff; }
    </style>
    <asp:Label ID="Label1" runat="server" ></asp:Label>

     <div id="mydiv" runat="server">

        <div class="form-top">
        <div class="form-top-left">
            <h3>Determining the winner</h3>
        </div>
        <div class="form-top-right">
            <i class="glyphicon glyphicon-king"></i>
        </div>
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
                <th>Action</th>
                <th style="width:250px">Edit/Update</th>
            </tr>
        </thead>
 
       
    </table>
    </div>

</asp:Content>
