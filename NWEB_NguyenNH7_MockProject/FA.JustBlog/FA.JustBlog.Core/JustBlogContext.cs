using FA.JustBlog.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class JustBlogContext : IdentityDbContext<AppUser>
    {
        public JustBlogContext() : base("name = connectionString")
        {
            Database.SetInitializer<JustBlogContext>(new CreateDatabaseIfNotExists<JustBlogContext>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public static JustBlogContext Create()
        {
            return new JustBlogContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostTagMap>()
            .HasKey(ptm => new { ptm.PostId, ptm.TagId });
        }
    }
}