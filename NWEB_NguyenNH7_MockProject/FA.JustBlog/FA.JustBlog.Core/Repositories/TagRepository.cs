using FA.JustBlog.Common;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext context) : base(context)
        {
        }

        public IEnumerable<int> AddTagByString(string tags)
        {
            var tagNames = tags.Split(';');

            foreach (var tagName in tagNames)
            {
                var tagExisting = this.dbSet.Where(t => t.Name.Trim().ToLower() == tagName.Trim().ToLower()).Count();
                if (tagExisting == 0)
                {
                    var tag = new Tag()
                    {
                        Name = tagName,
                        UrlSlug = UrlHelper.FrientlyUrl(tagName)
                    };
                    this.dbSet.Add(tag);
                }
            }
            this.context.SaveChanges();

            foreach (var tagName in tagNames)
            {
                var tagExisting = this.dbSet.FirstOrDefault(t => t.Name.Trim().ToLower() == tagName.Trim().ToLower());
                if (tagExisting != null)
                {
                    yield return tagExisting.Id;
                }
            }
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return this.dbSet.FirstOrDefault(x => x.UrlSlug == urlSlug);
        }
    }
}