using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public interface ICloudServiceRepository
    {
        Task<IEnumerable<CloudService>> GetCloudServicesAsync();
        Task<CloudService?> GetCloudServiceByIdAsync(Guid id);
        Task AddCloudServiceAsync(CloudService cloudService);
        Task UpdateCloudServiceAsync(CloudService cloudService);
        Task DeleteCloudServiceAsync(Guid id);
    }
}
