using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;

namespace MyPortfolio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var skills = await _skillService.GetSkillsAsync();
            return Ok(skills);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(Guid id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }
        [HttpPost]
        public async Task<IActionResult> AddSkill([FromBody] Skill skill)
        {
            if (skill == null)
            {
                return BadRequest("Skill cannot be null.");
            }
            var addedSkill = await _skillService.AddSkillAsync(skill);
            return CreatedAtAction(nameof(GetSkillById), new { id = addedSkill.Id }, addedSkill);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(Guid id, [FromBody] Skill skill)
        {
            if (skill == null || skill.Id != id)
            {
                return BadRequest("Skill data is invalid.");
            }
            var updatedSkill = await _skillService.UpdateSkillAsync(skill);
            return Ok(updatedSkill);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(Guid id)
        {
            await _skillService.DeleteSkillAsync(id);
            return NoContent();
        }
    }
}
