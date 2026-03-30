namespace TaskManager
{
    // 1. - Create a class to represent a task item
    public enum TaskPriority
    {
        Low = 0,
        Medium = 1,
        High = 2
    }

    // 2. - Create an enum to represent task status
    public enum TaskStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2
    }
    public class TaskItem
    {
        public int Id { get; internal set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public bool IsCompleted => Status == TaskStatus.Completed;
    }
}