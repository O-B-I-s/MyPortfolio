using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Core.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Uri? LiveLink { get; set; }
        public Uri? GitHubLink { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Skill>? Skills { get; set; }
    }
}
