using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudServicesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICloudService_Service _cloudServiceService;
        public CloudServicesController(IWebHostEnvironment webHostEnvironment, ICloudService_Service cloudServiceService)
        {
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _cloudServiceService = cloudServiceService ?? throw new ArgumentNullException(nameof(cloudServiceService));
        }
        [HttpGet]
        public async Task<IActionResult> GetCloudServices()
        {
            try
            {
                var cloudServices = await _cloudServiceService.GetCloudServicesAsync();
                return Ok(cloudServices);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving cloud services. {ex}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCloudServiceById(Guid id)
        {
            try
            {
                var cloudService = await _cloudServiceService.GetCloudServiceByIdAsync(id);
                if (cloudService == null)
                {
                    return NotFound($"Cloud service with ID {id} not found.");
                }
                return Ok(cloudService);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the cloud service. {ex}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCloudService([FromForm] CloudService cloudService)
        {
            if (cloudService == null)
            {
                return BadRequest("Cloud service data cannot be null.");
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
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(cloudService.Image.FileName)}";
                var filePath = Path.Combine(path, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await cloudService.Image.CopyToAsync(stream);
                cloudService.ImageUrl = $"/uploads/{fileName}";
                await _cloudServiceService.AddCloudServiceAsync(cloudService);
                return CreatedAtAction(nameof(GetCloudServiceById), new { id = cloudService.Id }, cloudService);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while adding the cloud service. {ex}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCloudService(Guid id, [FromForm] CloudService cloudService)
        {
            if (cloudService == null || cloudService.Id != id)
            {
                return BadRequest("Cloud service data is invalid.");
            }
            try
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(cloudService.Image.FileName)}";
                var filePath = Path.Combine(path, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await cloudService.Image.CopyToAsync(stream);
                cloudService.ImageUrl = $"/uploads/{fileName}";
                await _cloudServiceService.UpdateCloudServiceAsync(cloudService);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the cloud service. {ex}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCloudService(Guid id)
        {
            try
            {
                await _cloudServiceService.DeleteCloudServiceAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Cloud service with ID {id} not found.");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the cloud service. {ex}");
            }
        }
    }
}
