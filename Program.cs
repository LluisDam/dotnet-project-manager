using Microsoft.EntityFrameworkCore;
using ProjectManager.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjectContext>(opt => opt.UseInMemoryDatabase("ProjectManagerDb"));
builder.Services.AddScoped<KpiService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() { Title = "Project Manager API", Version = "v1",
        Description = "API REST para gestion de proyectos agiles con Scrum — Kit Digital" });
});
builder.Services.AddCors(o => o.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<ProjectContext>();
    ctx.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.MapControllers();
app.Run();
