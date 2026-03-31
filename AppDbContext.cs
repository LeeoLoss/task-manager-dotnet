using Microsoft.EntityFrameworkCore;
using TaskManager;

namespace TaskManager;

public class AppDbContext : DbContext
{
    // O construtor recebe as configurações que vêm lá do Program.cs
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> Tasks { get; set; }
}