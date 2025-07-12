namespace MyPortfolio.Core.Models
{
    public class Project
    {
        public Guid Id { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public Uri? LiveLink { get; private set; }
        public Uri? GitHubLink { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
