using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PortfolioDbContext _db;
        public ProjectRepository(PortfolioDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }



        public async Task AddProjectAsync(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }


            try
            {

                await _db.Projects.AddAsync(project);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new InvalidOperationException("An error occurred while adding the project.", ex);
            }

        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var project = _db.Projects.Find(id);
            if (project == null)
            {
                throw new KeyNotFoundException("Project not found.");
            }
            _db.Projects.Remove(project);
            await _db.SaveChangesAsync();
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            return await _db.Projects.FindAsync(id) ?? throw new KeyNotFoundException("Project not found.");

        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _db.Projects.ToListAsync() ?? throw new InvalidOperationException("No projects found.");
        }

        public async Task UpdateProjectAsync(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }
            try
            {
                _db.Projects.Update(project);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new InvalidOperationException("An error occurred while updating the project.", ex);
            }
        }
    }
}
