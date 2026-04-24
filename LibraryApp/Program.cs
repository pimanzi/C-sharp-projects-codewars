using LibraryApp.Services;
using LibraryApp.Repositories;
using LibraryApp.Models;
using LibraryApp.UI;
using LibraryApp.Data;

namespace LibraryApp;


public class Program
{
    public static void Main(string[] args)
    {
        
        using var context = new LibraryContext();

        var bookRepository    = new BookRepository(context);
        var commentRepository = new CommentRepository(context);

        var bookService    = new BookService(bookRepository);
        var commentService = new CommentService(commentRepository);

        var bookMenu    = new BookMenu(bookService);
        var commentMenu = new CommentMenu(commentService);

        var app = new ConsoleApp(bookMenu, commentMenu);

        bool running = true;
        while (running)
        {
            app.ShowMenu();
            running = app.FlowMenu();
        }

        Console.WriteLine("Goodbye!");
    }
}