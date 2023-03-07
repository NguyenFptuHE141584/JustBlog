using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FA.JustBlog.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "Get Post By Title",
             url: "Post/GetPostByTitle/{url}",
             defaults: new { Controller = "Post", Action = "GetPostByTitle" },
             namespaces: new string[] { "FA.JustBlog.Web.Controllers" }
             );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "FA.JustBlog.Web.Controllers" }

            );
        }
    }
}