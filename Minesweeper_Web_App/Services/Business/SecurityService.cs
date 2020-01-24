using Minesweeper_Web_App.Models;
using Minesweeper_Web_App.Services.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper_Web_App.Services.Business
{
    public class SecurityService
    {
        public bool Authenticate(UserModel user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.FindByUser(user);
        }
    }
}