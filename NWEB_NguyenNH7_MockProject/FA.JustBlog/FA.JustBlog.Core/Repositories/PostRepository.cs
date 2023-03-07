using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext context) : base(context)
        {
        }

        public int CountPostsForCategory(string category)
        {
            var cate = context.Categories.FirstOrDefault(c => c.Name.Equals(category));
            return this.dbSet.Count(x => x.Id == cate.Id);
        }

        public int CountPostsForTag(string tag)
        {
            var ta = context.Tags.FirstOrDefault(t => t.Name.Equals(tag));
            return this.dbSet.Count(x => x.Id == ta.Id);
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            return this.dbSet.FirstOrDefault(x => x.Published.Month.Equals(year) && x.Published.Year.Equals(month) && x.UrlSlug.Equals(urlSlug));
        }

        public IList<Post> GetLatestPost(int size)
        {
            return this.dbSet.OrderByDescending(x => x.Id).Take(size).ToList();
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            var cate = context.Categories.FirstOrDefault(t => t.Name.ToUpper().Equals(category.ToUpper()));
            return this.dbSet.Where(x => x.Id == cate.Id).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return this.dbSet.Where(x => x.Published.Month.Equals(monthYear.Month)).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            var tagOnTableTags = context.Tags.FirstOrDefault(t => t.Name.ToUpper().Equals(tag.ToUpper()));
            var postTagMap = context.PostTagMaps.Where(ptm => ptm.TagId == tagOnTableTags.Id).ToList();

            var postsByTag = new List<Post>();
            foreach (var item in postTagMap)
            {
                postsByTag.Add(context.Posts.FirstOrDefault(p => p.Id == item.PostId));
            }
            return postsByTag;
        }

        public IList<Post> GetPublisedPosts()
        {
            return this.dbSet.Where(x => x.PostedOn == true).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return this.dbSet.Where(x => x.PostedOn == false).ToList();
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return this.dbSet.OrderByDescending(x => x.RateCount).Take(size).ToList();
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return this.dbSet.OrderByDescending(x => x.ViewCount).Take(size).ToList();
        }

        public Post GetPostByUrlSlug(string urlSlug)
        {
            return this.dbSet.FirstOrDefault(x => x.UrlSlug.Equals(urlSlug));
        }

        public IList<Post> GetAllPostByUserId(string userId)
        {
            return this.dbSet.Where(x => x.UserId == userId).Include(c => c.Category).ToList();
        }

        public Post GetPostByIdHaveCateName(int id)
        {
            return this.dbSet.Where(x => x.Id == id).Include(c => c.Category).First();
        }

        public IList<Post> Search(string search, string userId)
        {
            return this.dbSet.Where(x => x.Title.Contains(search) || search == null).Where(x => x.UserId == userId).Include(c => c.Category).ToList();
        }

        public IList<Post> Search(string search)
        {
            return this.dbSet.Where(x => x.Title.Contains(search) || search == null).Include(c => c.Category).ToList();
        }
    }
}