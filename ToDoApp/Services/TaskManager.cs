using System.Linq;
using ToDoApp.Models;

namespace ToDoApp.Services;

public class TaskManager
{
    private  static List<ToDoItem> _items = new List<ToDoItem>();

    public static void  AddTask(string title, Status? status)
    {
        Status itemStatus = status.HasValue ? status.Value : Status.todo;
        DateTime createdAt= DateTime.Now;
        Guid newId = Guid.NewGuid();
        ToDoItem item = new ToDoItem(title,itemStatus, createdAt, newId);
        _items.Add(item);
       Console.WriteLine(item.ToString());
       Console.WriteLine($"Please keep this id for future operations {newId}");
    }

    public static void RemoveTask(string id)
    {
        bool idExist = _items.Any(x => x.Id == id);
        if (idExist)
        {
            _items.RemoveAll(task => task.Id == id);
            Console.WriteLine($"Task of this {id} has been removed ");
        }
        else
        {
            Console.WriteLine($"Task of this {id} not found");
        }
        
    }
    
}