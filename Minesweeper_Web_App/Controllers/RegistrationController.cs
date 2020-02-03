using Minesweeper_Web_App.Models;
using Minesweeper_Web_App.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minesweeper_Web_App.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View("RegistrationPage");
        }

        
        [HttpPost]
        public ActionResult Registration(UserModel user)
        {
            RegistrationService registrationService = new RegistrationService();
            Boolean success = registrationService.Create(user);

            if (success)
            {
                return View("RegistrationSuccess", user);
            }

            else
            {
                return View("RegistrationFailure");
            }
        }
        public string alreadyRegistered()
        {
            return "Hello World";
        }
    }
}