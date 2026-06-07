namespace ProjectManager.Models;

public class Sprint
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Goal { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int PlannedVelocity { get; set; }
    public int ActualVelocity { get; set; }
    public List<ProjectTask> Tasks { get; set; } = new();
}
