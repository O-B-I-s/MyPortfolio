using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public class FrameworkRepository : IFrameworkRepository
    {
        private readonly PortfolioDbContext _db;
        public FrameworkRepository(PortfolioDbContext db)
        {
            _db = db;
        }
        public async Task AddFrameworkAsync(Framework framework)
        {
            if (framework == null)
            {
                throw new ArgumentNullException(nameof(framework), "Framework cannot be null");
            }
            await _db.Frameworks.AddAsync(framework);
            await _db.SaveChangesAsync();

        }

        public async Task DeleteFrameworkAsync(Guid id)
        {
            var framework = _db.Frameworks.FirstOrDefault(f => f.Id == id);
            if (framework == null)
            {
                throw new KeyNotFoundException($"Framework with ID {id} not found.");
            }
            _db.Frameworks.Remove(framework);
            await _db.SaveChangesAsync();
        }

        public async Task<Framework?> GetFrameworkByIdAsync(Guid id)
        {
            var framework = await _db.Frameworks.FirstOrDefaultAsync(f => f.Id == id);
            if (framework == null)
            {
                throw new KeyNotFoundException($"Framework with ID {id} not found.");
            }
            return framework;
        }

        public async Task<IEnumerable<Framework>> GetFrameworksAsync()
        {
            try
            {
                return await _db.Frameworks.ToListAsync();
            }

            catch (Exception ex)
            {
                // Log the exception
                throw new InvalidOperationException("An error occurred while retrieving frameworks.", ex);
            }
        }

        public async Task UpdateFrameworkAsync(Framework framework)
        {
            var existing = await _db.Frameworks.AnyAsync(f => f.Id == framework.Id);
            if (!existing)
            {
                throw new KeyNotFoundException($"Framework with ID {framework.Id} not found.");
            }
            try
            {
                _db.Entry(framework).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new InvalidOperationException("An error occurred while updating the framework.", ex);
            }
        }
    }
}
