<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FPOtpVerificaton.aspx.cs" Inherits="WebApplication1.FPOtpVerificaton" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verify Otp</title>
    <link href="CustomCss/Custom.css" rel="stylesheet" />

</head>
<body>
    <form id="FPOtpVerificationForm" runat="server">
        <div>
            <asp:Label ID="otplabel" runat="server" Text="" Visible="true" class="form-label"></asp:Label>
            <input id="otp" type="text" name="otp" class="form-input" placeholder="Default: 0000" required="required" />
            <asp:Label ID="otpresultlabel" runat="server" Text="" Visible="true" class="error-message"></asp:Label>
            <asp:Button runat="server" type="submit" OnClick="OnClickSubmit" Text="Login" CssClass="btn-primary"></asp:Button>
            <asp:Label ID="errorMessageLabel" runat="server" Text="" class="error-message" Visible="true"></asp:Label>
        </div>
    </form>
</body>
</html>
