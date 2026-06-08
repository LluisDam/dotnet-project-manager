using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Models;
using ProjectManager.Services;

namespace ProjectManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectContext _context;
    private readonly KpiService _kpiService;

    public ProjectsController(ProjectContext context, KpiService kpiService)
    {
        _context = context;
        _kpiService = kpiService;
    }

    [HttpGet]
    public async Task<IEnumerable<Project>> GetAll() =>
        await _context.Projects.Include(p => p.Tasks).Include(p => p.Sprints).ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetById(int id)
    {
        var project = await _context.Projects.Include(p => p.Tasks).Include(p => p.Sprints)
            .FirstOrDefaultAsync(p => p.Id == id);
        return project is null ? NotFound() : Ok(project);
    }

    [HttpGet("{id}/kpi")]
    public ActionResult GetKpi(int id) => Ok(_kpiService.GetProjectKpis(id));

    [HttpGet("kpi")]
    public ActionResult GetGlobalKpi() => Ok(_kpiService.GetGlobalKpis());

    [HttpPost]
    public async Task<ActionResult<Project>> Create(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Project project)
    {
        if (id != project.Id) return BadRequest();
        _context.Entry(project).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project is null) return NotFound();
        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
