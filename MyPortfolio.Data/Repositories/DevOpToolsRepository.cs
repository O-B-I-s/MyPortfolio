using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public class DevOpToolsRepository : IDevOpsToolRepository
    {
        private readonly PortfolioDbContext _db;
        public DevOpToolsRepository(PortfolioDbContext db)
        {
            _db = db;
        }
        public async Task AddDevOpsToolAsync(DevOpsTool devOpsTool)
        {

            try
            {
                await _db.DevOpsTools.AddAsync(devOpsTool);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new InvalidOperationException("An error occurred while adding the DevOps tool.", ex);
            }
        }

        public async Task DeleteDevOpsToolAsync(Guid id)
        {
            var devOpsTool = await _db.DevOpsTools.FindAsync(id);
            if (devOpsTool == null)
            {
                throw new KeyNotFoundException($"DevOps tool with ID {id} not found.");
            }
            try
            {
                _db.DevOpsTools.Remove(devOpsTool);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new InvalidOperationException("An error occurred while deleting the DevOps tool.", ex);
            }
        }

        public async Task<DevOpsTool?> GetDevOpsToolByIdAsync(Guid id)
        {
            var devOpsTool = await _db.DevOpsTools.FindAsync(id);
            if (devOpsTool == null)
            {
                throw new KeyNotFoundException($"DevOps tool with ID {id} not found.");
            }
            return devOpsTool;
        }

        public async Task<IEnumerable<DevOpsTool>> GetDevOpsToolsAsync()
        {
            return await _db.DevOpsTools.ToListAsync();
        }

        public async Task UpdateDevOpsToolAsync(DevOpsTool devOpsTool)
        {
            var existing = await _db.DevOpsTools.AnyAsync(d => d.Id == devOpsTool.Id);
            if (!existing)
            {
                throw new KeyNotFoundException($"DevOps tool with ID {devOpsTool.Id} not found.");
            }
            try
            {
                _db.Entry(devOpsTool).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new InvalidOperationException("An error occurred while updating the DevOps tool.", ex);
            }
        }
    }
}
