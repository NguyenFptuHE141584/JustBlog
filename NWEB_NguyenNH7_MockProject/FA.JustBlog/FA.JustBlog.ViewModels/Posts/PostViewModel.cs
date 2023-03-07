using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Posts
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Published { get; set; }
        public DateTime Modified { get; set; }
        public string ShortDescription { get; set; }
        public string UrlSlug { get; set; }
        public string CategoryName { get; set; }
    }
}