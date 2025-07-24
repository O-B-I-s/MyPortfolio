using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly PortfolioDbContext _db;
        public DatabaseRepository(PortfolioDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task AddDatabaseAsync(Databases database)
        {
            await _db.Databases.AddAsync(database);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteDatabaseAsync(Guid id)
        {
            var database = _db.Databases.FirstOrDefault(d => d.Id == id);
            if (database == null)
            {
                throw new KeyNotFoundException($"Database with ID {id} not found.");
            }
            _db.Databases.Remove(database);
            await _db.SaveChangesAsync();
        }

        public async Task<Databases?> GetDatabaseByIdAsync(Guid id)
        {
            var database = await _db.Databases.FindAsync(id);
            if (database == null)
            {
                throw new KeyNotFoundException($"Database with ID {id} not found.");
            }
            return database;
        }

        public async Task<IEnumerable<Databases>> GetDatabasesAsync()
        {
            return await _db.Databases.ToListAsync();
        }

        public async Task UpdateDatabaseAsync(Databases database)
        {
            var exist = _db.Databases.AnyAsync(d => d.Id == database.Id);
            if (!exist.Result)
            {
                throw new KeyNotFoundException($"Database with ID {database.Id} not found.");
            }

            try
            {
                _db.Entry(database).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException("The database update failed due to concurrency issues.");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new InvalidOperationException("An error occurred while updating the database.", ex);
            }
        }
    }
}
