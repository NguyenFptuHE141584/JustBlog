using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class JustBlogInitializer : CreateDatabaseIfNotExists<JustBlogContext>
    {
        public void SeedData(JustBlogContext context)
        {
            base.Seed(context);
            if (!context.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new Category(){Name="Category 1"},
                    new Category(){Name="Category 2"},
                    new Category(){Name="Category 3"}
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
            if (!context.Tags.Any())
            {
                var tags = new List<Tag>()
                {
                    new Tag(){ Name= "Tag 1"},
                    new Tag(){ Name= "Tag 2"},
                    new Tag(){ Name= "Tag 3"},
                };
                context.Tags.AddRange(tags);
                context.SaveChanges();
            }
            if (!context.Posts.Any())
            {
                var posts = new List<Post>()
                {
                    new Post(){ Title= "Post 1",PostContent ="gfsdgdf",UrlSlug="dasdasdasd",Published=DateTime.Now,Modified=DateTime.Now,PostedOn=true,CategoryId = 1},
                    new Post(){ Title= "Post 2",PostContent ="asdhsdf",UrlSlug="dasdasdasd",Published=DateTime.Now,Modified=DateTime.Now,PostedOn=true,CategoryId = 2},
                    new Post(){ Title= "Post 3",PostContent ="werjgtt",UrlSlug="fgddfgdfgd",Published=DateTime.Now,Modified=DateTime.Now,PostedOn=true,CategoryId = 3},
                };
                context.Posts.AddRange(posts);
                context.SaveChanges();
            }
            if (!context.PostTagMaps.Any())
            {
                var postTagMap = new List<PostTagMap>()
                {
                   new PostTagMap(){ PostId =1,TagId =2  },
                   new PostTagMap(){ PostId =1,TagId =3  },
                   new PostTagMap(){ PostId =2,TagId =2  },
                };
                context.PostTagMaps.AddRange(postTagMap);
                context.SaveChanges();
            }
        }
    }
}