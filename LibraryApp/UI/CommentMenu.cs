using LibraryApp.Services;
using LibraryApp.Helpers;
using LibraryApp.Models;
using LibraryApp.DTOs;
namespace LibraryApp.UI;


public class  CommentMenu {

private readonly CommentService _commentService;

public CommentMenu(CommentService commentService){
_commentService= commentService;
}

public void AddCommentForBook (){
    Console.Write("Enter book id to add comments for: ");
    string bookId = Console.ReadLine();

  while (!int.TryParse(bookId, out int value)){
    Console.Write("Please enter correct id format. It shoud be digits: ");
    bookId = Console.ReadLine();
  }

  Console.Write("Enter Comment Note: ");
  string comment = Console.ReadLine ();

Comment newComment= new Comment {
    BookId = int.Parse(bookId),
    Note = comment
};
  _commentService.AddComment(newComment);
}


public void UpdateComment (){
    Console.Write("Enter Comment Id to update: ");
    string commentId= Console.ReadLine ();

while (int.TryParse(commentId, out int value)){
    Console.Write("Please enter correct id format. It shoud be digits");
    commentId = Console.ReadLine();
  }


 Console.Write("Enter new Comment Note: ");
  string comment = Console.ReadLine ();


 
   

  _commentService.UpdateComment(int.Parse(commentId), comment);

}


public void DeleteComment (){
    Console.Write("Enter Comment Id to delete: ");
    string commentId= Console.ReadLine ();

while (int.TryParse(commentId, out int value)){
    Console.Write("Please enter correct id format. It shoud be digits");
    commentId = Console.ReadLine();
  }

  _commentService.DeleteComment(int.Parse(commentId));
}
}