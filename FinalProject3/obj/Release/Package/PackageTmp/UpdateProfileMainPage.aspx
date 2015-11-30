<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="UpdateProfileMainPage.aspx.cs" Inherits="FinalProject3.UpdateProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  

            <div class="container">    
        <div id="loginbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">                    
            <div class="panel panel-info" >
                    <div class="panel-heading">
                        <div class="panel-title">Update Profile</div>
                       
                    </div>     

                    <div style="padding-top:30px" class="panel-body" >

                        
                        
                            <div style="margin-bottom: 25px" class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                 
                                          <asp:TextBox ID="TextBox1" runat="server" placeholder="Email Address" CssClass="form-control"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="UpdateProfileEmailValidator1"  runat="server"  ErrorMessage="Email Required" Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox1" CssClass="form-control"></asp:RequiredFieldValidator> 
                                      
                                              
          
                                    </div>
                                                    
                                                                            


                                <div style="margin-top:10px" class="form-group">
                                    <!-- Button -->

                                    <div class="col-sm-12 controls">
                                        <asp:Button ID="Button1" runat="server" Text="Submit"  CssClass="btn btn-success" OnClick="Button1_Click" /></br>
                                         </div>
                                          <asp:Label ID="Label2" runat="server" CssClass="navbar-text label label-danger lab" Font-Size="Small"  ></asp:Label> 
                                      
                                         
                                   
                                </div>


                                    
                           



                        </div>                     
                    </div>  
        </div>
        
               
               
                
         </div> 
   
    
    

</asp:Content>
