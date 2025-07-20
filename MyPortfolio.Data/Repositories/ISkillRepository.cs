using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetSkillsAsync();
        Task<Skill> GetSkillByIdAsync(Guid id);
        Task AddSkillAsync(Skill skill);
        Task UpdateSkillAsync(Skill skill);
        Task DeleteSkillAsync(Guid id);
    }
}
