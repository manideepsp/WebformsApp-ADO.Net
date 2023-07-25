<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OtpVerification.aspx.cs" Inherits="WebApplication2.OtpVerification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verify Otp</title>
    <link href="CustomCss/Custom.css" rel="stylesheet" />

</head>
<body>
    <form id="OtpVerificationForm" runat="server">
        <div>
            <asp:Label ID="otplabel" runat="server" Text="" Visible="true" class="form-label">Enter Otp you have recieved to your email: </asp:Label>
            <input id="otp" type="text" name="otp" class="form-input" placeholder="Default: 0000" required="required" />
            <asp:Button runat="server" type="submit" OnClick="OnClickSubmit" Text="Login" CssClass="btn-primary"></asp:Button>
            <asp:Label ID="errorMessageLabel" runat="server" Text="" class="error-message" Visible="true"></asp:Label>
        </div>
    </form>
</body>
</html>
