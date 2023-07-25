<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>
<%@ OutputCache Location="None" NoStore="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="CustomCss/Custom.css" rel="stylesheet" />
</head>
<body>
    <div class="navbar navbar-dark bg-dark">
        <a href="Default.aspx" class="navbar-brand">Your Website</a>
    </div>
    <div class="container">
        <form id="loginform" runat="server">
            <div>
                <label for="username" class="form-label">Enter username: </label>
                <input id="username" type="text" name="username" placeholder="username" required="required" class="form-input"/>
            </div>
            <br />
            <div>
                <label for="password" class="form-label">Enter Password: </label>
                <input id="password" type="password" name="password" placeholder="password" required="required" class="form-input"/>
            </div>
            <br />
            <div>
                <asp:button runat="server" OnClick="OnClickLogin" Text="Login" CssClass="btn-primary"></asp:button>
            </div>
            <br />
            <div>
                <asp:Label ID="errorMessageLabel" runat="server" Text="" style="color:red; font-weight:bold" Visible="true"></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>
