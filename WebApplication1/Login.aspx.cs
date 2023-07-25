using System;
using System.Web;
using DTO;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorMessageLabel.Text = string.Empty;
            errorMessageLabel.Visible = false;
        }
        protected void OnClickLogin(object sender, EventArgs e)
        {
            User user = new User();
            user.UserName = Request.Form["username"];
            user.Password = Request.Form["password"];

            Backend.Login login = new Backend.Login();
            bool response = login.LoginUser(user);

            if (response)
            {
                Response.Redirect("Dashboard.aspx", false);
            }
            else
            {
                errorMessageLabel.Text = "Login Failed.";
                errorMessageLabel.Visible = true;
            }

            // sets Cacheability of the webpage to no cache to prevent users to simply navigate back to login page from dashboard by using back and forward arrows
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }
    }
}