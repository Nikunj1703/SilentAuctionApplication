<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="EditandUpdateProBootstrap.aspx.cs" Inherits="FinalProject3.EditandUpdateProBootstrap" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/AddAuctionItem.css" />
   <link type="text/css" rel="stylesheet" href="css/EditandUpdateProBootstrap.css" /> 
      
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    
     <style>
        th{
            color:black;
            font-size:1.25em;
            width:650px;
            font-family:Georgia;
            font-weight:bold;
        }
        .input-group-addon{
            color:white;
            font-size:1em;
            font-family:Georgia;
            font-weight:bold;
            background-color:black;
        }
    </style>

    <div class="container">
        

         <div class="row">
                    	<div class="col-sm-2 book">
                    		
                    	</div>
                        <div class="col-sm-7 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h1 style="color:white;font-weight:bolder">Update Profile</h1>
                        		</div>
                                
                                
                        		<div class="form-top-right" runat="server" id="ImgUiDiv" style="opacity:1.0 !important">
                        			
                        		</div>
                               
                            </div>
                            <div class="form-bottom" style="margin-top:-5%">
                                <div class="registration-form">
                                       <div id="editUpdateId">
        <div id="loginbox">                    
            <div class="panel panel-info" >
                <div class="panel-body" >
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="input-group">
                                  <asp:Label ID="Label2" runat="server" CssClass="navbar-text label label-success lab" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="input-group">
                                <span class="input-group-addon">First Name</span>
                            </div>


                            <asp:TextBox ID="TextBox1" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server" class="input-group-addon"></asp:TextBox>



                            <div class="input-group">
                                <span class="input-group-addon">Last Name</span>
                            </div>


                            <asp:TextBox ID="TextBox2" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server"></asp:TextBox>



                            <div class="input-group">
                                <span class="input-group-addon">Address</span>
                            </div>


                            <asp:TextBox ID="TextBox3" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server"></asp:TextBox>


                            <div class="input-group">
                                <span class="input-group-addon">City</span>
                            </div>


                            <asp:TextBox ID="TextBox4" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server"></asp:TextBox>

                            <div class="input-group">
                                <span class="input-group-addon">Country</span>
                            </div>

                            <asp:TextBox ID="TextBox5" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server"></asp:TextBox></td>

              <div class="input-group">
                  <span class="input-group-addon">State</span>
              </div>

                            <asp:TextBox ID="TextBox6" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server"></asp:TextBox></td>

              <div class="input-group">
                  <span class="input-group-addon">Zip</span>
              </div>

                            <asp:TextBox ID="TextBox7" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server"></asp:TextBox>

                            <div class="input-group">
                                <span class="input-group-addon">Home Phone</span>
                            </div>

                            <asp:TextBox ID="TextBox8" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server" CssClass="form-control"></asp:TextBox>

                            <div class="input-group">
                                <span class="input-group-addon">Cell Phone</span>
                            </div>

                            <asp:TextBox ID="TextBox9" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server" CssClass="form-control"></asp:TextBox>

                            <div class="input-group">
                                <span class="input-group-addon">Email</span>
                            </div>

                            <asp:TextBox ID="TextBox10" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>

                            <div class="input-group">
                                <span class="input-group-addon">Password</span>
                            </div>

                            <asp:TextBox ID="TextBox11" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server" CssClass="form-control"></asp:TextBox>


                            <div class="input-group">
                                <span class="input-group-addon">Image Path</span>
                            </div>

                            <asp:TextBox ID="TextBox12" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server" CssClass="form-control"></asp:TextBox></td>
                
             <div class="input-group">
                 <span class="input-group-addon">Enable Text Message</span>
             </div>

                            <asp:RadioButton ID="RadioButton1" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server" Text="Yes" GroupName="TextMsg" />
                            <asp:RadioButton ID="RadioButton2" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server" Text="No" GroupName="TextMsg" />

                            <div class="input-group">
                                <span class="input-group-addon">Email Subscription</span>
                            </div>

                            <asp:RadioButton ID="RadioButton3" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server" Text="Yes" GroupName="EmailSub" />
                            <asp:RadioButton ID="RadioButton4" Font-Bold="true" ForeColor="Black" Font-Names="Georgia" runat="server" Text="No" GroupName="EmailSub" />
                            
                            
      
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Button1" />
                        </Triggers>
                    </asp:UpdatePanel>
            
    </div>
               
                </div>
            
             <asp:Button ID="Button1" runat="server" Text="Edit" OnClick="Button1_Click" CssClass="btn btn-primary btnedit" />
         <asp:Button ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" CssClass="btn btn-primary"/>
           
           
                 
            </div>
        
        </div>
                                </div>
                            </div>
                        </div>
             </div>
    </div>
</asp:Content>
