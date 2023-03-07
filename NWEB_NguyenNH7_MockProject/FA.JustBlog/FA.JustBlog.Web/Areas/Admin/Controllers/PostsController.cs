using FA.JustBlog.Core;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Service.Posts;
using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.Web.Filters;
using Microsoft.AspNet.Identity;
using PagedList;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private JustBlogContext db = new JustBlogContext();

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Index(string search, int? i)
        {
            var userId = User.Identity.GetUserId();
            return View(this.postService.Search(search, userId).ToList().ToPagedList(i ?? 1, 3));
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Name");
            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreatePostViewModel request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Name", request.CategoryId);
                return View(request);
            }
            var userId = User.Identity.GetUserId();
            var response = this.postService.CreatePostViewModel(request, userId);
            if (response.IsSuccessed)
            {
                TempData["Message"] = "Create success";
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(request);
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            var editPostViewModel = new EditPostViewModel()
            {
                Title = post.Title,
                PostContent = post.PostContent,
                PostedOn = post.PostedOn,
                ShortDescription = post.ShortDescription,
                UrlSlug = post.UrlSlug,
                Published = post.Published,
            };
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Name", post.CategoryId);
            return View(editPostViewModel);
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EditPostViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var userId = User.Identity.GetUserId();
            var response = this.postService.EditPostViewModel(request, userId);
            if (response.IsSuccessed)
            {
                TempData["Message"] = "Edit success";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "Name", request.CategoryId);
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(request);
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Delete(int id = -1)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeletePostViewModel deletePostViewModel = this.postService.GetPostById(id);

            if (deletePostViewModel == null)
            {
                return HttpNotFound();
            }
            return View(deletePostViewModel);
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(int id)
        {
            var response = this.postService.DeletePostViewModel(id);
            if (response.IsSuccessed)
            {
                TempData["Message"] = "Delete success";
                return RedirectToAction(nameof(Index));
            }
            return View(TempData["Message"] = "Delete Faild");
        }
    }
}