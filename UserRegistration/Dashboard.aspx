<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebApplication2.Dashboard" %>
<%@ OutputCache Location="None" NoStore="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Dashboard</title>
    <link href="CustomCss/Custom.css" rel="stylesheet" />
</head>
<body>
    <div class="navbar navbar-dark bg-dark">
        <a href="#" class="navbar-brand">Your Website</a>
    </div>
    <div class="container">
        <form id="form1" runat="server">
            <div>
                <h1>Success</h1>
            </div>
            <div class="redirect-buttons">
                <asp:Button Text="Logout" CssClass="btn-primary" runat="server" OnClick="OnClickLogout" />
            </div>
        </form>
    </div>
</body>
</html>
