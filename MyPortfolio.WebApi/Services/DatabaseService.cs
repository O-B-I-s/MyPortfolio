using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;
using MyPortfolio.Data.Repositories;

namespace MyPortfolio.WebApi.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IDatabaseRepository _databaseRepository;
        public DatabaseService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }
        public async Task AddDatabaseAsync(Databases database)
        {
            await _databaseRepository.AddDatabaseAsync(database);
        }

        public async Task DeleteDatabaseAsync(Guid id)
        {
            await _databaseRepository.DeleteDatabaseAsync(id);
        }

        public async Task<Databases?> GetDatabaseByIdAsync(Guid id)
        {
            return await _databaseRepository.GetDatabaseByIdAsync(id);
        }

        public async Task<IEnumerable<Databases>> GetDatabasesAsync()
        {
            return await _databaseRepository.GetDatabasesAsync();
        }

        public async Task UpdateDatabaseAsync(Databases database)
        {
            await _databaseRepository.UpdateDatabaseAsync(database);
        }
    }
}
