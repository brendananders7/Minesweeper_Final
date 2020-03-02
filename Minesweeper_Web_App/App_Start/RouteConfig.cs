using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Minesweeper_Web_App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Registration Page Route
            routes.MapRoute(
                name: "Registration",
                url: "Registration",
                defaults: new {controller = "Registration", action = "Index", id = UrlParameter.Optional}
                );

            //Login Page Route
            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
                );
            
            //Home Page Route
            routes.MapRoute(
                name: "Home",
                url: "Home",
                defaults: new { controller = "HomePage", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Minesweeper",
                url: "Minesweeper",
                defaults: new { controller = "Game", action = "BuildGame", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Minesweeper",
                url: "Minesweeper",
                defaults: new { controller = "Game", action = "BuildGame", id = UrlParameter.Optional }
            );

            //Default Route
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HomePage", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
