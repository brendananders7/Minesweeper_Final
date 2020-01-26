using Minesweeper_Web_App.Models;
using Minesweeper_Web_App.Services.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper_Web_App.Services.Business
{
    public class RegistrationService
    {
        public bool Create(UserModel user)
        {
            RegisterDAO service = new RegisterDAO();
            return service.AddByUser(user);
        }

    }
}