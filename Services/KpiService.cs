using ProjectManager.Models;

namespace ProjectManager.Services;

public class KpiService
{
    private readonly ProjectContext _context;
    public KpiService(ProjectContext context) => _context = context;

    public object GetProjectKpis(int projectId)
    {
        var tasks = _context.Tasks.Where(t => t.ProjectId == projectId).ToList();
        var sprints = _context.Sprints.Where(s => s.ProjectId == projectId).ToList();
        var totalPoints = tasks.Sum(t => t.StoryPoints);
        var donePoints = tasks.Where(t => t.Status == TaskStatus.Done).Sum(t => t.StoryPoints);
        return new {
            TotalTasks = tasks.Count,
            Done = tasks.Count(t => t.Status == TaskStatus.Done),
            InProgress = tasks.Count(t => t.Status == TaskStatus.InProgress),
            Todo = tasks.Count(t => t.Status == TaskStatus.Todo),
            TotalStoryPoints = totalPoints,
            CompletedPoints = donePoints,
            CompletionRate = totalPoints > 0 ? Math.Round((double)donePoints / totalPoints * 100, 1) : 0,
            Sprints = sprints.Count
        };
    }

    public object GetGlobalKpis()
    {
        var projects = _context.Projects.ToList();
        return new {
            TotalProjects = projects.Count,
            Completed = projects.Count(p => p.Status == ProjectStatus.Completed),
            InProgress = projects.Count(p => p.Status == ProjectStatus.InProgress),
            Pending = projects.Count(p => p.Status == ProjectStatus.Pending),
            CompletionRate = projects.Count > 0
                ? Math.Round((double)projects.Count(p => p.Status == ProjectStatus.Completed) / projects.Count * 100, 1) : 0,
            TotalBudget = projects.Sum(p => p.Budget)
        };
    }
}
