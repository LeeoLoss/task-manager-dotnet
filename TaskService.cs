using System.Diagnostics.Contracts;
using Microsoft.VisualBasic;

namespace TaskManager
{
    public class TaskService
    {
        private int nextId = 1;
        // 1 - Create a list to store tasks
        private List<TaskItem> tasks = new List<TaskItem>();

        // 2. - Create a method to add a new task to the list
        public void AddTask(TaskItem task)
        {
            task.Id = nextId++;
            tasks.Add(task);    
        }

        // 3. - Create a method to get the list of tasks
        public bool UpdateTask(int id, TaskItem updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return false;
            }
            else
            {
                task.Title = updatedTask.Title;
                task.Description = updatedTask.Description;
                task.Priority = updatedTask.Priority;
                task.Status = updatedTask.Status;
                return true;
            }
        }

        // 4. - Create a method to delete a task by its id
        public bool DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return false;
            }
            else
            {
                tasks.Remove(task);
                return true;
            }
        }

        // 5. - Create a method to get the list of tasks
        public List<TaskItem> GetTasks()
        {
            return tasks;
        }

    }
}


