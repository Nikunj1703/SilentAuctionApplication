<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="checkadminRequest.aspx.cs" Inherits="FinalProject3.checkadminRequest" %>
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
      <div class="container col-sm-12 form-box" style="width:auto">
        <div id="admindiv" runat="server" >
            <div class="row">
                
                <div>
                        	    <div class="form-top col-sm-12 ">
                        		    <div class="form-top-left">
                        			    <h1 style="color:white;font-weight:bolder">List of Requests</h1>
                        		    </div>
                        		    <div class="form-top-right">
                        			    <i class="glyphicon glyphicon-saved"></i>
                        		    </div>
                                </div>

                                  <div class="form-bottom col-sm-12">
		                            <div class="registration-form">
                                    <table id="example" class="table table-striped table-bordered container"  runat="server" >
                                        <thead>
                                            <tr>
                                                <th>First&nbspName</th>
                                                <th>Last&nbspName</th>
                                                <th>Address</th>
                                                <th>Cell&nbspPhone</th>
                                                <th>Email</th>
                                                <th>Permission</th>
                                                 <th>Allow&nbspAccess</th>
                                                <th>Action</th>
                 
                                            </tr>
                                        </thead>
                                      </table>
                                 </div>
                                </div>
                 </div>
            </div>
            </div>
   
   </div>
 
       
   
 
    <asp:Label ID="Label1" runat="server" ></asp:Label>
</asp:Content>
