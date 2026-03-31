using Microsoft.EntityFrameworkCore;
using TaskManager;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar o Banco de Dados
builder.Services.AddDbContext<AppDbContext>();

// 2. Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Ativar Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

// --- ROTAS DA API ---

app.MapGet("/tasks", async (AppDbContext db) => 
    await db.Tasks.ToListAsync());

app.MapPost("/tasks", async (TaskManager.TaskItem task, AppDbContext db) =>
{
    db.Tasks.Add(task);
    await db.SaveChangesAsync();
    return Results.Created($"/tasks/{task.Id}", task);
});

app.MapDelete("/tasks/{id}", async (int id, AppDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null) return Results.NotFound();

    db.Tasks.Remove(task);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();