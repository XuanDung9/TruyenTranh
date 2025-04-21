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
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>

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
        <uc1:wucHeaderAdmin runat="server" ID="wucHeaderAdmin" />
        <div id="container" class="row-fluid">
            <uc2:wucSideBarAdmin runat="server" ID="wucSideBarAdmin" />
            <div id="main-content">
                <div class="container-fluid">
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
                    <div class="row-fluid" id="main_content" runat="server">
                    </div>
                </div>
            </div>
        </div>
        <div id="footer">
            2013 &copy; Admin Hamtruyen.com
        </div>

        <script type="text/javascript" src="assets/gritter/js/jquery.gritter.js"></script>
        <script type="text/javascript" src="js/jquery.pulsate.min.js"></script>
        <script src="js/common-scripts.js"></script>
    </form>
</body>

</html>
