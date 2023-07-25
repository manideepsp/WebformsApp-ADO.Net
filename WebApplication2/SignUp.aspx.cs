using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DTO;
using Backend;

namespace WebApplication2
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OnClickSignup(object sender, EventArgs e)
        {
            User user = new User();
            user.UserName = Request.Form["username"];
            user.Password = Request.Form["password"];
            user.FirstName = Request.Form["firstname"];
            user.LastName = Request.Form["lastname"];
            user.ConfirmPassword = Request.Form["confirmpassword"];
            user.Email = Request.Form["email"];

            Register register = new Register();
            bool response = register.RegisterUser(user);
            if (response)
            {
                Response.Redirect("Dashboard.aspx", false);
            }
            else
            {
                errorMessageLabel.Text = "Could not register user.";
                errorMessageLabel.Visible = true;
            }
        }
    }
}