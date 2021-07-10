using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioSite.Data
{
    public class Photo
    {
        public int Id;
        public string FileName { get; set; }
        public string Desc { get; set; }
        public string Path { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Photo()
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
