using MyPortfolio.Core.DTOs;
using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;
using MyPortfolio.Data.Repositories;

namespace MyPortfolio.WebApi.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repo;
        private readonly ISkillRepository _skillRepository;

        public ProjectService(IProjectRepository projectRepository, ISkillRepository skillRepository)
        {
            _repo = projectRepository;
            _skillRepository = skillRepository;
        }

        public async Task<Project> AddProjectAsync(CreateProjectDto projectDto)
        {

            var project = new Project
            {
                Id = projectDto.Id,
                Title = projectDto.Title,
                Description = projectDto.Description,
                LiveLink = projectDto.LiveLink,
                GitHubLink = projectDto.GitHubLink,
                CreatedAt = projectDto.CreatedAt,
                ImageUrl = projectDto.ImageUrl,
                Skills = new List<Skill>()
            };

            // Fetch existing Skills based on SkillIds
            if (projectDto.SkillIds != null && projectDto.SkillIds.Any())
            {
                foreach (var skillId in projectDto.SkillIds)
                {
                    var skill = await _skillRepository.GetSkillByIdAsync(skillId);
                    if (skill != null)
                    {
                        project.Skills.Add(skill);
                    }
                }
            }

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

        public async Task<Project> UpdateProjectAsync(CreateProjectDto projectDto)
        {
            var existingProject = await _repo.GetProjectByIdAsync(projectDto.Id);
            if (existingProject == null)
            {
                throw new KeyNotFoundException($"Project with ID {projectDto.Id} not found.");
            }
            existingProject.Title = projectDto.Title;
            existingProject.Description = projectDto.Description;
            existingProject.LiveLink = projectDto.LiveLink;
            existingProject.GitHubLink = projectDto.GitHubLink;
            existingProject.CreatedAt = projectDto.CreatedAt;
            // Update ImageUrl only if a new image is provided
            if (!string.IsNullOrEmpty(projectDto.ImageUrl))
            {
                existingProject.ImageUrl = projectDto.ImageUrl;
            }
            if (projectDto.SkillIds != null && projectDto.SkillIds.Any())
            {
                existingProject.Skills.Clear();
                foreach (var skillId in projectDto.SkillIds)
                {
                    var skill = await _skillRepository.GetSkillByIdAsync(skillId);
                    if (skill != null)
                    {
                        existingProject.Skills.Add(skill);
                    }
                }
            }
            await _repo.UpdateProjectAsync(existingProject);
            return await _repo.GetProjectByIdAsync(existingProject.Id);
        }
    }
}
