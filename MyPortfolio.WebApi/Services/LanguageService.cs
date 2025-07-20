using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;
using MyPortfolio.Data.Repositories;

namespace MyPortfolio.WebApi.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository ?? throw new ArgumentNullException(nameof(languageRepository));
        }
        public async Task AddLanguageAsync(Language language)
        {
            await _languageRepository.AddLanguageAsync(language);
        }

        public async Task DeleteLanguageAsync(Guid id)
        {
            await _languageRepository.DeleteLanguageAsync(id);
        }

        public async Task<Language> GetLanguageByIdAsync(Guid id)
        {
            return await _languageRepository.GetLanguageByIdAsync(id);
        }

        public async Task<IEnumerable<Language>> GetLanguagesAsync()
        {
            return await _languageRepository.GetLanguagesAsync();
        }

        public async Task UpdateLanguageAsync(Language language)
        {
            await _languageRepository.UpdateLanguageAsync(language);
        }
    }
}
