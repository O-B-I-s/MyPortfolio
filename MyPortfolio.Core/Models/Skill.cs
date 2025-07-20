using System.Text.Json.Serialization;

namespace MyPortfolio.Core.Models
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore] // Ignore during deserialization for Skill creation
        public ICollection<Project>? Projects { get; set; }
    }
}
