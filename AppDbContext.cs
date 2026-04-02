using Microsoft.EntityFrameworkCore;
using TaskManager;

namespace TaskManager;

public class AppDbContext : DbContext
{
    // 1.- Create a DbContext class to manage database operations
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // 2. - Create a DbSet for the TaskItem class
    public DbSet<TaskItem> Tasks { get; set; }
}