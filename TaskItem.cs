using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager;

// 1. Enums definidos aqui para o C# encontrar
public enum TaskPriority
{   
    Low,
    Medium,
    High
}

public enum TaskStatus
{
    NotStarted,
    InProgress,
    Completed
}

// 2. A Classe TaskItem
public class TaskItem
{
    [Key]
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public TaskPriority Priority { get; set; }
    
    public TaskStatus Status { get; set; }

    [NotMapped]
    public bool IsCompleted => this.Status == (TaskStatus)2;
    
}
