using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Categories;
using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.ViewModels.Results;
using FA.JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.Posts
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ResponseResult CreatePostViewModel(CreatePostViewModel request, string userId)
        {
            try
            {
                //1. add tag vao database
                var tagIds = this.unitOfWork.TagRepository.AddTagByString(request.Tags);
                // 2. create postTag
                var postTags = new List<PostTagMap>();
                foreach (var tagId in tagIds)
                {
                    var postTag = new PostTagMap()
                    {
                        TagId = tagId
                    };
                    postTags.Add(postTag);
                }

                var post = new Post()
                {
                    Title = request.Title,
                    UrlSlug = request.UrlSlug,
                    ShortDescription = request.ShortDescription,
                    PostContent = request.PostContent,
                    CategoryId = request.CategoryId,
                    Published = DateTime.Now,
                    Modified = DateTime.Now,
                    UserId = userId,
                    PostedOn = request.PostedOn,
                    PostTagMaps = postTags
                };
                this.unitOfWork.PostRepository.Add(post);
                this.unitOfWork.SaveChanges();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public ResponseResult EditPostViewModel(EditPostViewModel request, string userId)
        {
            try
            {
                var post = new Post()
                {
                    Id = request.Id,
                    Published = request.Published,
                    UserId = userId,
                    Title = request.Title,
                    UrlSlug = request.UrlSlug,
                    ShortDescription = request.ShortDescription,
                    PostContent = request.PostContent,
                    CategoryId = request.CategoryId,
                    Modified = DateTime.Now,
                    PostedOn = request.PostedOn,
                };
                this.unitOfWork.PostRepository.Update(post);
                this.unitOfWork.SaveChanges();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public IEnumerable<PostViewModel> GetAll()
        {
            var posts = this.unitOfWork.PostRepository.GetAll();
            return Mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public PostDetailViewModel GetPostByTitle(string url)
        {
            var postExisting = this.unitOfWork.PostRepository.GetPostByUrlSlug(url);
            var tags = new List<TagViewModel>();
            foreach (var postTag in postExisting.PostTagMaps)
            {
                var tag = this.unitOfWork.TagRepository.GetById(postTag.TagId);
                tags.Add(Mapper.Map<TagViewModel>(tag));
            }
            var postDetail = new PostDetailViewModel()
            {
                Id = postExisting.Id,
                Title = postExisting.Title,
                ShortDescription = postExisting.ShortDescription,
                Published = postExisting.Published,
                PostContent = postExisting.PostContent,
                Tags = tags,
            };
            return postDetail;
        }

        public DeletePostViewModel GetPostById(int id)
        {
            var postExisting = this.unitOfWork.PostRepository.GetPostByIdHaveCateName(id);
            var tags = new List<TagViewModel>();
            foreach (var postTag in postExisting.PostTagMaps)
            {
                var tag = this.unitOfWork.TagRepository.GetById(postTag.TagId);
                tags.Add(Mapper.Map<TagViewModel>(tag));
            }
            var deletePostViewModel = new DeletePostViewModel()
            {
                Id = postExisting.Id,
                Title = postExisting.Title,
                ShortDescription = postExisting.ShortDescription,
                Published = postExisting.Published,
                PostContent = postExisting.PostContent,
                CategoryName = postExisting.Category.Name,
                Modified = postExisting.Modified,
                PostedOn = postExisting.PostedOn,
                UrlSlug = postExisting.UrlSlug,
                Tags = tags,
            };
            return deletePostViewModel;
        }

        public ResponseResult DeletePostViewModel(int id)
        {
            try
            {
                this.unitOfWork.PostRepository.Delete(id);
                this.unitOfWork.SaveChanges();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public IEnumerable<PostViewModel> Search(string search, string userId)
        {
            var postsSearch = this.unitOfWork.PostRepository.Search(search, userId);
            var postsViewModelSearch = new List<PostViewModel>();
            foreach (var item in postsSearch)
            {
                var postViewModel = new PostViewModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    CategoryName = item.Category.Name,
                    Modified = item.Modified,
                    Published = item.Published,
                    ShortDescription = item.ShortDescription,
                    UrlSlug = item.UrlSlug,
                };
                postsViewModelSearch.Add(postViewModel);
            }
            return postsViewModelSearch;
        }

        public IEnumerable<PostViewModel> Search(string search)
        {
            var postsSearch = this.unitOfWork.PostRepository.Search(search);
            var postsViewModelSearch = new List<PostViewModel>();
            foreach (var item in postsSearch)
            {
                var postViewModel = new PostViewModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    CategoryName = item.Category.Name,
                    Modified = item.Modified,
                    Published = item.Published,
                    ShortDescription = item.ShortDescription,
                    UrlSlug = item.UrlSlug,
                };
                postsViewModelSearch.Add(postViewModel);
            }
            return postsViewModelSearch;
        }
    }
}