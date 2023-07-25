<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>
<%@ OutputCache Location="None" NoStore="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="loginform" runat="server" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">
        <div>
            <label for="username" class="form-label">Enter username: </label>
            <input id="username" type="text" name="username" placeholder="username" required="required" />
        </div>
        <br />
        <div>
            <label for="password" class="form-label">Enter Password: </label>
            <input id="password" type="password" name="password" placeholder="password" required="required" />
        </div>
        <br />
        <div>
            <asp:button runat="server" OnClick="OnClickLogin" Text="Login"></asp:button>
        </div>
        <br />
        <div>
            <asp:Label ID="errorMessageLabel" runat="server" Text="" style="color:red; font-weight:bold" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
