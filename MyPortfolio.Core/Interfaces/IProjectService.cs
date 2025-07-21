using MyPortfolio.Core.DTOs;
using MyPortfolio.Core.Models;

namespace MyPortfolio.Core.Interfaces
{
    public interface IProjectService
    {
        /// <summary>
        /// Retrieves a list of all projects.
        /// </summary>
        /// <returns>A list of projects.</returns>
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        /// <summary>
        /// Retrieves a project by its ID.
        /// </summary>
        /// <param name="id">The ID of the project.</param>
        /// <returns>The project with the specified ID.</returns>
        Task<Project> GetProjectByIdAsync(Guid id);
        /// <summary>
        /// Adds a new project.
        /// </summary>
        /// <param name="project">The project to add.</param>
        /// <returns>The added project.</returns>
        Task<Project> AddProjectAsync(CreateProjectDto projectDto);
        /// <summary>
        /// Updates an existing project.
        /// </summary>
        /// <param name="project">The project to update.</param>
        /// <returns>The updated project.</returns>
        Task<Project> UpdateProjectAsync(CreateProjectDto projectDto);
        /// <summary>
        /// Deletes a project by its ID.
        /// </summary>
        /// <param name="id">The ID of the project to delete.</param>
        Task DeleteProjectAsync(Guid id);
    }
}
