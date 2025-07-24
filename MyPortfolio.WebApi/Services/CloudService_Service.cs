using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;
using MyPortfolio.Data.Repositories;

namespace MyPortfolio.WebApi.Services
{
    public class CloudService_Service : ICloudService_Service
    {
        private readonly ICloudServiceRepository _cloudServiceRepository;
        public CloudService_Service(ICloudServiceRepository cloudServiceRepository)
        {
            _cloudServiceRepository = cloudServiceRepository;
        }
        public async Task AddCloudServiceAsync(CloudService cloudService)
        {
            await _cloudServiceRepository.AddCloudServiceAsync(cloudService);
        }

        public async Task DeleteCloudServiceAsync(Guid id)
        {
            await _cloudServiceRepository.DeleteCloudServiceAsync(id);
        }

        public async Task<CloudService?> GetCloudServiceByIdAsync(Guid id)
        {
            return await _cloudServiceRepository.GetCloudServiceByIdAsync(id);
        }

        public async Task<IEnumerable<CloudService>> GetCloudServicesAsync()
        {
            return await _cloudServiceRepository.GetCloudServicesAsync();
        }

        public async Task UpdateCloudServiceAsync(CloudService cloudService)
        {
            await _cloudServiceRepository.UpdateCloudServiceAsync(cloudService);
        }
    }
}
