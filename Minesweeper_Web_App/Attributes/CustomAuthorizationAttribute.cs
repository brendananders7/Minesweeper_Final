using Minesweeper_Web_App.Models;
using Minesweeper_Web_App.Services.Business;
using System;
using System.Web.Mvc;

namespace Minesweeper_Web_App.Controllers
{
    internal class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            SecurityService securityService = new SecurityService();
            //get the user from a session variable
            LoginUser user = (LoginUser) filterContext.HttpContext.Session["user"];

            bool success = false;

            if (user != null)
            {
                success = securityService.Authenticate(user);
            }

            if(success)
            {
                //do nothing. Logged in successfully!
            }
            else
            {
                filterContext.Result = new RedirectResult("/login");
            }
        }
    }
}