using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string ShortDescription { get; set; }

        [Required]
        public string PostContent { get; set; }

        [Required]
        public string UrlSlug { get; set; }

        public DateTime Published { get; set; }
        public DateTime Modified { get; set; }
        public bool PostedOn { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<PostTagMap> PostTagMaps { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public int? ViewCount { get; set; }
        public int? RateCount { get; set; }
        public int? TotalRate { get; set; }

        public decimal? Rate
        {
            get => this.TotalRate / this.RateCount;
        }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public AppUser AppUser { get; set; }
    }
}