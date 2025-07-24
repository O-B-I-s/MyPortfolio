using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public class CloudServiceRepository : ICloudServiceRepository
    {
        private readonly PortfolioDbContext _db;
        public CloudServiceRepository(PortfolioDbContext db)
        {
            _db = db;
        }
        public async Task AddCloudServiceAsync(CloudService cloudService)
        {
            await _db.CloudServices.AddAsync(cloudService);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCloudServiceAsync(Guid id)
        {
            var cloudService = await _db.CloudServices.FirstOrDefaultAsync(c => c.Id == id);
            if (cloudService == null)
            {
                throw new KeyNotFoundException($"Cloud service with ID {id} not found.");
            }
            _db.CloudServices.Remove(cloudService);
            await _db.SaveChangesAsync();
        }

        public async Task<CloudService?> GetCloudServiceByIdAsync(Guid id)
        {
            var cloudService = await _db.CloudServices.FindAsync(id);
            if (cloudService == null)
            {
                throw new KeyNotFoundException($"Cloud service with ID {id} not found.");
            }
            return cloudService;
        }

        public async Task<IEnumerable<CloudService>> GetCloudServicesAsync()
        {
            var cloudServices = await _db.CloudServices.ToListAsync();

            return cloudServices;
        }

        public async Task UpdateCloudServiceAsync(CloudService cloudService)
        {
            var exist = await _db.CloudServices.AnyAsync(c => c.Id == cloudService.Id);
            if (!exist)
            {
                throw new KeyNotFoundException($"Cloud service with ID {cloudService.Id} not found.");
            }
            _db.Entry(cloudService).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
