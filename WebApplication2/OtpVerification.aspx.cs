using System;


namespace WebApplication2
{
    /// <inheritdoc/>
    /// <seealso cref="System.Web.UI.Page"/>
    public partial class OtpVerification : System.Web.UI.Page
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
            if (Request.Form["otp"].ToString() == "0000")
            {
                Response.Redirect("ChangePassword.aspx");
            }
            else
            {
                errorMessageLabel.Text = "Enter correct otp";
                Response.Redirect("OtpVerification.aspx");
            }
        }
    }
}