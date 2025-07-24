using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public interface IDatabaseRepository
    {
        Task<IEnumerable<Databases>> GetDatabasesAsync();
        Task<Databases?> GetDatabaseByIdAsync(Guid id);
        Task AddDatabaseAsync(Databases database);
        Task DeleteDatabaseAsync(Guid id);
        Task UpdateDatabaseAsync(Databases database);
    }
}
