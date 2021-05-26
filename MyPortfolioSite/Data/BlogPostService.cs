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
        public async Task<bool> InsertBlogPostAsync(BlogPost blogPost, List<string> tagIds)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                List<int> ids = new List<int>();
                foreach (var tag in tagIds)
                {
                    ids.Add(int.Parse(tag));
                }

                var tags = await context.Tags.Where(t => ids.Contains(t.Id)).ToListAsync();

                blogPost.Tags = tags;

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
                return await context.BlogPosts
                    .Include(blog => blog.Tags)
                    .ToListAsync();
            }
        }

        // Get BlogPost by id
        public async Task<BlogPost> GetBlogPostAsync(int Id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                BlogPost blogPost = await context.BlogPosts
                    .Include(blog => blog.Tags)
                    .FirstOrDefaultAsync(c => c.Id.Equals(Id));
                return blogPost;
            }
        }

        // Update BlogPost
        public async Task<bool> UpdateBlogPostAsync(BlogPost updatedPost, List<string> tagIds)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                BlogPost blogPost = await context.BlogPosts
                    .Include(blog => blog.Tags)
                    .FirstOrDefaultAsync(c => c.Id.Equals(updatedPost.Id));

                // Convert the posted Tag Id's from string to int for convenience
                List<int> ids = new List<int>();
                foreach (var tag in tagIds)
                {
                    ids.Add(int.Parse(tag));
                }

                // Tags that should exist in the updated Post.Tags
                var newTags = await context.Tags.Where(t => ids.Contains(t.Id)).ToListAsync();

                blogPost.Title = updatedPost.Title;
                blogPost.Desc = updatedPost.Desc;
                blogPost.Author = updatedPost.Author;
                blogPost.Content = updatedPost.Content;
                blogPost.IsPublic = updatedPost.IsPublic;
                blogPost.DateUpdated = DateTime.UtcNow;

                // Update list of Tags
                blogPost.Tags.Clear();
                blogPost.Tags = newTags;

                // Save changes
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
