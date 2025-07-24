using MyPortfolio.Core.Models;

namespace MyPortfolio.Core.Interfaces
{
    public interface IDatabaseService
    {
        Task<IEnumerable<Databases>> GetDatabasesAsync();
        Task<Databases?> GetDatabaseByIdAsync(Guid id);
        Task AddDatabaseAsync(Databases database);
        Task DeleteDatabaseAsync(Guid id);
        Task UpdateDatabaseAsync(Databases database);

    }
}
