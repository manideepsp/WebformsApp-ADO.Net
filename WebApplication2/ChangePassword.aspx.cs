using System;
using DTO;

namespace WebApplication2
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
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