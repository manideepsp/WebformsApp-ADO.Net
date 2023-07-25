<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="WebApplication1.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change the PAssword</title>
    <link href="CustomCss/Custom.css" rel="stylesheet" />

</head>
<body>
    <form id="ChangePasswordForm" runat="server">
        <div>
            <label for="password" class="form-label">Enter New Password:</label>
            <input id="password" type="password" name="password" class="form-input" placeholder="Password" required="required" />
            <label for="confirmpassword" class="form-label">Confirm Password:</label>
            <input id="confirmpassword" type="password" name="confirmpassword" class="form-input" placeholder="confirm password" required="required" />
        </div>
    </form>
</body>
</html>
