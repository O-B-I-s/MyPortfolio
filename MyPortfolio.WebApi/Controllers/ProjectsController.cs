using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.DTOs;
using MyPortfolio.Core.Interfaces;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IWebHostEnvironment _env;
        public ProjectsController(IProjectService projectService, IWebHostEnvironment env)
        {
            _projectService = projectService;
            _env = env;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromForm] CreateProjectDto projectDto)
        {
            if (projectDto == null)
            {
                return BadRequest("Project data cannot be null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var path = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(projectDto.Image.FileName)}";
            var filePath = Path.Combine(path, fileName);
            await using var stream = new FileStream(filePath, FileMode.Create);
            await projectDto.Image.CopyToAsync(stream);
            projectDto.ImageUrl = $"/uploads/{fileName}";
            var addedProject = await _projectService.AddProjectAsync(projectDto);

            return CreatedAtAction(nameof(GetProjectById), new { id = addedProject.Id }, addedProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, [FromForm] CreateProjectDto projectDto)
        {
            if (projectDto == null || projectDto.Id != id)
            {
                return BadRequest("Project data is invalid.");
            }
            if (projectDto.Image != null)
            {
                var path = Path.Combine(_env.WebRootPath, "uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(projectDto.Image.FileName)}";
                var filePath = Path.Combine(path, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await projectDto.Image.CopyToAsync(stream);
                projectDto.ImageUrl = $"/uploads/{fileName}";
            }

            var updatedProject = await _projectService.UpdateProjectAsync(projectDto);
            return Ok(updatedProject);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var existingProject = await _projectService.GetProjectByIdAsync(id);
            if (existingProject == null)
            {
                return NotFound();
            }
            await _projectService.DeleteProjectAsync(id);
            return NoContent();
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchProjects([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Search query cannot be empty.");
            }
            var projects = await _projectService.GetAllProjectsAsync();
            var filteredProjects = projects.Where(p => p.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                                       p.Description.Contains(query, StringComparison.OrdinalIgnoreCase));
            return Ok(filteredProjects);
        }

    }
}
