using MyPortfolio.Core.Models;

namespace MyPortfolio.Core.Interfaces
{
    public interface IDevOpsToolService
    {
        Task<IEnumerable<DevOpsTool>> GetDevOpsToolsAsync();
        Task<DevOpsTool?> GetDevOpsToolByIdAsync(Guid id);
        Task AddDevOpsToolAsync(DevOpsTool devOpsTool);
        Task UpdateDevOpsToolAsync(DevOpsTool devOpsTool);
        Task DeleteDevOpsToolAsync(Guid id);
    }
}
