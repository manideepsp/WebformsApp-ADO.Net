using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using System.Threading;

namespace WebApplication1
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        User user = new User();
        string maskedEmail = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnClickSubmit(object sender, EventArgs e)
        {
            user.UserName = Request.Form["username"];
            Session["maskedEmail"] = Backend.GetDetails.GetMaskedEmail(user.UserName);
            Response.Redirect("")
        }
            
            if (maskedEmail != null)
            {
                youremaillabel.Text = $@"{maskedEmail}, confirm your email: ";
                youremaillabel.Visible = true;
            }
            else
            {
                youremaillabel.Text = "Username Doesnot exist";
                Response.Redirect("Default.apsx");
            }

            user.Email = Request.Form["email"];
            if (maskedEmail == user.Email)
            {
                otplabel.Visible = true;
            }
            string otp = Request.Form["otp"], defaultOtp = "0000";
            if (otp.Equals(defaultOtp))
            {
                Response.Redirect("Dashboard.aspx", false);
            }
            else
            {
                otpresultlabel.Text = "Wrong Otp";
                otpresultlabel.Visible = true;
                Thread.Sleep(5000);
                Response.Redirect("ForgotPassword.aspx");
            }
            user.Password = Request.Form["password"];
            user.ConfirmPassword = Request.Form["confirmpassword"];

            Backend.ChangeParameter changeParameter = new Backend.ChangeParameter();
            if (user.Password == user.ConfirmPassword)
            {
                if (changeParameter.ChangePassword(user))
                {
                    Response.Redirect("Dashboard.aspx", false);
                }
                else
                {
                    errorMessageLabel.Text = "Passwords doesnot match. Try again.";
                    errorMessageLabel.Visible = true;
                    Response.Redirect("ForgotPassword.aspx");
                }
            }
        }
    }

    //public class temp
    //{
    //    public void method()
    //    {
    //        user.UserName = Request.Form["username"];
    //        maskedEmail = Backend.GetDetails.GetMaskedEmail(user.UserName);
    //        if (maskedEmail != null)
    //        {
    //            youremaillabel.Text = $@"{maskedEmail}, confirm your email: ";
    //            youremaillabel.Visible = true;
    //        }
    //        else
    //        {
    //            youremaillabel.Text = "Username Doesnot exist";
    //            Response.Redirect("Default.apsx");
    //        }

    //        user.Email = Request.Form["email"];
    //        if (maskedEmail == user.Email)
    //        {
    //            otplabel.Visible = true;
    //        }
    //        string otp = Request.Form["otp"], defaultOtp = "0000";
    //        if (otp.Equals(defaultOtp))
    //        {
    //            Response.Redirect("Dashboard.aspx", false);
    //        }
    //        else
    //        {
    //            otpresultlabel.Text = "Wrong Otp";
    //            otpresultlabel.Visible = true;
    //            Thread.Sleep(5000);
    //            Response.Redirect("ForgotPassword.aspx");
    //        }
    //        user.Password = Request.Form["password"];
    //        user.ConfirmPassword = Request.Form["confirmpassword"];

    //        Backend.ChangeParameter changeParameter = new Backend.ChangeParameter();
    //        if (user.Password == user.ConfirmPassword)
    //        {
    //            if (changeParameter.ChangePassword(user))
    //            {
    //                Response.Redirect("Dashboard.aspx", false);
    //            }
    //            else
    //            {
    //                errorMessageLabel.Text = "Passwords doesnot match. Try again.";
    //                errorMessageLabel.Visible = true;
    //                Response.Redirect("ForgotPassword.aspx");
    //            }
    //        }
    //    }
    //}
}