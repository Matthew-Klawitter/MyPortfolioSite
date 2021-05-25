using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolioSite.Data
{
    public class ProjectService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public ProjectService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Insert new Project
        public async Task<bool> InsertProjectAsync(Project project)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.Projects.AddAsync(project);
                await context.SaveChangesAsync();
                return true;
            }
        }

        // Get all Projects
        public async Task<List<Project>> GetProjectsAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Projects.ToListAsync();
            }
        }

        // Get Project by id
        public async Task<Project> GetProjectAsync(int Id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Project project = await context.Projects.FirstOrDefaultAsync(c => c.Id.Equals(Id));
                return project;
            }
        }

        // Update Project
        public async Task<bool> UpdateProjectAsync(Project project)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Projects.Update(project);
                await context.SaveChangesAsync();
                return true;
            }
        }

        // Delete Project
        public async Task<bool> DeleteProjectAsync(Project project)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Projects.Remove(project);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
