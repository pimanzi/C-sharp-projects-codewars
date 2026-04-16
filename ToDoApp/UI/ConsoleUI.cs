using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.UI;

public class ConsoleUI{
private static int[] menuList = { 1, 2 ,3};
private static string[] statusList = { "todo", "inProgress", "completed" };

    public static bool CheckInput( string input)
    {
            int menuStep = int.Parse(input);
            return menuList.Contains(menuStep);
        
    }
    
    public static  bool CheckInput( string title, string status )
    {
        if (title.Length == 0 || !statusList.Contains(status))
        {
            return false;
        }

        return true;

    }

    public static void Action(int option)
    {
        switch (option)
        {
            case 1:
                Console.Write("Enter task title ");
                string title = Console.ReadLine();
                Console.Write("Enter task status ");
                string status = Console.ReadLine();
                while  (!CheckInput(title, status))
            {
                Console.WriteLine("Please enter title with atleast 1 character and a valid status (todo,  inProgress, completed)");
                Console.Write("Enter task title: ");
                title = Console.ReadLine();
                Console.Write("Enter task status: ");
                status = Console.ReadLine();
            }
                    if (status == "todo")
                    {
                        TaskManager.AddTask(title, Status.todo);
                    }
                    else if (status == "inProgress")
                    {
                        TaskManager.AddTask(title, Status.inProgress);
                    }
                    else if (status == "completed")
                    {
                        TaskManager.AddTask(title, Status.completed);
                    }

                    break;
            case 2:
                Console.Write("Enter the id of the task to delete: ");
                string input = Console.ReadLine();
                TaskManager.RemoveTask(input);
                break;
                
            case 3: 
                Console.Write("Thanks for using our application");
                break;
            default:
                    Console.WriteLine("Currently working on other steps");
                    break;
                
            }
    }
}