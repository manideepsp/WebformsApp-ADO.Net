using DTO;
using System;
using System.Web;

namespace WebApplication2
{
    /// <inheritdoc/>
    /// <seealso cref="System.Web.UI.Page"/>
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// Page load.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            errorMessageLabel.Text = string.Empty;
            errorMessageLabel.Visible = false;
        }

        /// <summary>
        /// Ons a click login.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        protected void OnClickLogin(object sender, EventArgs e)
        {
            User user = new User();
            user.UserName = Request.Form["username"];
            user.Password = Request.Form["password"];

            BLL.Login login = new BLL.Login();
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