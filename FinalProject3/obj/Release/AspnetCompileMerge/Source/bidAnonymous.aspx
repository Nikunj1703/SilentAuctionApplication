<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="bidAnonymous.aspx.cs" Inherits="FinalProject3.bidAnonymous" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   









    <div class="container">
        <div id="loginbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">                    
            <div class="panel panel-info" >
                    <div class="panel-heading">
                        <div class="panel-title" style="margin-left:160px; font-weight:600;">LOGIN ANONYMOUS BIDDER</div>
                        <div style="padding-top:30px" class="panel-body" >

                        
                        
                            <div style="margin-bottom: 25px" class="input-group">
                                        <span class="input-group-addon">FirstName</span>
                                 
                                          <asp:TextBox ID="fnameId" runat="server"  CssClass="form-control" ></asp:TextBox>

                       
                    </div>   
                            
                            <div style="margin-bottom: 25px" class="input-group">
                                        <span class="input-group-addon">LastName</span>
                                 
                                          <asp:TextBox ID="lnameId" runat="server" CssClass="form-control" ></asp:TextBox>

                       
                    </div>  
                             <div style="margin-bottom: 25px" class="input-group">
                                        <span class="input-group-addon">Cell Phone</span>
                                 
                                          <asp:TextBox ID="cellId" runat="server" CssClass="form-control" ></asp:TextBox>

                       
                    </div>  
                           
                           <div style="margin-top:10px" class="form-group">
                                    <!-- Button -->

                                    <div class="col-sm-12 controls">
                                        <asp:Button ID="Button1" runat="server" Text="Login"  CssClass="btn btn-success" OnClick="Button1_Click" /></br>
                                         </div>
                                                       
                                         
                                   
                                </div>


                                    
                           



                        </div>  
                            
                            
                            
                              



      </div>
</div>     
        </div>     

         </div>     





</asp:Content>
