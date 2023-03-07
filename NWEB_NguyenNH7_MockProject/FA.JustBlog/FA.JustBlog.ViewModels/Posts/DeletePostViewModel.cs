using FA.JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Posts
{
    public class DeletePostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string UrlSlug { get; set; }
        public DateTime Published { get; set; }
        public DateTime Modified { get; set; }

        public string CategoryName { get; set; }

        public List<TagViewModel> Tags { get; set; } = new List<TagViewModel>();
        public string PostContent { get; set; }

        public bool PostedOn { get; set; }
    }
}