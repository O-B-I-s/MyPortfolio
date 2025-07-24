using MyPortfolio.Core.Interfaces;
using MyPortfolio.Core.Models;
using MyPortfolio.Data.Repositories;

namespace MyPortfolio.WebApi.Services
{
    public class FrameworkService : IFrameworkService
    {
        private readonly IFrameworkRepository _frameworkRepository;
        public FrameworkService(IFrameworkRepository frameworkRepository)
        {
            _frameworkRepository = frameworkRepository;
        }
        public async Task<IEnumerable<Framework>> GetFrameworksAsync()
        {
            return await _frameworkRepository.GetFrameworksAsync();
        }
        public async Task<Framework?> GetFrameworkByIdAsync(Guid id)
        {
            return await _frameworkRepository.GetFrameworkByIdAsync(id);
        }
        public async Task AddFrameworkAsync(Framework framework)
        {
            await _frameworkRepository.AddFrameworkAsync(framework);
        }
        public async Task UpdateFrameworkAsync(Framework framework)
        {
            await _frameworkRepository.UpdateFrameworkAsync(framework);
        }
        public async Task DeleteFrameworkAsync(Guid id)
        {
            await _frameworkRepository.DeleteFrameworkAsync(id);
        }
    }


}
