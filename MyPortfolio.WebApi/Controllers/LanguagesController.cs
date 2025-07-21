using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        private readonly IWebHostEnvironment _env;
        public LanguagesController(ILanguageService language, IWebHostEnvironment env)
        {
            _languageService = language ?? throw new ArgumentNullException(nameof(language));
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> GetLanguages()
        {
            try
            {
                var languages = await _languageService.GetLanguagesAsync();
                return Ok(languages);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving languages. {ex}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageById(Guid id)
        {
            try
            {
                var language = await _languageService.GetLanguageByIdAsync(id);
                if (language == null)
                {
                    return NotFound($"Language with ID {id} not found.");
                }
                return Ok(language);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the language.{ex}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddLanguage([FromForm] Language language)
        {
            if (language == null)
            {
                return BadRequest("Language cannot be null.");
            }
            try
            {
                var path = Path.Combine(_env.WebRootPath, "uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(language.Image.FileName)}";
                var filePath = Path.Combine(path, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await language.Image.CopyToAsync(stream);
                language.ImageUrl = $"/uploads/{fileName}";
                await _languageService.AddLanguageAsync(language);
                return CreatedAtAction(nameof(GetLanguageById), new { id = language.Id }, language);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while adding the language.{ex}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLanguage(Guid id, [FromForm] Language language)
        {
            if (language == null || language.Id != id)
            {
                return BadRequest("Language data is invalid.");
            }
            try
            {
                if (language.Image != null)
                {
                    var path = Path.Combine(_env.WebRootPath, "uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(language.Image.FileName)}";
                    var filePath = Path.Combine(path, fileName);
                    await using var stream = new FileStream(filePath, FileMode.Create);
                    await language.Image.CopyToAsync(stream);
                    language.ImageUrl = $"/uploads/{fileName}";
                }
                await _languageService.UpdateLanguageAsync(language);
                return Ok(language);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"Concurrency conflict: {ex.Message}");
                throw new InvalidOperationException("A concurrency conflict occurred. The language was modified by another user.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating language: {ex.Message}, Inner Exception: {ex.InnerException?.Message}");
                throw new InvalidOperationException("An error occurred while updating the language.", ex);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(Guid id)
        {
            try
            {
                var existingLanguage = await _languageService.GetLanguageByIdAsync(id);
                if (existingLanguage == null)
                {
                    return NotFound($"Language with ID {id} not found.");
                }
                await _languageService.DeleteLanguageAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the language.{ex}");
            }
        }

    }
}
