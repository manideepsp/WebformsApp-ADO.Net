<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebApplication2.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>
    <link href="CustomCss/Custom.css" rel="stylesheet" />
</head>
<body>
    <div class="navbar navbar-dark bg-dark">
        <a href="#" class="navbar-brand">Your Website</a>
        <ul class="navbar-links">
            <li><a href="Login.aspx">Login</a></li>
            <li><a href="Signup.aspx">Signup</a></li>
        </ul>
    </div>
    <div class="container">
        <form id="signupform" runat="server">
            <div>
                <label for="firstname" class="form-label">First Name: </label>
                <input id="firstname" type="text" name="firstname" placeholder="firstname" required="required" class="form-input"/>
        
                <label for="lastname" class="form-label">Last Name: </label>
                <input id="lastname" type="text" name="lastname" placeholder="lastname" required="required" class="form-input" />

                <label for="username" class="form-label">Enter username: </label>
                <input id="username" type="text" name="username" placeholder="username" required="required" class="form-input"/>
        
                <label for="password" class="form-label">Enter Password: </label>
                <input id="password" type="password" name="password" placeholder="password" required="required" class="form-input" />

                <label for="confirmpassword" class="form-label">Confirm Password: </label>
                <input id="confirmpassword" type="password" name="confirmpassword" placeholder="confirmpassword" required="required" class="form-input"/>

                <label for="email" class="form-label">Enter Email: </label>
                <input if="email" type="text" name="email" placeholder="abc@xyz.com" required="required" class="form-input"/> 
            </div>
            <br />
            <div>
                <asp:Label ID="errorMessageLabel" runat="server" Text="" style="color:red; font-weight:bold" Visible="false"></asp:Label>
            </div>
            <br />
            <div>
                <asp:button type="submit" runat="server" OnClick="OnClickSignup" Text="SignUp" CssClass="btn-primary"></asp:button>
            </div>
        </form>
    </div>
</body>
</html>
