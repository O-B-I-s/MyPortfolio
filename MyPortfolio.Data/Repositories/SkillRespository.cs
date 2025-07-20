using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public class SkillRespository : ISkillRepository
    {

        private readonly PortfolioDbContext _db;
        public SkillRespository(PortfolioDbContext db)
        {
            _db = db;
        }
        public async Task AddSkillAsync(Skill skill)
        {
            _db.Skills.Add(skill);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteSkillAsync(Guid id)
        {

            var skill = _db.Skills.Find(id);
            if (skill == null)
            {
                throw new KeyNotFoundException("Skill not found.");
            }
            _db.Skills.Remove(skill);
            await _db.SaveChangesAsync();
        }

        public async Task<Skill> GetSkillByIdAsync(Guid id)
        {
            var skill = await _db.Skills.FindAsync(id);
            if (skill == null)
            {
                throw new KeyNotFoundException("Skill not found.");
            }
            return skill;
        }

        public async Task<IEnumerable<Skill>> GetSkillsAsync()
        {
            return await _db.Skills.ToListAsync() ?? throw new InvalidOperationException("No skills found.");
        }

        public Task UpdateSkillAsync(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }
            var exist = _db.Skills.AnyAsync(s => s.Id == skill.Id);
            if (exist == null)
            {
                throw new KeyNotFoundException("Skill not found.");
            }
            _db.Entry(skill).State = EntityState.Modified;
            return _db.SaveChangesAsync();
        }
    }
}
