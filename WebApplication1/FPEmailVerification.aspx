<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FPEmailVerification.aspx.cs" Inherits="WebApplication1.FPEmailVerification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verify Your Email</title>
    <link href="CustomCss/Custom.css" rel="stylesheet" />

</head>
<body>
    <form id="FPEmailVerificationForm" runat="server">
        <div>
            <asp:Label ID="youremaillabel" runat="server" Text="" Visible="True" class="form-label"></asp:Label>
            <input id="email" type="text" name="email" class="form-input" placeholder="Confirm your email." required="required" />
            <asp:Button runat="server" type="submit" OnClick="OnClickSubmit" Text="Login" CssClass="btn-primary"></asp:Button>
            <asp:Label ID="errorMessageLabel" runat="server" Text="" class="error-message" Visible="true"></asp:Label>
        </div>
    </form>
</body>
</html>
