using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskManager;


    // 1. - Create enums for task priority and status
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
    // 2. - Create a class to represent a task (TaskItem)
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public bool IsCompleted => Status == TaskStatus.Completed;
    }
