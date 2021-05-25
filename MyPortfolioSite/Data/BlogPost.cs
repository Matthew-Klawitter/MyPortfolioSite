using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioSite.Data
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public bool IsPublic { get; set; }
        public List<Tag> Tags { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public BlogPost()
        {
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = DateTime.UtcNow;
        }

        public bool UpdateDate()
        {
            this.DateUpdated = DateTime.UtcNow;
            return true;
        }
    }
}
