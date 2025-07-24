using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolio.Core.Models
{
    public class Framework
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
    }
}
