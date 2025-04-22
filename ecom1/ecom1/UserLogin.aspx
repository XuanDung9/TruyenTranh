<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="ecom1.UserLogin" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Login / Signup</title>
    <link href="https://fonts.googleapis.com/css2?family=Jost:wght@500&display=swap" rel="stylesheet">
    <style>
        body {
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            font-family: 'Jost', sans-serif;
            background: linear-gradient(to bottom, #0f0c29, #302b63, #24243e);
        }

        .main {
            width: 350px;
            height: 500px;
            background: url("https://yourimageurl.com/image.jpg") no-repeat center/cover;
            border-radius: 10px;
            box-shadow: 5px 20px 50px #000;
            position: relative;
            overflow: hidden;
        }

        #chk {
            display: none;
        }

        .signup, .login {
            position: absolute;
            width: 100%;
            height: 100%;
            transition: .6s;
            padding-top: 40px;
        }

        label {
            color: #fff;
            font-size: 2em;
            justify-content: center;
            display: flex;
            margin-bottom: 20px;
            font-weight: bold;
            cursor: pointer;
        }

        .aspTextBox, .aspButton {
            width: 60%;
            margin: 10px auto;
            display: block;
            padding: 10px;
            border-radius: 5px;
            border: none;
            outline: none;
        }

        .aspButton {
            background: #573b8a;
            color: #fff;
            font-weight: bold;
            cursor: pointer;
        }

        .aspButton:hover {
            background: #6d44b8;
        }

        .login {
            background: #eee;
            border-radius: 60% / 10%;
            transform: translateY(100%);
        }

        .login label {
            color: #573b8a;
        }

        #chk:checked ~ .signup {
            transform: translateY(-100%);
        }

        #chk:checked ~ .login {
            transform: translateY(0);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <input type="checkbox" id="chk" aria-hidden="true" />
                       <!-- LOGIN -->
            <div class="login">
                <label for="chk" aria-hidden="true">Login</label>
                <asp:TextBox ID="txtInputEmail" runat="server" CssClass="aspTextBox" TextMode="Email" placeholder="Email"></asp:TextBox>
                <asp:TextBox ID="txtInputPassword" runat="server" CssClass="aspTextBox" TextMode="Password" placeholder="Password"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="aspButton" OnClick="btnLogin_Click" />
                <label for="chk" aria-hidden="true" style="font-size: 0.9em; margin-top: 20px;">Don't have an account? Sign up</label>
            </div>
            <!-- SIGN UP -->
            <div class="signup">
                <label for="chk" aria-hidden="true">Sign up</label>
                <asp:TextBox ID="txtFullName" runat="server" CssClass="aspTextBox" placeholder="Full Name"></asp:TextBox>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="aspTextBox" placeholder="Email"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="aspTextBox" TextMode="Password" placeholder="Password"></asp:TextBox>
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="aspButton" OnClick="btnSignUp_Click" />
                <label for="chk" aria-hidden="true" style="font-size: 0.9em; margin-top: 20px;">Already have an account? Login</label>
            </div>

 
        </div>
    </form>
</body>
</html>
