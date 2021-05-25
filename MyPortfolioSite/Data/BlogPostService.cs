using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioSite.Data
{
    public class BlogPostService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public BlogPostService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Insert new BlogPost
        public async Task<bool> InsertBlogPostAsync(BlogPost blogPost)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.BlogPosts.AddAsync(blogPost);
                await context.SaveChangesAsync();
                return true;
            }
        }

        // Get all BlogPosts
        public async Task<List<BlogPost>> GetBlogPostsAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.BlogPosts.ToListAsync();
            }
        }

        // Get BlogPost by id
        public async Task<BlogPost> GetBlogPostAsync(int Id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                BlogPost blogPost = await context.BlogPosts.FirstOrDefaultAsync(c => c.Id.Equals(Id));
                return blogPost;
            }
        }

        // Update BlogPost
        public async Task<bool> UpdateBlogPostAsync(BlogPost blogPost)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.BlogPosts.Update(blogPost);
                await context.SaveChangesAsync();
                return true;
            }
        }

        // Delete BlogPost
        public async Task<bool> DeleteBlogPostAsync(BlogPost blogPost)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.BlogPosts.Remove(blogPost);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
