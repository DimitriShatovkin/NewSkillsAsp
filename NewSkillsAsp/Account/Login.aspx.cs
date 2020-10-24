using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using NewSkillsAsp.Models;
using System.Collections.Generic;
using System.Linq;
using DataBaseLayer;

namespace NewSkillsAsp.Account
{
    public partial class Login : Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }

        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var dbContext = new NewSkillsDbContext();
                var user = dbContext.Users.Where(x => x.Email == Email.Text).Where(x => x.Password == Password.Text).First();

                switch (checkLogIn(user))
                {
                    case true:
                        Response.Redirect("/WorkSpace/UserWorkspace");
                        break;
                    case false:
                        FailureText.Text = "Неверный логин или пароль";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }

        private bool checkLogIn(User user)
        {
            if (user.Email == Email.Text && user.Password == user.Password) {
                return true;            }

            return false; 
        }
    }
}