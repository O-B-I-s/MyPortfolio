using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabasesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDatabaseService _databaseService;
        public DatabasesController(IWebHostEnvironment webHostEnvironment, IDatabaseService databaseService)
        {
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
        }
        [HttpGet]
        public async Task<IActionResult> GetDatabases()
        {
            try
            {
                var databases = await _databaseService.GetDatabasesAsync();
                return Ok(databases);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving databases. {ex}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDatabaseById(Guid id)
        {
            try
            {
                var database = await _databaseService.GetDatabaseByIdAsync(id);
                if (database == null)
                {
                    return NotFound($"Database with ID {id} not found.");
                }
                return Ok(database);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the database. {ex}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddDatabase([FromForm] Databases database)
        {
            if (database == null)
            {
                return BadRequest("Database data cannot be null.");
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
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(database.Image.FileName)}";
                var filePath = Path.Combine(path, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await database.Image.CopyToAsync(stream);
                database.ImageUrl = $"/uploads/{fileName}";
                await _databaseService.AddDatabaseAsync(database);
                return CreatedAtAction(nameof(GetDatabaseById), new { id = database.Id }, database);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while adding the database. {ex}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDatabase(Guid id, [FromForm] Databases database)
        {
            if (database == null || database.Id != id)
            {
                return BadRequest("Database data is invalid.");
            }
            try
            {
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(database.Image.FileName)}";
                var filePath = Path.Combine(path, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await database.Image.CopyToAsync(stream);
                database.ImageUrl = $"/uploads/{fileName}";
                await _databaseService.UpdateDatabaseAsync(database);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the database. {ex}");
            }
        }
        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteDatabase(Guid id)
        {
            try
            {
                await _databaseService.DeleteDatabaseAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the database. {ex}");
            }
        }
    }
}
