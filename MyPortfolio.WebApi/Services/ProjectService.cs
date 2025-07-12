using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;
using MyPortfolio.Data.Repositories;

namespace MyPortfolio.WebApi.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repo;
        public ProjectService(IProjectRepository projectRepository)
        {
            _repo = projectRepository;
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            await _repo.AddProjectAsync(project);
            return project;
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            await _repo.DeleteProjectAsync(id);
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _repo.GetProjectsAsync() ?? throw new InvalidOperationException("No projects found.");

        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            return await _repo.GetProjectByIdAsync(id);
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            var projectToUpdate = await _repo.GetProjectByIdAsync(project.Id);
            return projectToUpdate;
        }
    }
}
