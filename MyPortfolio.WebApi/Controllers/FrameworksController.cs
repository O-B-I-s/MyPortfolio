using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworksController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFrameworkService _frameworkService;
        public FrameworksController(IWebHostEnvironment webHostEnvironment, IFrameworkService frameworkService)
        {
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _frameworkService = frameworkService ?? throw new ArgumentNullException(nameof(frameworkService));
        }
        [HttpGet]
        public async Task<IActionResult> GetFrameworks()
        {
            try
            {
                var frameworks = await _frameworkService.GetFrameworksAsync();
                return Ok(frameworks);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving frameworks. {ex}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFrameworkById(Guid id)
        {
            try
            {
                var framework = await _frameworkService.GetFrameworkByIdAsync(id);
                if (framework == null)
                {
                    return NotFound($"Framework with ID {id} not found.");
                }
                return Ok(framework);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the framework. {ex}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddFramework([FromForm] Framework framework)
        {
            if (framework == null)
            {
                return BadRequest("Framework data cannot be null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(framework.Image.FileName)}";
                var filePath = Path.Combine(path, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await framework.Image.CopyToAsync(stream);
                framework.ImageUrl = $"/uploads/{fileName}";
                await _frameworkService.AddFrameworkAsync(framework);
                return CreatedAtAction(nameof(GetFrameworkById), new { id = framework.Id }, framework);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while adding the framework. {ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFramework(Guid id, [FromForm] Framework framework)
        {
            if (framework == null || framework.Id != id)
            {
                return BadRequest("Framework data is invalid.");
            }
            try
            {
                if (framework.Image != null)
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(framework.Image.FileName)}";
                    var filePath = Path.Combine(path, fileName);
                    await using var stream = new FileStream(filePath, FileMode.Create);
                    await framework.Image.CopyToAsync(stream);
                    framework.ImageUrl = $"/uploads/{fileName}";
                }
                await _frameworkService.UpdateFrameworkAsync(framework);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the framework. {ex}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFramework(Guid id)
        {
            try
            {
                await _frameworkService.DeleteFrameworkAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Framework with ID {id} not found.");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the framework. {ex}");
            }

        }

    }
}
