using MyPortfolio.Core.Models;

namespace MyPortfolio.Core.Interfaces
{
    public interface ILanguageService
    {
        Task<IEnumerable<Language>> GetLanguagesAsync();
        Task<Language> GetLanguageByIdAsync(Guid id);
        Task AddLanguageAsync(Language language);
        Task UpdateLanguageAsync(Language language);
        Task DeleteLanguageAsync(Guid id);
    }
}
