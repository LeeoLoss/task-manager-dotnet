using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace TaskManager
{
    public class TaskService
    {
        // 1. - Create a class to manage the tasks (TaskService)
        private readonly AppDbContext _db = new AppDbContext();
        
        // 2. - Create a method to add a new task
        public void AddTask(TaskItem task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        // 3. - Create a method to retrieve the list of tasks
        public List<TaskItem> GetTasks()
        {
            return _db.Tasks.ToList();
        }

        // 4. - Create a method to update an existing task
        public bool UpdateTask(int id, TaskItem updatedTask)
        {
            var task = _db.Tasks.Find(id);
            if (task == null) return false;
            
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.Priority = updatedTask.Priority;
            task.Status = updatedTask.Status;
            _db.SaveChanges();
            return true;
        }
        // 5. - Create a method to delete a task from the list
        public bool DeleteTask(int id)
        {
            var task = _db.Tasks.Find(id);
            if (task == null)
            {
                return false;
            }
            else
            {
                _db.Tasks.Remove(task);
                _db.SaveChanges();
                return true;
            }
        }
    }
}


