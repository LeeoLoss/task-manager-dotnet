using Microsoft.EntityFrameworkCore;

namespace TaskManager
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=tcp:db-task-manager.database.windows.net,1433;Initial Catalog=srv-leo-tasks;Persist Security Info=False;User ID=adminLeo;Password=Akxp0209;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            optionsBuilder.UseSqlServer(connectionString, sqlOptions =>
            {
                // Esta linha faz o app tentar conectar de novo caso a internet falhe por um segundo
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5, 
                    maxRetryDelay: TimeSpan.FromSeconds(30), 
                    errorNumbersToAdd: null);
            });
        }
    }
}