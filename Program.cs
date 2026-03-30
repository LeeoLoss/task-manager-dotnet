using System.Security.Cryptography.X509Certificates;
using Microsoft.Identity.Client;
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
                    var priority = int.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("Informe the task status (0 - Not Started, 1 - In Progress, 2 - Completed):");
                    var status = int.Parse(Console.ReadLine() ?? "0");

                    // 3.1 - Create a new task object with the provided details
                    var priorityEnum = (TaskPriority)priority;
                    var statusEnum = (TaskStatus)status;
                    var task = new TaskItem
                    {
                        Title = title,
                        Description = description,
                        Priority = (TaskPriority)priority,
                        Status = (TaskStatus)status,
                    };

                    Console.WriteLine("Please confirm the task details:");
                    Console.WriteLine($"Title: {task.Title}, Description: {task.Description}, Priority: {task.Priority}, Status: {task.Status}, IsCompleted: {task.IsCompleted}");
                        
                    Console.WriteLine("Is the information correct? (Y/N)");
                    var confirmation = Console.ReadLine();
                    if (confirmation == "y")
                    {
                        service.AddTask(task);
                        Console.WriteLine($"Task '{task.Title}' added successfully with ID: {task.Id}!");
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
                    Console.WriteLine("Please enter the task ID to edit or delete: ");
                    if (!int.TryParse(Console.ReadLine(), out var id))
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine("Do you want to edit (E) or delete (D) the task?");
                    var action = Console.ReadLine()?.ToUpper();    

                    if (action == "E")
                            {
                                Console.WriteLine("Please enter the new task title:");   
                                var title = Console.ReadLine() ?? "Untitled Task";

                                Console.WriteLine("Please enter the new task description:");
                                var description = Console.ReadLine();

                                Console.WriteLine("Inform the new task priority (0 - Low, 1 - Medium, 2 - High):");
                                int.TryParse(Console.ReadLine(), out var priority);

                                Console.WriteLine("Inform the new task status (0 - Not Started, 1 - In Progress, 2 - Completed):");
                                int.TryParse(Console.ReadLine(), out var status);

                                // 5.1 - Create an updated task object with the new details
                                var priorityEnum = (TaskPriority)priority;
                                var statusEnum = (TaskStatus)status;
                                var updatedTask = new TaskItem
                                {
                                    Title = title,
                                    Description = description,
                                    Priority = (TaskPriority)priority,
                                    Status = (TaskStatus)status,
                                };
                                var success = service.UpdateTask(id, updatedTask);
                                if (success)                                {
                                    Console.WriteLine($"Task with ID {id} updated successfully!");
                                }
                                else
                                {
                                    Console.WriteLine($"Task with ID {id} not found.");
                                }

                            }
                            else if (action == "D")
                            {
                                var success = service.DeleteTask(id);
                                if (success)
                                {
                                    Console.WriteLine($"Task with ID {id} deleted successfully!");
                                }
                                else
                                {
                                    Console.WriteLine($"Task with ID {id} not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid action. Please enter 'E' to edit or 'D' to delete.");
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