using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public interface IFrameworkRepository
    {
        Task<IEnumerable<Framework>> GetFrameworksAsync();
        Task<Framework?> GetFrameworkByIdAsync(Guid id);
        Task AddFrameworkAsync(Framework framework);
        Task UpdateFrameworkAsync(Framework framework);
        Task DeleteFrameworkAsync(Guid id);

    }
}
