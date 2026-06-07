namespace ProjectManager.Models;

public enum ProjectStatus { Pending, InProgress, Completed, Cancelled }

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public ProjectStatus Status { get; set; } = ProjectStatus.Pending;
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; set; }
    public string? KitDigitalCode { get; set; }
    public decimal KitDigitalAmount { get; set; }
    public List<ProjectTask> Tasks { get; set; } = new();
    public List<Sprint> Sprints { get; set; } = new();
}
