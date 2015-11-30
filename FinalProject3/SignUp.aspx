<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="FinalProject3.SignUp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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



       <script type="text/javascript">
        var str;
        str = window.location.href;
        var res = str.substr(str.lastIndexOf("#") + 1, 7);
        if (res == "success") {
                $(window).load(function(){
                    $('#success').modal('show');
                });
        }
    </script>


        <!--<a class="btn btn-success" id="successModalID" href="#success" data-toggle="modal"></a>-->
                              
                                    
    <!-- Modal -->
    <div class="modal fade" id="success" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header modal-header-success">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3><i class="glyphicon glyphicon-thumbs-up"></i> Congratulations! Your request has been submitted</h3>
                </div>
                <div class="modal-footer">
                    <asp:Button  id="Button2"  Text="Continue" runat="server"  class="btn btn-success pull-left"  data-dismiss="modal" />
                </div>
            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->

    

    <div class="container"  style="width:80%;">
        <div class="row">
            <section id="signUpId1" >
                <div class="wizard" style="background-color:black;opacity:0.8;text-align:left">
                    <div class="wizard-inner">
                        <div class="connecting-line"></div>
                        <ul class="nav nav-tabs" role="tablist">

                            <li role="presentation" class="active">
                                <a href="#step1" data-toggle="tab" aria-controls="step1" role="tab" title="Step 1">
                                    <span class="round-tab">
                                        <i class="glyphicon glyphicon-user"></i>
                                    </span>
                                </a>
                            </li>

                            <li role="presentation" class="disabled">
                                <a href="#step2" data-toggle="tab" aria-controls="step2" role="tab" title="Step 2">
                                    <span class="round-tab">
                                        <i class="glyphicon glyphicon-home"></i>
                                    </span>
                                </a>
                            </li>
                            <li role="presentation" class="disabled">
                                <a href="#step3" data-toggle="tab" aria-controls="step3" role="tab" title="Step 3">
                                    <span class="round-tab">
                                        <i class="glyphicon glyphicon-phone-alt"></i>
                                    </span>
                                </a>
                            </li>

                            <li role="presentation" class="disabled">
                                <a href="#complete" data-toggle="tab" aria-controls="complete" role="tab" title="Complete">
                                    <span class="round-tab">
                                        <i class="glyphicon glyphicon-ok"></i>
                                    </span>
                                </a>
                            </li>
                        </ul>
                    </div>

                    <form id="dataFormId" role="form">
                        <div class="tab-content">
                            <div class="tab-pane active" role="tabpanel" id="step1">

                                <div class="col-lg-offset-3 col-lg-6" style="text-align: center">

                                    <asp:TextBox ID="firstName" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" placeholder="First Name" class="form-control" runat="server" autofocus="true"></asp:TextBox><br />

                                    <asp:TextBox ID="lastName" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" placeholder="Last Name" class="form-control" runat="server"></asp:TextBox><br />
                                </div>
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <br />
                                <ul class="list-inline" style="text-align: center">
                                    <li>
                                        <button type="button" class="btn btn-primary next-step">Next</button></li>
                                </ul>
                            </div>
                            <div class="tab-pane" role="tabpanel" id="step2">
                                

                                    <asp:TextBox ID="address" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" placeholder="Address" class="form-control" runat="server"></asp:TextBox><br />

                                    <asp:TextBox ID="city" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" placeholder="City" class="form-control" runat="server"></asp:TextBox><br />

                                    <asp:DropDownList ID="country" class="form-control"  ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" 
                                         runat="server"></asp:DropDownList><br />
                                    <asp:TextBox ID="state" placeholder="State" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" class="form-control" runat="server"></asp:TextBox><br />
                                    <asp:TextBox ID="zip" placeholder="Zip" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" class="form-control" runat="server"></asp:TextBox><br />
                               
                                
                                <ul class="list-inline" style="text-align: center">
                                    <li>
                                        <button type="button" class="btn btn-warning prev-step" style="background-color:orange">Previous</button></li>
                                    <li>
                                        <button type="button" class="btn btn-primary next-step">Next</button></li>
                                </ul>
                            </div>
                            <div class="tab-pane" role="tabpanel" id="step3">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="homePhone" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" placeholder="Home Phone" class="form-control" runat="server"></asp:TextBox><br />
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="cellPhone" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" placeholder="Cell Phone*" class="form-control" runat="server"></asp:TextBox><br />
                                    </div>
                                </div>
                                
                                

                                <asp:Label ID="Label1" runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" Text="Enable Text Message*"></asp:Label>
                                <div class="btn-group" data-toggle="buttons">
                                    
                                        <asp:RadioButton ID="RadioButton1" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" CssClass="btn btn-default" GroupName="textMsgRadio" Text="Yes" runat="server" />
                                    
                                    
                                         <asp:RadioButton ID="RadioButton2" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" CssClass="btn btn-default" GroupName="textMsgRadio" Text="No" runat="server" />
                                    
                                    
                                </div>
                                <br />
                                <br />
                                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="email" placeholder="Email" AutoPostBack="true" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia"
                                        OnTextChanged="CheckUniqueEmail"
                                        class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <div id="emailErrorId" runat="server" visible="false" class="col-sm-4">
                                            <asp:Label ID="Label4" class="form-control"
                                                 Font-Italic="true" ForeColor="Black" Font-Bold="true" BackColor="Red"
                                                 runat="server" Text=""></asp:Label>
                                        </div>
                                        <div id="emailErrorId2" runat="server" visible="false" class="col-sm-4">
                                            <asp:Label ID="Label5" class="form-control"
                                                 Font-Italic="true" ForeColor="Black"  Font-Bold="true" BackColor="Green"
                                                 runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    
                                    
                                </ContentTemplate>
                                </asp:UpdatePanel>







                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="email" ErrorMessage="Email Address is required"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="password" placeholder="Password" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" TextMode="Password" class="form-control" runat="server"></asp:TextBox><br />
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="cPassword" placeholder="Confirm Password" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                
                                
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" 
                                    ErrorMessage="Password & Confirm Password must be same" ControlToCompare="password"
                                    ControlToValidate="cPassword"></asp:CompareValidator><br />
                                
                                <asp:Label ID="Label3" runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" Text="Permission Level"></asp:Label>
                                <asp:DropDownList class="form-control"  ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" ID="DropDownList1" runat="server">
                                    <asp:ListItem>Public</asp:ListItem>
                                    <asp:ListItem>Designer/Donor</asp:ListItem>
                                    <asp:ListItem>Steering Committee</asp:ListItem>
                                    <asp:ListItem>Admin</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="DropDownList1"
                                    ForeColor="Red" ErrorMessage="***Permission Level is Mendatory***"></asp:RequiredFieldValidator>
                                <br />




                                <asp:Label ID="Label2" runat="server" ForeColor="White" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" Text="Subscribe for email"></asp:Label>
                                 <div class="btn-group" data-toggle="buttons">
                                    
                                        <asp:RadioButton ID="RadioButton3" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" CssClass="btn btn-default" GroupName="emailRadio" Text="Yes" runat="server" />
                                    
                                    
                                         <asp:RadioButton ID="RadioButton4" ForeColor="Black" Font-Bold="true" Font-Size="Large" Font-Names="Georgia" CssClass="btn btn-default" GroupName="emailRadio" Text="No" runat="server" />
                                    
                                    
                                </div>
                                <br />
                                <br />

                                <ul class="list-inline" style="text-align: center">
                                    <li>
                                        <button type="button" class="btn btn-default prev-step" style="background-color:orange">Previous</button></li>
                                    <li>
                                        <button type="button" class="btn btn-primary btn-info-full next-step">Next</button></li>
                                </ul>
                            </div>
                            <div class="tab-pane" role="tabpanel" id="complete">


                                <script type="text/javascript">
                                function uploadStarted() {
                                    $get("imgDisplay").style.display = "none";
                                    $get("progressId").style.visibility = "visible";
                                }
                                function uploadComplete(sender, args) {
                                    var imgDisplay = $get("imgDisplay");
                                    imgDisplay.src = "images/loader.gif";
                                    imgDisplay.style.cssText = "";
                                    var img = new Image();
                                    img.onload = function () {
                                        imgDisplay.style.cssText = "height:200px;width:200px";
                                        imgDisplay.src = img.src;
                                        progressId.style.visibility = "hidden";
                                    };
                                    img.src = "<%= ResolveUrl(UploadFolderPath) %>" + args.get_fileName();
                                }
                                </script>


                                <div class="row">
                                    <div class="col-lg-4 col-md-6">
                                       
                                        <cc1:asyncfileupload onclientuploadcomplete="uploadComplete" runat="server" id="AsyncFileUpload1"
                                            width="200px" uploaderstyle="Modern" completebackcolor="White" uploadingbackcolor="#CCFFFF"
                                            throbberid="imgLoader" style="margin-left:15%;" onuploadedcomplete="FileUploadComplete" onclientuploadstarted="uploadStarted" />
                                        <asp:Image ID="imgLoader" runat="server" ImageUrl="~/images/loader.gif" /><br />
                                        <br />
                                          <div class="progress" id="progressId" style="visibility:collapse">
                                              <div class="progress-bar progress-bar-success progress-bar-striped active" role="progressbar"
                                              aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width:100%;height:120%">
                                                Loading...
                                              </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-0"></div>
                                    <div class="col-lg-5 col-md-6">
                                        <img id="imgDisplay" alt="" src="" style="display:none" />
                                    </div>
                                </div><br />
                               
                                 <ul class="list-inline" style="text-align: center">
                                    <li>
                                        
                                        <asp:Button ID="Button1" runat="server" OnClick="CreateProfile_Click" CssClass="btn btn-success" Text="Create Profile" /></li>
                                </ul>


                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </form>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </div>
            </section>
        </div>
    </div>



  



   <!-- <script src="js/jquery-1.11.3.js"></script> -->
    <script src="js/SignUpJS.js"></script> 
    <!--<script src="js/bootstrap.min.js"></script> -->





</asp:Content>
