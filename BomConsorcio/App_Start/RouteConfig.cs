using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BomConsorcio
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "/Dashboard",
                "Dashboard",
                new { controller = "Home", action = "Dashboard" }
            );


            routes.MapRoute(
                "/Clientes",
                "Clientes",
                new { controller = "Clientes", action = "Index" }
            );

            routes.MapRoute(
                "/Portes",
                "Portes",
                new { controller = "Portes", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Dashboard", id = UrlParameter.Optional }
            );

        }
    }
}
