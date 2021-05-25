using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioSite.Data
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public List<BlogPost> Posts { get; set; }
        public Tag()
        {
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = DateTime.UtcNow;
        }
    }
}
