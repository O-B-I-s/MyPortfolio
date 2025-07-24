using MyPortfolio.Core.Models;

namespace MyPortfolio.Core.Interfaces
{
    public interface IFrameworkService
    {
        Task<IEnumerable<Framework>> GetFrameworksAsync();
        Task<Framework?> GetFrameworkByIdAsync(Guid id);
        Task AddFrameworkAsync(Framework framework);
        Task UpdateFrameworkAsync(Framework framework);
        Task DeleteFrameworkAsync(Guid id);
    }
}
