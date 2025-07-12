using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Models;

namespace MyPortfolio.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
    }
}
