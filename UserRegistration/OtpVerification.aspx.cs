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
            otplabel.Text = Session["Text"].ToString();
            //Session["otp"] = BLL.Details.GetOtp(mailId);
        }

        /// <summary>
        /// Ons a click submit.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        protected void OnClickSubmit(object sender, EventArgs e)
        {
            BLL.BLLFactory factoryObject = new BLL.BLLFactory();
            BLL.IDetails details = factoryObject.GetOtpDetails();

            if (Request.Form["otp"].ToString().Trim() == details.GetDetails(Session["email"].ToString(), "otp"))
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