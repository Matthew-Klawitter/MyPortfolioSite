using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioSite.Data
{
    public class TagService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public TagService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Insert new Tag
        public async Task<bool> InsertTagAsync(Tag tag)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.Tags.AddAsync(tag);
                await context.SaveChangesAsync();
                return true;
            }
        }

        // Get all
        public async Task<List<Tag>> GetTagsAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Tags.ToListAsync();
            }
        }

        // Get Tag by id
        public async Task<Tag> GetTagAsync(int Id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Tag tag = await context.Tags.FirstOrDefaultAsync(c => c.Id.Equals(Id));
                return tag;
            }
        }

        // Update Tag
        public async Task<bool> UpdateTagAsync(Tag tag)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                tag.DateUpdated = DateTime.UtcNow;
                context.Tags.Update(tag);
                await context.SaveChangesAsync();
                return true;
            }
        }

        // Delete Tag
        public async Task<bool> DeleteTagAsync(Tag tag)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Tags.Remove(tag);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}