using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioSite.Data
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string URL { get; set; }
        public DateTime StartYear { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Project()
        {
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = DateTime.UtcNow;
        }
    }
}
