using Microsoft.EntityFrameworkCore;
using TaskManager;

var builder = WebApplication.CreateBuilder(args);

// 1. - Configure DbContext to use SQL Server with Azure connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSqlConnection"), 
    sqlOptions => 
    {
        // Enable retry on failure for transient faults
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5, 
            maxRetryDelay: TimeSpan.FromSeconds(30), 
            errorNumbersToAdd: null);
    }));

// 2. - Configure Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. - Activate Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

// --- API Routes ---

// 4. - Create API endpoints for CRUD operations on TaskItem
app.MapGet("/tasks", async (AppDbContext db) => 
    await db.Tasks.ToListAsync());

// 5. - Get a single task by ID
app.MapPost("/tasks", async (TaskManager.TaskItem task, AppDbContext db) =>
{
    db.Tasks.Add(task);
    await db.SaveChangesAsync();
    return Results.Created($"/tasks/{task.Id}", task);
});

// 6. - Update a task
app.MapDelete("/tasks/{id}", async (int id, AppDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null) return Results.NotFound();

    db.Tasks.Remove(task);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// 7. - Run the application
app.Run();
