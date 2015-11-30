<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="FinalProject3.SignIn" %>



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
    
        <br />
        <div id="signInId1" class="container" style="width:50%">

            <form class="form-signin">
        <div class="form-top col-sm-12 ">
        
         <div class="form-top-left">
             <h1 style="color:white;font-weight:bolder;font-family:Georgia"> Sign in</h1>
         </div>
        
                 <div class="form-top-right">
                        			    <i class="glyphicon glyphicon-user"></i>
                        		    </div>
             <div class="form-bottom col-sm-12">
        <label for="inputEmail" class="sr-only">Email address</label>
      <label style="color:white;font-size:large;float:left;font-family:Georgia">Email:</label><asp:TextBox ID="email" ForeColor="Black" Font-Bold="true" Font-Size="Larger" class="form-control" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter  Username" ControlToValidate="email" ForeColor="green"></asp:RequiredFieldValidator>

        <label for="inputPassword" class="sr-only">Password</label><br />
       <label style="color:white;font-size:large;font-family:Georgia">Password:</label><asp:TextBox ID="password" ForeColor="Black" Font-Bold="true" Font-Size="Larger" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter Password" ControlToValidate="password" ForeColor="green"></asp:RequiredFieldValidator>
     <br />
                <asp:Label ID="Label1" runat="server"></asp:Label>
              <asp:Literal ID="Literal1" Visible="false" runat="server" >
         <script type="text/javascript">
     var RecaptchaOptions = {
        theme : 'custom',
        custom_theme_widget: 'recaptcha_widget'
     };
</script>               

<form method="post" action="<?php echo $base_url; ?>user/register/check" method="post" class="form-horizontal well" accept-charset="UTF-8">

                    <script type="text/javascript">
                         var RecaptchaOptions = {
                            theme : 'custom',
                            custom_theme_widget: 'recaptcha_widget'
                         };
                    </script>
                    <div id="recaptcha_widget" style="display:none">

                        <div class="control-group">
                            <label class="control-label">reCAPTCHA</label>
                            <div class="controls">
                                <a id="recaptcha_image" href="#" class="thumbnail"></a>
                                <div class="recaptcha_only_if_incorrect_sol" style="color:red">Incorrect please try again</div>
                            </div>
                        </div>

                           <div class="control-group">
                               <label class="recaptcha_only_if_image control-label">Enter the words above:</label>
                              <label class="recaptcha_only_if_audio control-label">Enter the numbers you hear:</label>

                              <div class="controls">
                                  <div class="input-append">
                                      <input type="text" id="recaptcha_response_field" name="recaptcha_response_field" class="input-recaptcha" />
                                      <a class="btn" href="javascript:Recaptcha.reload()"><i class="icon-refresh"></i></a>
                                      <a class="btn recaptcha_only_if_image" href="javascript:Recaptcha.switch_type('audio')"><i title="Get an audio CAPTCHA" class="icon-headphones"></i></a>
                                      <a class="btn recaptcha_only_if_audio" href="javascript:Recaptcha.switch_type('image')"><i title="Get an image CAPTCHA" class="icon-picture"></i></a>
                                    <a class="btn" href="javascript:Recaptcha.showhelp()"><i class="icon-question-sign"></i></a>
                                  </div>
                              </div>
                        </div>

                    </div>

                    <script type="text/javascript"
                       src="<?php echo $recaptcha_url; ?>">
                    </script>

                    <noscript>
                        <iframe src="<?php echo $recaptcha_noscript_url; ?>"
                           height="300" width="500" frameborder="0"></iframe><br>
                        <textarea name="recaptcha_challenge_field" rows="3" cols="40">
                        </textarea>
                        <input type="hidden" name="recaptcha_response_field"
                           value="manual_challenge">
                      </noscript>
    </div>
    </div>
</form>
<script type="text/javascript" src="https://www.google.com/recaptcha/api/challenge?k=6LcrK9cSAAAAALEcjG9gTRPbeA0yAVsKd8sBpFpR"></script>

<noscript>
    <iframe src="<?php echo $recaptcha_noscript_url; ?>"
       height="300" width="500" frameborder="0"></iframe><br>
    <textarea name="recaptcha_challenge_field" rows="3" cols="40">
    </textarea>
    <input type="hidden" name="recaptcha_response_field" value="manual_challenge">
</noscript>

    </asp:Literal>
          
             <div class="checkbox">
          <label style="color:black;font-size:large">
              <asp:CheckBox ID="CheckBox1"  runat="server" ForeColor="White" Font-Names="Georgia" Text="Remember me" /> 
          </label>
        </div>
               
          <asp:Button ID="Button1" runat="server" style="z-index:3; background-color:black" class="btn btn-lg btn-primary" Text="Sign In" OnClick="Button_Click" />
  
                <br /><br />



<!-- Button trigger modal -->
<a data-toggle="modal" style="color:white;font-size:large;font-family:Georgia;" data-target="#myModalHorizontal">
    <u>Forget Password</u>
</a><br /><br />

<!-- Modal -->
<div class="modal fade" id="myModalHorizontal" tabindex="-1" role="dialog" 
     aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content" style="background-color:black;">
            <!-- Modal Header -->
            <div class="modal-header" style="background-color:black;">
                <button type="button" class="close" 
                   data-dismiss="modal">
                       <span aria-hidden="true">&times;</span>
                       <span class="sr-only">Close</span>
                </button>
                <h4 class="modal-title" id="myModalLabel" style="font-family:Georgia;color:white">
                    Forget Password
                </h4>
            </div>
            
            <!-- Modal Body -->
            <div class="modal-body" style="background-color:black">
                
              
                  <div class="form-group">
                    <label  class="col-sm-2 control-label" style="font-family:Georgia;color:white"
                              for="inputEmail3">Email</label>
                      <div class="col-sm-6">
                   <asp:TextBox ID="TextBox1" class="form-control" placeholder="Email" runat="server"></asp:TextBox></div>
                      <div class="col-sm-2">
                         <asp:Button ID="Button2"  class="btn btn-success" runat="server" Text="Recover" CausesValidation="False" OnClick="Button2_Click" />
                    </div>
                    </div>
                   
                    </div><br /><br />
                    


                  </div>
                  
                  </div>
           
                <br /><br />
                  
                
            </div>         
            
            
            
            
            
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
                                                    <h3><i class="glyphicon glyphicon-thumbs-up"></i>Your password has been recovered. Check your email.</h3>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-danger pull-left" data-dismiss="modal">Close</button>
                                                </div>
                                            </div><!-- /.modal-content -->
                                        </div><!-- /.modal-dialog -->
                                  </div><!-- /.modal -->   
        
 

<!-- Post Info -->
<div style='position:fixed;bottom:0;left:0; background:lightgray;width:100%;'>
   
</div>




















     </form>  
    </div>
    
     <!-- <script src="js/jquery-1.11.3.js"></script> 
    <script src="js/bootstrap.min.js"></script>  -->
    <!--<script src="js/ForgetPasswordModalJS.js"></script>  -->
  
       
          

</asp:Content>
