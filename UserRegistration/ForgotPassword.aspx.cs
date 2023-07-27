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
        protected void Page_Load(object sender, EventArgs e){}

        /// <summary>
        /// Ons a click submit.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        protected void OnClickSubmit(object sender, EventArgs e)
        {
            BLL.BLLFactory factory = new BLL.BLLFactory();
            BLL.IDetails emailDetails = factory.GetEmailDetails();

            Session["username"] = Request.Form["username"].ToLower();
            Session["maskedEmail"] = emailDetails.GetDetails(Session["username"].ToString(), "maskedemail");
            Session["email"] = emailDetails.GetDetails(Session["username"].ToString(), "email");

            Response.Redirect("FPEmailVerification.aspx");
        }
    }
}