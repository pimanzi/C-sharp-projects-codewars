
namespace LibraryApp.UI;
public class ConsoleApp{

    public readonly BookMenu _bookMenu;
    public readonly CommentMenu _commentMenu;

    public ConsoleApp (BookMenu bookMenu, CommentMenu commentMenu){
_bookMenu= bookMenu;
_commentMenu= commentMenu;

    }


public void ShowMenu (){
    Console.WriteLine("================================");
    Console.WriteLine("Library menu: choose an option ");
    Console.WriteLine("================================");

  Console.WriteLine ("1. See all books ");
  Console.WriteLine ("2. View Details of a book");
  Console.WriteLine ("3. Create a book");
  Console.WriteLine ("4. Update a book");
  Console.WriteLine ("5. Delete a book");
  Console.WriteLine ("6. Search Book (by author, title)");
  Console.WriteLine ("7.  Sort Books (ascending or descending)");

  Console.WriteLine ("8. Add Comments for a book");
  Console.WriteLine ("9. Update a comment");
  Console.WriteLine ("10. Delete a comment");
Console.WriteLine(" 0. Quit Application");
Console.WriteLine ("================================");

}



public bool FlowMenu()
{
    Console.Write("Enter option number: ");
    string value = Console.ReadLine() ?? "";

    while (!int.TryParse(value, out int intValue) || intValue > 10)
    {
        Console.Write("Please enter a valid option (0-10): ");
        value = Console.ReadLine() ?? "";
    }

    switch (int.Parse(value))
    {
        case 1:
            _bookMenu.SeeBooks();
            break;

        case 2:
            _bookMenu.SeeOneBook();
            break;

        case 3:
            _bookMenu.AddBook();
            break;

        case 4:
            _bookMenu.UpdateBook();
            break;

        case 5:
            _bookMenu.DeleteBook();
            break;

        case 6:
            Console.Write("Filter by (author or title): ");
            string filter = Console.ReadLine() ?? "";

            while (filter.ToLower() != "author" && filter.ToLower() != "title")
            {
                Console.Write("Please enter either author or title: ");
                filter = Console.ReadLine() ?? "";
            }

            if (filter.ToLower() == "author")
                _bookMenu.SearchBookByAuthor();
            else
                _bookMenu.SearchBookByTitle();
            break;

        case 7:
            Console.Write("Sort (ascending or descending): ");
            string sort = Console.ReadLine() ?? "";

            while (sort.ToLower() != "ascending" && sort.ToLower() != "descending")
            {
                Console.Write("Please enter either ascending or descending: ");
                sort = Console.ReadLine() ?? "";
            }

            if (sort.ToLower() == "ascending")
                _bookMenu.GetOldestBooks();
            else
                _bookMenu.GetNewestBooks();
            break;

        case 8:
            _commentMenu.AddCommentForBook();
            break;

        case 9:
            _commentMenu.UpdateComment();
            break;

        case 10:
            _commentMenu.DeleteComment();
            break;

        case 0:
            return false; 

        default:
            Console.WriteLine("Option not found");
            break;
    }

    return true;
}
}