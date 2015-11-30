<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FinalProject3.HomeUI.index" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <!-- Basic Page Needs
    ================================================== -->
    <meta charset="utf-8">
    <!--[if IE]><meta http-equiv="x-ua-compatible" content="IE=9" /><![endif]-->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Festival of Trees</title>
    <meta name="description" content="Spirit8 is a Digital agency one page template built based on bootstrap framework. This template is design by Robert Berki and coded by Jenn Pereira. It is simple, mobile responsive, perfect for portfolio and agency websites. Get this for free exclusively at ThemeForces.com">
    <meta name="keywords" content="bootstrap theme, portfolio template, digital agency, onepage, mobile responsive, spirit8, free website, free theme, themeforces themes, themeforces wordpress themes, themeforces bootstrap theme">
    <meta name="author" content="ThemeForces.com">
    
    <!-- Favicons
    ================================================== -->
    <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon">
    <link rel="apple-touch-icon" href="img/apple-touch-icon.png">
    <link rel="apple-touch-icon" sizes="72x72" href="img/apple-touch-icon-72x72.png">
    <link rel="apple-touch-icon" sizes="114x114" href="img/apple-touch-icon-114x114.png">

    <!-- Bootstrap -->
    <link rel="stylesheet" type="text/css"  href="css/bootstrap.css">
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome/css/font-awesome.css">

    <!-- Slider
    ================================================== -->
    <link href="css/owl.carousel.css" rel="stylesheet" media="screen">
    <link href="css/owl.theme.css" rel="stylesheet" media="screen">

    <!-- Stylesheet
    ================================================== -->
    <link rel="stylesheet" type="text/css"  href="css/style.css">
    <link rel="stylesheet" type="text/css" href="css/responsive.css">

    <link href='http://fonts.googleapis.com/css?family=Lato:100,300,400,700,900,100italic,300italic,400italic,700italic,900italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,700,300,600,800,400' rel='stylesheet' type='text/css'>

    <script type="text/javascript" src="js/modernizr.custom.js"></script>
	<link rel="stylesheet" type="text/css" href="css/customStyle.css">
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>
  <body>
    <!-- Navigation
    ==========================================-->
    <nav id="tf-menu" class="navbar navbar-default navbar-fixed-top">
      <div class="container">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="#">Festival of Trees</a>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
          <ul class="nav navbar-nav navbar-right">
            <li><a href="#tf-home" class="page-scroll">Home</a></li>
            <li><a href="#tf-about" class="page-scroll">About</a></li>
            <li><a href="#tf-team" class="page-scroll">Team</a></li>
            <li><a href="#tf-services" class="page-scroll">Sponsors</a></li>
			<li><a href="#tf-clients" class="page-scroll">Clients</a></li>
            <li><a href="#tf-contact" class="page-scroll">Contact</a></li>
          </ul>
        </div><!-- /.navbar-collapse -->
      </div><!-- /.container-fluid -->
    </nav>
	
	

    <!-- Home Page
    ==========================================-->
	
    <div class="fullscreen-bg container-fluid" style="position:absolute" >
	         <iframe style="margin-left:4%" width="1366" height="666" src="https://www.youtube.com/embed/LKmXAL3VEgc?autoplay=1&controls=0&loop=1&theme=dark" frameborder="0" allowfullscreen></iframe>
           
			<!--<video controls="controls" autoplay="autoplay" loop="loop" class="fullscreen-bg__video container-fluid fillWidth">
				<source src="./videos/video.3gp" >
			</video>-->
            <!--<img src="videos/video.gif" class="fullscreen-bg__video container-fluid fillWidth" style="width:1400px;height:660px">-->
	</div>
	
    <div id="tf-home" class="text-center">
		
        <div class="overlay">
		<br /><br /><br /><br /><br /><br /><br /><br /><br />
            <div class="content">
                <h1>Welcome to <strong><span class="color">Festival Of Trees</span></strong></h1>
                <p class="lead">The best place to start holidays! <strong>Make a difference</strong> with <strong>The Baby Fold</strong><br/>
				
				</p>
				
				<div class="container">
				<div class="row">
					<div class="col-sm-6">
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="../SignUp.aspx" class="btn btn-block btn-lg btn-warning" runat="server" style="color:black;font-size:2em"><span class="fa fa-user-plus"></span>Sign Up</asp:HyperLink>
					</div>
					<div class="col-sm-6">
                        <asp:HyperLink ID="HyperLink2" NavigateUrl="../SignIn.aspx" class="btn btn-block btn-lg btn-success" runat="server" style="color:black;font-size:2em"><span class="fa fa-user-secret"></span>Sign In</asp:HyperLink>
					</div>
				</div>
				</div>
				
				
				
                <a href="#tf-about" class="fa fa-angle-down page-scroll"></a>
            </div>
        </div>
    </div>

    <!-- About Us Page
    ==========================================-->
    <div id="tf-about">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <img src="img/02.jpg" class="img-responsive">
                </div>
                <div class="col-md-6">
                    <div class="about-text">
                        <div class="section-title">
                            <h4>About us</h4>
                            <h2>Some words <strong>about us</strong></h2>
                            <hr>
                            <div class="clearfix"></div>
                        </div>
                        <p class="intro">In 2015, Festival of Trees will celebrate its 22nd year as a family-centered community event.  Proceeds from the festival go toward serving the children and families of The Baby Fold.



</p>
                        <ul class="about-list">
                            <li>
                                <span class="fa fa-dot-circle-o"></span>
                                <strong>Recent Event</strong> - <em>On November 20-22nd (Opening Night on November 19), come and enjoy a venue of 7 ft and 4 ft custom-designed trees. </em>
                            </li>
                            <li>
                                <span class="fa fa-dot-circle-o"></span>
                                <strong>For you</strong> - <em>You are invited to kick-off the holiday season at the Festival of Trees! </em>
                            </li>
                            <li>
                                <span class="fa fa-dot-circle-o"></span>
                                <strong>Clients</strong> - <em>Satisfied clients thanks to our experience</em>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Team Page
    ==========================================-->
    <div id="tf-team" class="text-center">
        <div class="overlay">
            <div class="container">
                <div class="section-title center">
                    <h2>Meet <strong>our team</strong></h2>
                    <div class="line">
                        <hr>
                    </div>
                </div>

                <div id="team" class="owl-carousel owl-theme row">
                    <div class="item">
                        <div class="thumbnail">
                            <img src="img/team/01.jpg" alt="..." class="img-circle team-img">
                            <div class="caption">
                                <h3>Nikunj Ratnaparkhi</h3>
                                <p>MS-Information Systems</p>
                                <p>Do not seek to change what has come before. Seek to create that which has not.</p>
                            </div>
                        </div>
                    </div>

                    <div class="item">
                        <div class="thumbnail">
                            <img src="img/team/02.jpg" alt="..." class="img-circle team-img">
                            <div class="caption">
                                <h3>Shubhanjli Jain</h3>
                                <p>MS-Information Systems</p>
                                <p>Do not seek to change what has come before. Seek to create that which has not.</p>
                            </div>
                        </div>
                    </div>

                    <div class="item">
                        <div class="thumbnail">
                            <img src="img/team/03.jpg" alt="..." class="img-circle team-img">
                            <div class="caption">
                                <h3>Nivedita Mazumdar</h3>
                                <p>MS-Information Systems</p>
                                <p>Do not seek to change what has come before. Seek to create that which has not.</p>
                            </div>
                        </div>
                    </div>

                    <div class="item">
                        <div class="thumbnail">
                            <img src="img/team/04.jpg" alt="..." class="img-circle team-img">
                            <div class="caption">
                                <h3>Rajneesh Pandey</h3>
                                <p>MS-Information Systems</p>
                                <p>Do not seek to change what has come before. Seek to create that which has not.</p>
                            </div>
                        </div>
                    </div>

                 

                   

                   
                </div>
                
            </div>
        </div>
    </div>

    <!-- Services Section
    ==========================================-->
    <div id="tf-services" class="text-center">
        <div class="container">
            <div class="section-title center">
                <h2>Take a look at <strong>categories of our Sponsors</strong></h2>
                <div class="line">
                    <hr>
                </div>
                <div class="clearfix"></div>
                <small><em>This event is made possible through the continued support of our local businesses and friends!  Here is a list of our current 2015 sponsors!  It’s not too late to get involved!  Call Melissa Engel at 309-451-7206to be part of Festival of Trees today!</em></small>
            </div>
            <div class="space"></div>
            <div class="row">
                <div class="col-md-3 col-sm-6 service">
                    <i class="fa fa-diamond"></i>
                    <h4><strong>Diamond Level</strong></h4>
                   
                </div>

                <div class="col-md-3 col-sm-6 service">
                    <i class="fa fa-futbol-o"></i>
                    <h4><strong>Gold Level</strong></h4>
                  
                </div>

                <div class="col-md-3 col-sm-6 service">
                    <i class="fa fa-sun-o"></i>
                    <h4><strong>Silver Level</strong></h4>
                    
                </div>

                <div class="col-md-3 col-sm-6 service">
                    <i class="fa fa-circle"></i>
                    <h4><strong>Bronze Level</strong></h4>
                    
                </div>
            </div>
        </div>
    </div>

    <!-- Clients Section
    ==========================================-->
    <div id="tf-clients" class="text-center">
        <div class="overlay">
            <div class="container">

                <div class="section-title center">
                    <h2>Some of <strong>our Clients</strong></h2>
                    <div class="line">
                        <hr>
                    </div>
                </div>
                <div id="clients" class="owl-carousel owl-theme">
                    <div class="item">
                        <img src="img/client/01.jpg">
                    </div>
                    <div class="item">
                        <img src="img/client/02.jpg">
                    </div>
                    <div class="item">
                        <img src="img/client/03.jpg">
                    </div>
                    <div class="item">
                        <img src="img/client/04.jpg">
                    </div>
                    <div class="item">
                        <img src="img/client/05.jpg">
                    </div>
                    <div class="item">
                        <img src="img/client/06.jpg">
                    </div>
                    <div class="item">
                        <img src="img/client/07.jpg">
                    </div>
                </div>

            </div>
        </div>
    </div>


    <!-- Contact Section
    ==========================================-->
    <div id="tf-contact" class="text-center">
        <div class="container">

            <div class="row">
                <div class="col-md-8 col-md-offset-2">

                    <div class="section-title center">
                        <h2>Feel free to <strong>contact us</strong></h2>
                        <div class="line">
                            <hr>
                        </div>
                        <div class="clearfix"></div>
                        <small><em>The Festival is coordinated by a number of community volunteers and led by a steering committee. We have created contact forms about specific aspects of the festival so that you can direct your inquiry to the appropriate committee chair. Pick from any of the buttons below to be taken to the corresponding form.</em></small>            
                    </div>

                    <form>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Email address</label>
                                    <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Enter email">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputPassword1">Password</label>
                                    <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Message</label>
                            <textarea class="form-control" rows="3"></textarea>
                        </div>
                        
                        <button type="submit" class="btn tf-btn btn-default">Submit</button>
                    </form>

                </div>
            </div>

        </div>
    </div>

    <nav id="footer">
        <div class="container">
            <div class="pull-left fnav">
                <p>ALL RIGHTS RESERVED. © 2015 Festival of Trees <a href="https://dribbble.com/shots/1817781--FREEBIE-Spirit8-Digital-agency-one-page-template">IT485 Project</a>  <a href="http://it.illinoisstate.edu/">School of IT, Illinois State University</a></p>
            </div>
            <div class="pull-right fnav">
                <ul class="footer-social">
                    <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                    <li><a href="#"><i class="fa fa-dribbble"></i></a></li>
                    <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
                    <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                </ul>
            </div>
        </div>
    </nav>


    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.1.11.1.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script type="text/javascript" src="js/bootstrap.js"></script>
    <script type="text/javascript" src="js/SmoothScroll.js"></script>
    <script type="text/javascript" src="js/jquery.isotope.js"></script>

    <script src="js/owl.carousel.js"></script>

    <!-- Javascripts
    ================================================== -->
    <script type="text/javascript" src="js/main.js"></script>
	
	

  </body>
</html>
