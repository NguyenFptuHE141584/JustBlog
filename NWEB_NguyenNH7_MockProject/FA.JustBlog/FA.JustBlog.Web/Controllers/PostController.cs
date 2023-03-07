using FA.JustBlog.Service.Posts;
using FA.JustBlog.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public ActionResult GetPostByTitle(string url)
        {
            ViewBag.Title = "GetPostByTitle";
            return View(this.postService.GetPostByTitle(url));
        }
    }
}