<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" AutoEventWireup="true" CodeBehind="BiddingHomescreen.aspx.cs" Inherits="FinalProject3.BiddingHomescreen" %>
<%@ MasterType VirtualPath="~/BootstrapASP.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




                    <!-- jQuery (necessary JavaScript plugins) -->
<script type='text/javascript' src="jsCart/jquery-1.11.3.js"></script>

     
          <script type="text/javascript" src="jsCart/megamenu.js"></script>
<script src="jsCart/menu_jquery.js"></script>
<script src="jsCart/simpleCart.min.js"> </script>






<link href="cssCart/bootstrap.css" rel='stylesheet' type='text/css' />

<!-- Custom Theme files -->
<link href="cssCart/style.css" rel='stylesheet' type='text/css' />
<!-- Custom Theme files -->
<!--//theme-style-->
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Gretong Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<link href='//fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900' rel='stylesheet' type='text/css'/>
<link href='//fonts.googleapis.com/css?family=Playfair+Display:400,700,900' rel='stylesheet' type='text/css'/>
<!-- start menu -->
<link href="cssCart/megamenu.css" rel="stylesheet" type="text/css" media="all" />

  <script>$(document).ready(function(){$(".megamenu").megamenu();});</script>   


    <style>
        td{
            color:white;
        }
    </style>

   

<!-- header_top -->


    <div runat="server" id="ImgUiDiv" style="opacity:1.0 !important; float:right;width:100px;height:100px;margin-right:-14%"></div><br /><br />
<div class="header_bg">
     
<div class="container">
	<div class="container-fluid">
       
	
		<!-- start header menu -->
	    <ul class="megamenu specia-top center-block grid_1 col-sm-12" style="margin:auto">

		        <li ><a  style="background-color:#EF5F21" class="col-sm-2 col-lg-2 col-md-2" href="#">Gingerbread</a></li>
		        <li ><a  href="#" style="background-color:#589D3E" class="col-sm-3 col-lg-3 col-md-3">Celebrity Place</a></li>
		        <li ><a href="#" style="background-color:#00ACED" class="col-sm-3 col-lg-3 col-md-3">Jingle Bell Junction</a></li>
		        <li ><a  href="#" style="background-color:#D61F85" class="col-sm-2 col-lg-2 col-md-2">Opening Night</a></li>
		        <li ><a href="#" style="background-color:#F89F1B" class="col-sm-2 col-lg-2 col-md-2">Designer Items</a></li>
		 </ul> 
	</div>
</div>
</div>

     <!-- FlexSlider -->
						<script src="jsCart/imagezoom.js"></script>
							<script defer src="jsCart/jquery.flexslider.js"></script>
						<link rel="stylesheet" href="cssCart/flexslider.css" type="text/css" media="screen" />

						<script>
						// Can also be used with $(document).ready()
						$(window).load(function() {
							$('.flexslider').flexslider({
							animation: "slide",
							controlNav: "thumbnails"
							});
						});
						</script>
				<!-- //FlexSlider-->
    <td>
<div class="special" style="color:white !important" >
	
	<div class="container" style="background-color:black; padding-top:10px; margin-top:-5%">
		
		
			<ul  class="grid_2">


              
		            <div  runat="server" class="grid_2 col-sm-12" id="ImagesDiv" style="color:white !important"></div>
		          
		
                <asp:Label ID="Label1" runat="server"></asp:Label>
                
		<div class="clearfix"> </div>
	</ul>
		
	</div>
</div>

</td>















</asp:Content>
