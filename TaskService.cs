using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace TaskManager
{
    public class TaskService
    {
        // 1. - Dependency Injection of DbContext
        private readonly AppDbContext _db;

        // 2. - Constructor
        public TaskService(AppDbContext db)
        {
            _db = db;
        }

        // 3. - CRUD operations   
        public void AddTask(TaskItem task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        // 4. - Retrieve tasks
        public List<TaskItem> GetTasks()
        {
            return _db.Tasks.ToList();
        }

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

        // 5. - Delete task
        public bool DeleteTask(int id)
        {
            var task = _db.Tasks.Find(id);
            if (task == null) return false;

            _db.Tasks.Remove(task);
            _db.SaveChanges();
            return true;
        }
    }
}