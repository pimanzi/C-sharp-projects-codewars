namespace ToDoApp.Models;

public enum Status
{
    todo,
    inProgress,
    completed
}

public class ToDoItem
{
    private string _title;
    private Status _status;
    private DateTime _date;
    private Guid _id;
    
    public ToDoItem(string title, Status status, DateTime date, Guid  id)
    {
        this.Title = title;
        this.Status = status;
        this._date = date;
        this.Id = id.ToString();
    }

    public string Title
    {
        get { return _title; }
        set
        {
            if (value.Length == 0)
            {
                Console.WriteLine("Please give your title at least one character,");
                return;
            }

            this._title = value;
        }
    }

    public Status Status
    {
        get { return _status; }
        set { _status = value; }
    }

    public DateTime Date { get; }
    public string Id { get; set; }

    public  override string ToString()
    {
        return $"Title: {Title} of this  Status: {Status} was successfully created at {Date}";
    }
}