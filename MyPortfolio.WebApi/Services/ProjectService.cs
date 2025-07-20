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

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            await _repo.UpdateProjectAsync(project);
            return await _repo.GetProjectByIdAsync(project.Id);
        }
    }
}
