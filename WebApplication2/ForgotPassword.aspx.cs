using System;

namespace WebApplication2
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnClickSubmit(object sender, EventArgs e)
        {
            Session["username"] = Request.Form["username"];
            Session["maskedEmail"] = Backend.GetDetails.GetMaskedEmail(Session["username"].ToString());
            Session["email"] = Backend.GetDetails.GetEmail(Session["username"].ToString());
            Response.Redirect("FPEmailVerification.aspx");
        }  
    }
}