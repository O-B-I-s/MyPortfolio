using Microsoft.AspNetCore.Http;

namespace MyPortfolio.Core.DTOs
{
    public class CreateProjectDto
    {
        public Guid Id { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Uri? LiveLink { get; set; }
        public Uri? GitHubLink { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Guid> SkillIds { get; set; } = new List<Guid>();

    }
}
