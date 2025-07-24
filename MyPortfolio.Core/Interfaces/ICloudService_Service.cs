using MyPortfolio.Core.Models;

namespace MyPortfolio.Core.Interfaces
{
    public interface ICloudService_Service
    {
        Task<IEnumerable<CloudService>> GetCloudServicesAsync();
        Task<CloudService?> GetCloudServiceByIdAsync(Guid id);
        Task AddCloudServiceAsync(CloudService cloudService);
        Task DeleteCloudServiceAsync(Guid id);
        Task UpdateCloudServiceAsync(CloudService cloudService);

    }
}
