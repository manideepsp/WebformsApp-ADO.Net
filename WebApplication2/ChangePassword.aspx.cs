using System;
using DTO;

namespace WebApplication2
{
    /// <inheritdoc/>
    /// <seealso cref="System.Web.UI.Page"/>
    public partial class ChangePassword : System.Web.UI.Page
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
        /// Ons a click submit.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        protected void OnClickSubmit(object sender, EventArgs e)
        {
            if (Request.Form["password"] == Request.Form["confirmpassword"])
            {
                User user = new User();
                user.UserName = Session["username"].ToString();
                user.Password = Request.Form["password"].ToString();

                Backend.ChangeParameter changeParameter = new Backend.ChangeParameter();
                changeParameter.ChangePassword(user);
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}