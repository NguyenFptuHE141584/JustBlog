using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Posts
{
    public class CreatePostViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title not empty")]
        [MaxLength(200, ErrorMessage = "Title should not exceed 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ShortDescription not empty")]
        [MaxLength(200, ErrorMessage = "ShortDescription should not exceed 200 characters")]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Link Url")]
        public string UrlSlug { get; set; }

        [Display(Name = "Categories")]
        public int CategoryId { get; set; }

        [Display(Name = "List Tag (separated by ;)")]
        public string Tags { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "Content not empty")]
        public string PostContent { get; set; }

        public bool PostedOn { get; set; }
    }
}