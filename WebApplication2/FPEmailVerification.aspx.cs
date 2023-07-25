using System;
using DTO;

namespace WebApplication2
{
    public partial class FPEmailVerification : System.Web.UI.Page
    {
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = Session["maskedEmail"].ToString();
            youremaillabel.Text = $@"{str} Confirm ths email to recieve otp: ";
        }
        protected void OnClickSubmit(object sender, EventArgs e)
        {
            if(Session["email"].ToString() == Request.Form["email"])
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