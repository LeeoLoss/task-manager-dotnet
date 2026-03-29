using System.Diagnostics.Contracts;

namespace TaskManager
{
    public class TaskService
    {
        // 1 - Create a list to store tasks
        private List<TaskItem> tasks = new List<TaskItem>();

        // 2. - Add some sample tasks to the list
        public TaskService()
        {
        
        tasks.Add(new TaskItem { Id = 1, Title = "Study and Practice C# and .NET", Description = "Milk, Bread, Eggs", 
                Priority = 2, Status = 0, IsCompleted = false });

        tasks.Add(new TaskItem { Id = 2, Title = "Complete the project report", Description = "Finish the report for the project by Friday",
                Priority = 1, Status = 0, IsCompleted = false });

        tasks.Add(new TaskItem { Id = 3, Title = "Attend the meeting", Description = "Attend the meeting with the team",
                Priority = 0, Status = 0, IsCompleted = false });
        }

        // 3. - Method to add a new task to the list
        public void AddTask(TaskItem task)
        {            
            tasks.Add(task);
        }

        // 4. - Method to return the list of tasks
        public List<TaskItem> GetTasks()
        {
            return tasks;
        }


    }
}


