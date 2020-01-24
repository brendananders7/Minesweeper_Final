using Minesweeper_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper_Web_App.Services.Business.Data
{
    public class SecurityDAO
    {
        public bool FindByUser(UserModel user)
        {
            if (user.Username == "Admin" && user.Password == "secret")
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}