using System;

namespace WebApplication2
{
    /// <inheritdoc/>
    /// <seealso cref="System.Web.UI.Page"/>
    public partial class FPEmailVerification : System.Web.UI.Page
    {
        /// <summary>
        /// Page load.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = Session["maskedEmail"].ToString();
            youremaillabel.Text = $@"{str} Confirm ths email to recieve otp: ";
        }

        /// <summary>
        /// Ons a click submit.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        protected void OnClickSubmit(object sender, EventArgs e)
        {
            if (Session["email"].ToString() == Request.Form["email"])
            {
                Response.Redirect("OtpVerification.aspx");
            }
            else
            {
                errorMessageLabel.Text = "email you entered is wrong";
                Response.Redirect("FPEmailVerification.aspx");
            }
        }
    }
}