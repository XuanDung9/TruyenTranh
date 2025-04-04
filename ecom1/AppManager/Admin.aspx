<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Admin.aspx.cs" Inherits="HamtruyenAdmin.Admin" %>

<%@ Register Src="~/wucHeaderAdmin.ascx" TagPrefix="uc1" TagName="wucHeaderAdmin" %>
<%@ Register Src="~/wucSideBarAdmin.ascx" TagPrefix="uc2" TagName="wucSideBarAdmin" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
   <title>Admin</title>
   <meta content="width=device-width, initial-scale=1.0" name="viewport" />
   <meta content="" name="description" />
   <meta content="" name="author" />
   <link href="<%=ResolveUrl("~/assets/bootstrap/css/bootstrap.min.css") %>" rel="stylesheet" />
   <link href="<%=ResolveUrl("~/assets/bootstrap/css/bootstrap-responsive.min.css") %>" rel="stylesheet" />
   <link href="/assets/bootstrap/css/bootstrap-fileupload.css" rel="stylesheet" />
   <link href="/assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
   <link href="/Css/style.css" rel="stylesheet" />
   <link href="/Css/style-responsive.css" rel="stylesheet" />
   <link href="/Css/style-default.css" rel="stylesheet" id="style_color" />
   <link rel="stylesheet" type="text/css" href="/assets/gritter/css/jquery.gritter.css" />
    <script src="js/jquery-1.8.3.min.js"></script>
    <script src="js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="assets/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
</head>
<body class="fixed-top">
    <form id="form_1" runat="server">
        <uc1:wucHeaderAdmin runat="server" id="wucHeaderAdmin" />
   <!-- BEGIN CONTAINER -->
   <div id="container" class="row-fluid">
       <uc2:wucSideBarAdmin runat="server" id="wucSideBarAdmin" />
      <!-- BEGIN PAGE -->  
      <div id="main-content">
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
            <!-- BEGIN THEME CUSTOMIZER-->
            <div id="theme-change" class="hidden-phone">
                <i class="icon-cogs"></i>
                <span class="settings">
                    <span class="text">Theme Color:</span>
                    <span class="colors">
                        <span class="color-default" data-style="default"></span>
                        <span class="color-green" data-style="green"></span>
                        <span class="color-gray" data-style="gray"></span>
                        <span class="color-purple" data-style="purple"></span>
                        <span class="color-red" data-style="red"></span>
                    </span>
                </span>
            </div>
            <!-- END THEME CUSTOMIZER-->
            <!-- BEGIN PAGE CONTENT-->
            
            <div class="row-fluid" id="main_content" runat="server">
                
            </div>
          
            <!-- END PAGE CONTENT-->         
         </div>
         <!-- END PAGE CONTAINER-->
      </div>
      <!-- END PAGE -->  
   </div>
   <!-- END CONTAINER -->

   <!-- BEGIN FOOTER -->
   <div id="footer">
       2013 &copy; Admin Hamtruyen.com
   </div>
   <!-- END FOOTER -->

   <!-- BEGIN JAVASCRIPTS -->
   <!-- Load javascripts at bottom, this will reduce page load time -->
   

   <!-- ie8 fixes -->
   <!--[if lt IE 9]>
   <script src="js/excanvas.js"></script>
   <script src="js/respond.js"></script>
   <![endif]-->

   <script type="text/javascript" src="assets/gritter/js/jquery.gritter.js"></script>
   <script type="text/javascript" src="js/jquery.pulsate.min.js"></script>


   <!--common script for all pages-->
   <script src="js/common-scripts.js"></script>



   <!-- END JAVASCRIPTS -->
        </form>
</body>
    
</html>
