<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapASP.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="auctionItemDetails.aspx.cs" Inherits="FinalProject3.auctionItemDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">







    <!--A Design by W3layouts
Author: W3layout
Author URL: http://w3layouts.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE HTML>
<html>
<head>
<title>Bid Now</title>
<link href="cssCart/bootstrap.css" rel='stylesheet' type='text/css' />
<!-- jQuery (necessary JavaScript plugins) -->
<script type='text/javascript' src="jsCart/jquery-1.11.1.min.js"></script>
<!-- Custom Theme files -->
<link href="cssCart/style.css" rel='stylesheet' type='text/css' />
<!-- Custom Theme files -->
<!--//theme-style-->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Gretong Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<link href='//fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900' rel='stylesheet' type='text/css'>
<link href='//fonts.googleapis.com/css?family=Playfair+Display:400,700,900' rel='stylesheet' type='text/css'>
<!-- start menu -->
<link href="cssCart/megamenu.css" rel="stylesheet" type="text/css" media="all" />
<script type="text/javascript" src="jsCart/megamenu.js"></script>
<script>$(document).ready(function(){$(".megamenu").megamenu();});</script>
<script src="jsCart/menu_jquery.js"></script>
</head>
<body>
<!-- header_top -->

<!-- header -->
<div class="header_bg">
<div class="container">
	<div class="header">
	<div class="head-t">

	
		<div class="clearfix"> </div>
	</div>
		<!-- start header menu -->
			<ul class="megamenu skyblue">
			<li class="active grid"><a class="color1" href="index.html">Gingerbread</a></li>
			<li class="grid"><a class="color2" href="#">Celebrity Place</a></li>
			<li class="grid"><a class="color3" href="#">Jingle Bell Junction</a></li>
			<li class="grid"><a class="color4" href="#">Opening Night</a></li>
			<li class="grid"><a class="color5" href="#">Designer Items</a></li>
			
					
   
				
		 </ul> 
	</div>
</div>
</div>
<!-- content -->
<div class="container">
<div class="women_main">
	<!-- start content -->
			<div class="row single">
				<div class="col-md-9 det">
				  <div class="single_left">
					<div class="grid images_3_of_2">
						<div class="flexslider">
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

							  <ul class="slides">
								<li data-thumb="AutionItemImages/d1.jpg">
									<div class="thumb-image" id="ImagesDiv" runat="server">  </div>
								</li>
								
							  </ul>
							<div class="clearfix"></div>
						</div>
					</div>
				  <div class="desc1 span_3_of_2">
					<h3>Item Number:<asp:Label ID="Label1" runat="server" Text=""></asp:Label></h3>
					<span class="brand">Category: <asp:Label ID="Label2" runat="server" Text=""></asp:Label> </span>
					<br>
					
					<span class="brand">Item description: <asp:Label ID="Label3" runat="server" Text=""></asp:Label></span><br />
					<span class="brand">Designer:<asp:Label ID="Label4" runat="server" Text=""></asp:Label></span>
						<div class="price">
							<span class="text">Min Bid:</span>
							<span class="price-new" id="minBid" runat="server"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></span>Current Max. Bid Value:<span class="price-old"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></span> 
							
							<br>
						</div>
					
					<div class="btn_form">
                        <asp:LinkButton ID="LinkButton1" OnClientClick="window.open('BidSheet.aspx', 'OtherPage','left=20,top=20,width=685,height=500');"
                             CssClass="btn btn-success" runat="server">Bid</asp:LinkButton>
					</div>
					
					
			   	 </div>
          	    <div class="clearfix"></div>
          	   </div>
          	   
				
	       </div>	

		   <div class="clearfix"></div>		
	  </div>
	<!-- end content -->
</div>
</div>
<div class="foot-top">
	<div class="container">
		<div class="col-md-6 s-c">
			<li>
				<div class="fooll">
					<h5>follow us on</h5>
				</div>
			</li>
			<li>
				<div class="social-ic">
					<ul>
						<li><a href="#"><i class="facebok"> </i></a></li>
						<li><a href="#"><i class="twiter"> </i></a></li>
						<li><a href="#"><i class="goog"> </i></a></li>
						<li><a href="#"><i class="be"> </i></a></li>
						<li><a href="#"><i class="pp"> </i></a></li>
							<div class="clearfix"></div>	
					</ul>
				</div>
			</li>
				<div class="clearfix"> </div>
		</div>
		<div class="col-md-6 s-c">
			<div class="stay">
						<div class="stay-left">
							<form>
								<input type="text" placeholder="Enter your email to join our newsletter" required="">
							</form>
						</div>
						<div class="btn-1">
							<form>
								<input type="submit" value="join">
							</form>
						</div>
							<div class="clearfix"> </div>
			</div>
		</div>
			<div class="clearfix"> </div>
	</div>
</div>

</body>
</html>










</asp:Content>
