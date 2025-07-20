using MyPortfolio.Core.Models;

namespace MyPortfolio.Data.Repositories
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> GetLanguagesAsync();
        Task<Language> GetLanguageByIdAsync(Guid id);
        Task AddLanguageAsync(Language language);
        Task UpdateLanguageAsync(Language language);
        Task DeleteLanguageAsync(Guid id);

    }
}
