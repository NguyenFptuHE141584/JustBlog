using FA.JustBlog.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class ManageController : Controller
    {
        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}