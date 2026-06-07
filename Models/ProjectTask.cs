namespace ProjectManager.Models;

public enum TaskStatus { Todo, InProgress, Done }
public enum Priority { Low, Medium, High }

public class ProjectTask
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public Project? Project { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskStatus Status { get; set; } = TaskStatus.Todo;
    public Priority Priority { get; set; } = Priority.Medium;
    public int StoryPoints { get; set; }
    public string? Assignee { get; set; }
    public int? SprintId { get; set; }
    public Sprint? Sprint { get; set; }
}
