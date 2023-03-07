using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
            name: "Home",
            url: "Home/Index",
            defaults: new { Controller = "Home", Action = "Index" },
            namespaces: new string[] { "FA.JustBlog.Web.Controllers" }
            );

            context.MapRoute(
             name: "Log Off Account",
             url: "Account/LogOff",
             defaults: new { Controller = "Account", Action = "LogOff" },
             namespaces: new string[] { "FA.JustBlog.Web.Controllers" }
             );

            context.MapRoute(
               "Admin_default",
               "Admin/{controller}/{action}/{id}",
               new { action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "FA.JustBlog.Web.Areas.Admin.Controllers" }
           );
        }
    }
}