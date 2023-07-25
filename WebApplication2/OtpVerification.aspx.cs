using System;


namespace WebApplication2
{
    public partial class OtpVerification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
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