using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;
using MyPortfolio.Data.Repositories;

namespace MyPortfolio.WebApi.Services
{
    public class DevOpsToolService : IDevOpsToolService
    {
        private readonly IDevOpsToolRepository _repo;
        public DevOpsToolService(IDevOpsToolRepository repo)
        {
            _repo = repo;
        }
        public async Task AddDevOpsToolAsync(DevOpsTool devOpsTool)
        {
            await _repo.AddDevOpsToolAsync(devOpsTool);
        }

        public async Task DeleteDevOpsToolAsync(Guid id)
        {
            await _repo.DeleteDevOpsToolAsync(id);
        }

        public async Task<DevOpsTool?> GetDevOpsToolByIdAsync(Guid id)
        {
            return await _repo.GetDevOpsToolByIdAsync(id) ?? throw new InvalidOperationException("DevOps Tool not found.");
        }

        public async Task<IEnumerable<DevOpsTool>> GetDevOpsToolsAsync()
        {
            return await _repo.GetDevOpsToolsAsync() ?? throw new InvalidOperationException("No DevOps Tools found.");
        }

        public async Task UpdateDevOpsToolAsync(DevOpsTool devOpsTool)
        {
            await _repo.UpdateDevOpsToolAsync(devOpsTool);
        }
    }
}
