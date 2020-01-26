using Minesweeper_Web_App.Models;
using Minesweeper_Web_App.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minesweeper_Web_App.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginUser user)
        {
            //Call the Security Business Service Authenticate() method from the Login() method
            //and save the results of the method call in a local method variable

            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(user);

            if (success)
            {
                return View("LoginSuccess", user);
            }

            else
            {
                return View("LoginFailed");
            }
        }
    }
}