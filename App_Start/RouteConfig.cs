using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WeatherTestProj
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "TestFetch",
               url: "TestFetch",
               new { controller = "TestFetch", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Submitter",
               url: "Submitter",
               new { controller = "Submitter", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
               name: "Login",
               url: "Login",
               new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
