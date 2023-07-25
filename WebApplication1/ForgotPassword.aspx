<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="WebApplication1.ForgotPassword" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Forgot Password</title>
    <link href="CustomCss/Custom.css" rel="stylesheet" />
</head>

<body>
    <div class="container">
        <form id="forgotpasswordform" runat="server">
            <div>
                <label for="username" class="form-label">Enter Username:</label>
                <input id="username" type="text" name="username" class="form-input" placeholder="Username" required="required" />
                <asp:Button runat="server" type="submit" OnClick="OnClickSubmit" Text="Login" CssClass="btn-primary"></asp:Button>
                <asp:Label ID="errorMessageLabel" runat="server" Text="" class="error-message" Visible="true"></asp:Label>
            </div>
        </form>
    </div>
</body>
<%--<body>
    <form id="forgotpasswordform" runat="server">
        <div>
            <label for="username" class="form-label">Enter username: </label>
            <input id="username" type="text" name="username" placeholder="username" required="required" />
            <asp:Button ID="continue1" runat="server" Text="Continue" OnClick="Continue_Click" class="btn-primary" Visible="true"/>
        </div>
        <br />
        <div>
            <asp:Label ID="youremaillabel" runat="server" Text="" Visible="false"></asp:Label>
            <input id="email" type="text" name="email" placeholder="Confirm your email." required="required" />
            <asp:Button ID="continue2" runat="server" Text="Continue" OnClick="Continue_Click2" class="btn-primary" Visible="true" />
        </div>
        <br />
        <div>
            <asp:Label ID="otplabel" runat="server" Text="" Visible="false"></asp:Label>
            <input id="otp" type="text" name="otp" placeholder="default: 0000" required="required" />
            <asp:Button ID="continue3" runat="server" Text="Continue" OnClick="Continue_Click3" class="btn-primary" Visible="true" />
            <asp:Label ID="otpresultlabel" runat="server" Text="" Visible="false"></asp:Label>
        </div>
        <br />
        <div>
            <label for="password" class="form-label">Enter Password: </label>
            <input id="password" type="password" name="password" placeholder="password" required="required" />
        </div>
        <br />
        <div>
            <asp:button runat="server" type="submit" OnClick="OnClickLogin" Text="Login"></asp:button>
        </div>
        <br />
        <div>
            <asp:Label ID="errorMessageLabel" runat="server" Text="" style="color:red; font-weight:bold" Visible="false"></asp:Label>
        </div>
    </form>
</body>--%>
</html>
