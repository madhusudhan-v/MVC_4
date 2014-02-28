using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name:"",
            //    url: "{controller}",
            //    defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            //    );
            routes.MapRoute(
                name: "googly",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Subject", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}