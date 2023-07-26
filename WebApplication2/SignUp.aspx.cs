using BLL;
using DTO;
using System;

namespace WebApplication2
{
    /// <inheritdoc/>
    /// <seealso cref="System.Web.UI.Page"/>
    public partial class SignUp : System.Web.UI.Page
    {
        /// <summary>
        /// Page load.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ons a click signup.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns></returns>
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