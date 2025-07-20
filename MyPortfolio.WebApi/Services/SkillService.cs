using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;
using MyPortfolio.Data.Repositories;

namespace MyPortfolio.WebApi.Services
{

    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<Skill> AddSkillAsync(Skill skill)
        {
            await _skillRepository.AddSkillAsync(skill);
            return skill;
        }

        public async Task DeleteSkillAsync(Guid id)
        {
            await _skillRepository.DeleteSkillAsync(id);
        }

        public async Task<Skill> GetSkillByIdAsync(Guid id)
        {
            var skill = await _skillRepository.GetSkillByIdAsync(id);
            if (skill == null)
            {
                throw new KeyNotFoundException("Skill not found.");
            }
            return skill;
        }

        public async Task<IEnumerable<Skill>> GetSkillsAsync()
        {
            return await _skillRepository.GetSkillsAsync() ?? throw new InvalidOperationException("No skills found.");
        }

        public async Task<Skill> UpdateSkillAsync(Skill skill)
        {
            await _skillRepository.UpdateSkillAsync(skill);
            return await _skillRepository.GetSkillByIdAsync(skill.Id);
        }
    }
}
