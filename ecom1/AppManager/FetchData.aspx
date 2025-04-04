<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FetchData.aspx.cs" Inherits="HamtruyenAdmin.FetchData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
   <meta content="" name="description" />
   <meta content="" name="author" />
    
    <script src= "http://ajax.googleapis.com/ajax/libs/angularjs/1.3.14/angular.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        Key : <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
            </div>
        <div>
            Page : <asp:TextBox ID="txtPage" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
        <div id="kid" runat="server"></div>
        </form>
</body>
</html>
