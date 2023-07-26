using System;

namespace WebApplication2
{
    /// <inheritdoc/>
    /// <seealso cref="System.Web.UI.Page"/>
    public partial class ForgotPassword : System.Web.UI.Page
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
            Session["username"] = Request.Form["username"];
            Session["maskedEmail"] = BLL.Details.GetMaskedEmail(Session["username"].ToString());
            Session["email"] = BLL.Details.GetEmail(Session["username"].ToString());

            Response.Redirect("FPEmailVerification.aspx");
        }
    }
}