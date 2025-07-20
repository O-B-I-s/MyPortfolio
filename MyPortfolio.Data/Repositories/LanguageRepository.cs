using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly PortfolioDbContext _db;
        public LanguageRepository(PortfolioDbContext db)
        {
            _db = db;
        }
        public async Task AddLanguageAsync(Language language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language), "Language cannot be null");
            }
            try
            {
                await _db.Languages.AddAsync(language);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception 
                throw new InvalidOperationException("An error occurred while adding the language.", ex);
            }

        }

        public async Task DeleteLanguageAsync(Guid id)
        {
            var language = _db.Languages.FirstOrDefault(l => l.Id == id);
            if (language == null)
            {
                throw new KeyNotFoundException($"Language with ID {id} not found.");
            }
            try
            {
                _db.Languages.Remove(language);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception 
                throw new InvalidOperationException("An error occurred while deleting the language.", ex);
            }
        }

        public async Task<Language> GetLanguageByIdAsync(Guid id)
        {
            var language = await _db.Languages.FindAsync(id);
            if (language == null)
            {
                throw new KeyNotFoundException($"Language with ID {id} not found.");
            }
            return language;
        }

        public async Task<IEnumerable<Language>> GetLanguagesAsync()
        {
            return await _db.Languages.ToListAsync();
        }

        public async Task UpdateLanguageAsync(Language language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language), "Language cannot be null");
            }
            var existing = await _db.Languages.AnyAsync(l => l.Id == language.Id);
            if (!existing)
            {
                throw new KeyNotFoundException($"Language with ID {language.Id} not found.");
            }
            try
            {
                _db.Entry(language).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception 
                throw new InvalidOperationException("An error occurred while updating the language.", ex);
            }
        }
    }
}
