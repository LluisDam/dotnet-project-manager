using Microsoft.EntityFrameworkCore;
using ProjectManager.Models;

namespace ProjectManager.Services;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectTask> Tasks => Set<ProjectTask>();
    public DbSet<Sprint> Sprints => Set<Sprint>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, Name = "Web Corporativa PYME", ClientName = "Ferreteria Lopez SL",
                Status = ProjectStatus.Completed, Budget = 2500m,
                KitDigitalCode = "KD-2024-001", KitDigitalAmount = 2000m,
                StartDate = DateTime.UtcNow.AddMonths(-3), Description = "WordPress. Aceptacion 100%." },
            new Project { Id = 2, Name = "Integracion CRM API", ClientName = "Fontaneria Garcia",
                Status = ProjectStatus.InProgress, Budget = 4200m,
                KitDigitalCode = "KD-2024-003", KitDigitalAmount = 3500m,
                StartDate = DateTime.UtcNow.AddMonths(-1), Description = "REST API. -15% procesamiento." }
        );
    }
}
