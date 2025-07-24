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
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Framework> Frameworks { get; set; }
        public DbSet<DevOpsTool> DevOpsTools { get; set; }
        public DbSet<Database> Databases { get; set; }
        public DbSet<CloudService> CloudServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>()
                .HasMany(s => s.Skills)
                .WithMany(p => p.Projects)
                .UsingEntity(j => j.ToTable("ProjectAndSkills"));
        }



    }
}
