using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public interface IDevOpsToolRepository
    {
        Task<IEnumerable<DevOpsTool>> GetDevOpsToolsAsync();
        Task<DevOpsTool?> GetDevOpsToolByIdAsync(Guid id);
        Task AddDevOpsToolAsync(DevOpsTool devOpsTool);
        Task UpdateDevOpsToolAsync(DevOpsTool devOpsTool);
        Task DeleteDevOpsToolAsync(Guid id);
    }
}
