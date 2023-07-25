<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebApplication1.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="signupform" runat="server">
        <div>
            <label for="username" class="form-label">Enter username: </label>
            <input id="username" type="text" name="username" placeholder="username" required="required" />
        
            <label for="password" class="form-label">Enter Password: </label>
            <input id="password" type="password" name="password" placeholder="password" required="required" />

            <label for="email" class="form-label">Enter Email: </label>
            <input if="email" type="text" name="email" placeholder="abc@xyz.com" required="required" /> 
        
            <label for="confirmpassword" class="form-label">Confirm Password: </label>
            <input id="confirmpassword" type="password" name="confirmpassword" placeholder="confirmpassword" required="required" />
        
            <label for="firstname" class="form-label">First Name: </label>
            <input id="firstname" type="text" name="firstname" placeholder="firstname" required="required" />
        
            <label for="lastname" class="form-label">Last Name: </label>
            <input id="lastname" type="text" name="lastname" placeholder="lastname" required="required" />
        </div>
        <br />
        <div>
            <asp:button type="submit" runat="server" OnClick="OnClickSignup" Text="SignUp"></asp:button>
        </div>
        <br />
        <div>
            <asp:Label ID="errorMessageLabel" runat="server" Text="" style="color:red; font-weight:bold" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
