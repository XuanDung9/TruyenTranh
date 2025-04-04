<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HamtruyenAdmin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
   <title>Login To Administrator</title>
   <meta content="width=device-width, initial-scale=1.0" name="viewport" />
   <meta content="" name="description" />
   <meta content="" name="author" />
   <link href="/assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
   <link href="/assets/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" />
   <link href="/assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
   <link href="/css/style.css" rel="stylesheet" />
   <link href="/css/style-responsive.css" rel="stylesheet" />
   <link href="/css/style-default.css" rel="stylesheet" id="style_color" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="lock-header">
        <!-- BEGIN LOGO -->
        <a class="center" id="logo" style="font: normal 60px MyriadPro-Light;color: #eee;" href="http://hamtruyen.com">
            App Content Administrator
        </a>
        <!-- END LOGO -->
    </div>
    <div class="login-wrap">
        <div class="metro single-size red">
            <div class="locked">
                <i class="icon-lock"></i>
                <span>Login</span>
            </div>
        </div>
        <div class="metro double-size green">
            
                <div class="input-append lock-input">
                    <input id="txtUserName" runat="server" type="text" class="" placeholder="Username"/>
                </div>
            
        </div>
        <div class="metro double-size yellow">
            
                <div class="input-append lock-input">
                    <input id="txtPassword" runat="server" type="password" class="" placeholder="Password"/>
                </div>
        </div>
        <div class="metro single-size terques login">
            <asp:LinkButton ID="LinkButton1" CssClass="btn login-btn" runat="server" OnClick="LinkButton1_Click">
                 Login
                    <i class=" icon-long-arrow-right"></i>
            </asp:LinkButton>
        </div>
        <div class="forgot-hint pull-right">
                <a id="check" runat="server"></a>
            </div>
        
    </div>
    </form>
</body>
</html>
