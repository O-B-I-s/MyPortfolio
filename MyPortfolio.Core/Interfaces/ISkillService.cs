using MyPortfolio.Core.Models;

namespace MyPortfolio.Core.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> GetSkillsAsync();
        Task<Skill> GetSkillByIdAsync(Guid id);
        Task<Skill> AddSkillAsync(Skill skill);
        Task<Skill> UpdateSkillAsync(Skill skill);
        Task DeleteSkillAsync(Guid id);
    }
}
