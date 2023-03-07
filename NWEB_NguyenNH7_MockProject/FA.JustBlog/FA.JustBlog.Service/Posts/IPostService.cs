using FA.JustBlog.ViewModels.Categories;
using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.Posts
{
    public interface IPostService
    {
        IEnumerable<PostViewModel> GetAll();

        IEnumerable<PostViewModel> Search(string search, string userId);

        IEnumerable<PostViewModel> Search(string search);

        ResponseResult CreatePostViewModel(CreatePostViewModel request, string userId);

        ResponseResult EditPostViewModel(EditPostViewModel request, string userId);

        ResponseResult DeletePostViewModel(int id);

        PostDetailViewModel GetPostByTitle(string url);

        DeletePostViewModel GetPostById(int id);
    }
}