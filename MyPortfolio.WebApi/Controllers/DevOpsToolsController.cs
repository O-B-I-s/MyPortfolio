using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevOpsToolsController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDevOpsToolService _devOpsToolService;
        public DevOpsToolsController(IWebHostEnvironment webHostEnvironment, IDevOpsToolService devOpsToolService)
        {
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _devOpsToolService = devOpsToolService ?? throw new ArgumentNullException(nameof(devOpsToolService));
        }
        [HttpGet]
        public async Task<IActionResult> GetDevOpsTools()
        {
            try
            {
                var devOpsTools = await _devOpsToolService.GetDevOpsToolsAsync();
                return Ok(devOpsTools);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving DevOps tools. {ex}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevOpsToolById(Guid id)
        {
            try
            {
                var devOpsTool = await _devOpsToolService.GetDevOpsToolByIdAsync(id);
                if (devOpsTool == null)
                {
                    return NotFound($"DevOps tool with ID {id} not found.");
                }
                return Ok(devOpsTool);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the DevOps tool. {ex}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddDevOpsTool([FromForm] DevOpsTool devOpsTool)
        {
            if (devOpsTool == null)
            {
                return BadRequest("DevOps tool data cannot be null.");
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
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(devOpsTool.Image.FileName)}";
                var filePath = Path.Combine(path, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await devOpsTool.Image.CopyToAsync(stream);
                devOpsTool.ImageUrl = $"/uploads/{fileName}";


                await _devOpsToolService.AddDevOpsToolAsync(devOpsTool);
                return CreatedAtAction(nameof(GetDevOpsToolById), new { id = devOpsTool.Id }, devOpsTool);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while adding the DevOps tool. {ex}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevOpsTool(Guid id, [FromForm] DevOpsTool devOpsTool)
        {
            if (devOpsTool == null || devOpsTool.Id != id)
            {
                return BadRequest("DevOps tool data is invalid.");
            }
            try
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(devOpsTool.Image.FileName)}";
                var filePath = Path.Combine(path, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await devOpsTool.Image.CopyToAsync(stream);
                devOpsTool.ImageUrl = $"/uploads/{fileName}";
                await _devOpsToolService.UpdateDevOpsToolAsync(devOpsTool);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the DevOps tool. {ex}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevOpsTool(Guid id)
        {
            try
            {
                await _devOpsToolService.DeleteDevOpsToolAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"DevOps tool with ID {id} not found.");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the DevOps tool. {ex}");
            }
        }

    }
}
