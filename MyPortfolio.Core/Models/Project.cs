namespace MyPortfolio.Core.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Uri? LiveLink { get; set; }
        public Uri? GitHubLink { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
