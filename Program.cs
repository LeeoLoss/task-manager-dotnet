using TaskManager;
namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. - Call the TaskService to manage tasks
            var service = new TaskService();

            // 2. - Add a menu to add a new task or show the list of tasks
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Task Manager!");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add a new task");
                Console.WriteLine("2. Show the list of tasks");
                Console.WriteLine("3. Edit or delete a task");
                Console.WriteLine("4. Exit");

            var option = Console.ReadLine();

            // 3. - Implement the logic to add a new task
            switch (option)
            {
                case "1":
                {
                    Console.WriteLine("Please enter the task title:");
                    var title = Console.ReadLine();

                    Console.WriteLine("Please enter the task description:");
                    var description = Console.ReadLine();

                    Console.WriteLine("Inform the task priority (0 - Low, 1 - Medium, 2 - High):");
                    var priority = int.Parse(Console.ReadLine());

                    Console.WriteLine("Informe the task status (0 - Not Started, 1 - In Progress, 2 - Completed):");
                    var status = int.Parse(Console.ReadLine());

                    var task = new TaskItem
                    {
                        Id = service.GetTasks().Count + 1,
                        Title = title,
                        Description = description,
                        Priority = priority,
                        Status = status,
                        IsCompleted = status == 2
                    };

                    Console.WriteLine("Please confirm the task details:");
                    Console.WriteLine($"Id: {task.Id}, Title: {task.Title}, Description: {task.Description}, Priority: {task.Priority}, Status: {task.Status}, IsCompleted: {task.IsCompleted}");
                    
                    Console.WriteLine("Is the information correct? (y/n)");
                    var confirmation = Console.ReadLine();
                    if (confirmation == "y")
                    {
                        service.AddTask(task);
                        Console.WriteLine("Task added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Task not added. Please try again.");
                    }
                    
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                break;
                }

            // 4. - Implement the logic to show the list of tasks
                case "2":
                {
                        Console.WriteLine("Informations about the Task List:");
                        var tasks = service.GetTasks();
                        
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks found.");
                        }
                        
                        foreach (var t in tasks)                    
                        {
                            Console.WriteLine($"Id: {t.Id}, Title: {t.Title}, Description: {t.Description}, Priority: {t.Priority}, Status: {t.Status}, IsCompleted: {t.IsCompleted}");
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                break;
                }

                // 5. - Implement the logic to edit or delete a task
                case "3":
                {
                    Console.WriteLine("Please enter the task Id to edit or delete: ");
                    var taskId = int.Parse(Console.ReadLine());
                    var taskToEdit = service.GetTasks().FirstOrDefault(t => t.Id == taskId);

                    if (taskToEdit == null)
                    {
                        Console.WriteLine("Task not found. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }

                    if (taskToEdit != null)
                        {                        
                            Console.WriteLine("Please select an option:");
                            Console.WriteLine("1. Edit the task");
                            Console.WriteLine("2. Delete the task");
                            var editOption = Console.ReadLine();
                            
                            if (editOption == "1")
                            {
                                Console.WriteLine("Please enter the new task title:");
                                var newTitle = Console.ReadLine();

                                Console.WriteLine("Please enter the new task description:");
                                var newDescription = Console.ReadLine();

                                Console.WriteLine("Inform the new task priority (0 - Low, 1 - Medium, 2 - High):");
                                var newPriority = int.Parse(Console.ReadLine());

                                Console.WriteLine("Informe the new task status (0 - Not Started, 1 - In Progress, 2 - Completed):");
                                var newStatus = int.Parse(Console.ReadLine());

                                taskToEdit.Title = newTitle;
                                taskToEdit.Description = newDescription;
                                taskToEdit.Priority = newPriority;
                                taskToEdit.Status = newStatus;
                                taskToEdit.IsCompleted = newStatus == 2;

                                Console.WriteLine("Task updated successfully!");
                            }
                            else if (editOption == "2")
                            {
                                service.GetTasks().Remove(taskToEdit);
                                Console.WriteLine("Task deleted successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid option. Please try again.");
                            }
                        }

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                break;
                }

                // 6. - Implement the logic to exit the application
                case "4":
                {
                    Console.WriteLine("Thank you for using the Task Manager!");
                break;
                }
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                break;
                }
        }
    }
    }
}  



