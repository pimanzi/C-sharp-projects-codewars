using LibraryApp.Services;
using LibraryApp.Helpers;
using LibraryApp.Models;
using LibraryApp.DTOs;
namespace LibraryApp.UI;

public class BookMenu {

private readonly BookService _bookService ;

public BookMenu (BookService bookService){
       _bookService= bookService;
}

public void  SeeBooks (){
   Console.WriteLine("================================");
    Console.WriteLine("          All Books        ");
    Console.WriteLine("================================");


List<Book> allBooks= _bookService.GetAllBooks();

foreach (Book book in  allBooks){
  Console.WriteLine("--------------------------------");
   Console.WriteLine($"     Book {book.Id}     ");
    Console.WriteLine ($" Title: {book.Title}");
    Console.WriteLine ($"Author: {book.Author}");
    Console.WriteLine("--------------------------------");
}

}

public void  SeeOneBook (){
    bool funcContinue= true ;
    while (funcContinue){
    Console.Write("\n Enter the id of the book you want to see:  ");
   string input = Console.ReadLine ();

   if (int.TryParse(input, out int userInput)){
    Book specificBook = _bookService.GetBookById(userInput);
   
   if (specificBook == null){
    Console.WriteLine ($"\n Oooops Book with ${userInput} is not found" );
    return ;
   }

  Console.WriteLine ($"Book id: {specificBook.Id}");
   Console.WriteLine($"Book Title: {specificBook.Title}");
   Console.WriteLine ($"Book Author: {specificBook.Author}");
   Console.WriteLine ($"Book Genre: {specificBook.Genre}");
   Console.WriteLine ($"Book created at: {specificBook.CreatedAt}");
   string? description = specificBook.Description ?? "No description available";
   Console.WriteLine ($"Book description: {description}");
   Console.WriteLine ($"Book pages number: {specificBook.Pages}");

   Console.WriteLine ("=================================");
   Console.WriteLine ("=======Comments for this Book========");

   ICollection<Comment>? comments= specificBook.Comments;

if (comments == null || comments.Count == 0){
    Console.WriteLine ("There are no comments for this book.");
}
   foreach (Comment  comment in comments ?? new List<Comment>()){

    Console.WriteLine (comment.Note);
   Console.WriteLine (comment.CreatedAt);
   }

   Console.Write ("Do you want to check details for another book (yes/no)? ");
   string input2=  Console.ReadLine();
   List <string> check= new List<string> {"yes", "no"};
  while (!check.Contains(input2.ToLower())){
  Console.Write("Please choose between yer or no: ");
   input2 = Console.ReadLine ();
  }

  if (input2== "no"){
    funcContinue= false;
     return;
  }
 

   }
   else{
    Console.WriteLine("Incorrect Id please type Id with correct format: ");
    return; 
   }
    
   }

}

public void  AddBook (){
    Console.WriteLine ("Create a Book \n");
    Console.Write("Enter book title: ");
    string bookTitle= Console.ReadLine();

    Console. Write ("Enter book author: ");
    string bookAuthor= Console.ReadLine();

    Console.Write("Enter book pages number: ");
    string bookPages= Console.ReadLine(); 

    while (!int.TryParse(bookPages, out int bookPagesInput)){
        Console.WriteLine ("Please page number should be in digits");
        Console.Write("Enter book pages number ");
        bookPages= Console.ReadLine(); 

    }
    Console.Write("Description (optional, press enter to skip): ");
    string? description = Console.ReadLine();

Console.WriteLine ("Choose movie genre among the below options");
    LibraryHelper.ShowAvailableGenres();


Console.Write("What's your option?:  ");
string genre= Console.ReadLine();



AddBookDto  book = new AddBookDto{
    Title= bookTitle,
    Author = bookAuthor, 
    Description = description, 
    Pages= int.Parse(bookPages),
    Genre = genre

};

_bookService.AddBook(book);
    
}


public void UpdateBook (){

Console.Write("Enter the id of the book you want to update:  ");
string bookId= Console.ReadLine();
while (!int.TryParse(bookId, out int  value)){
Console.Write("Please enter the correct id : ");
bookId= Console.ReadLine();
}

Console.Write ("Enter new title or click enter for no updates for title: " );
string title = Console.ReadLine ();


Console.Write ("Enter new book author  or click enter for no updates for author name: " );
string author = Console.ReadLine ();


Console.Write ("Enter new book pages  or click  enter for no updates for page name: " );
string pages = Console.ReadLine ();

while (!string.IsNullOrEmpty(pages) && !int.TryParse(pages, out _)){
    Console.Write("Please enter correct pages number:  ");
    pages= Console.ReadLine();
}

Console.Write ("Enter new book genre or click enter for no ypdates for genre name: ");
LibraryHelper.ShowAvailableGenres();

Console.Write("Enter new book genre among above genres: ");
string genre= Console.ReadLine ();

UpdateBookDto updatedBook = new UpdateBookDto {

    Title= title,
    Author= author,
    Pages= string.IsNullOrEmpty(pages) ? null : int.Parse(pages),
    Genre= genre
};

_bookService.UpdateBook(int.Parse(bookId), updatedBook);

}


public void SearchBookByAuthor (){
    Console.Write("Enter the author name to search with: ");
    string authorName= Console.ReadLine ();

    List <Book> result= _bookService.SearchByAuthor(authorName);

    if (result == null){
        _bookService.SearchByAuthor(authorName);
    }

    else{
        Console.WriteLine ($"All Book Created By {authorName}");

        foreach (Book book in result  ){
    Console.WriteLine("--------------------------------");
     Console.WriteLine ($" Title: {book.Title}");
    Console.WriteLine ($"Author: {book.Author}");

    Console.WriteLine("--------------------------------");
        }
    }
}


public void SearchBookByTitle (){
    Console.Write("Enter the name of the book to search: ");
    string bookTitle= Console.ReadLine ();

    List <Book> result= _bookService.SearchByTitle(bookTitle);

    if (result == null){
        _bookService.SearchByTitle(bookTitle);
    }

    else{
        Console.WriteLine ($"All Book with the title {bookTitle}");

        foreach (Book book in result  ){
    Console.WriteLine("--------------------------------");
     Console.WriteLine ($" Title: {book.Title}");
    Console.WriteLine ($"Author: {book.Author}");

    Console.WriteLine("--------------------------------");
        }
    }
}


public void GetNewestBooks (){
    List <Book> result= _bookService.GetNewestBooks();
     foreach (Book book in result  ){
    Console.WriteLine("--------------------------------");
     Console.WriteLine ($" Title: {book.Title}");
    Console.WriteLine ($"Author: {book.Author}");
    Console.WriteLine ($"Created At: {book.CreatedAt}");

    Console.WriteLine("--------------------------------");
        }

}
 
public void GetOldestBooks (){

List <Book> result= _bookService.GetOldestBooks();
     foreach (Book book in result  ){
    Console.WriteLine("--------------------------------");
     Console.WriteLine ($" Title: {book.Title}");
    Console.WriteLine ($"Author: {book.Author}");
    Console.WriteLine ($"Created At: {book.CreatedAt}");

    Console.WriteLine("--------------------------------");
        }
}

public void DeleteBook (){
    Console.Write("Enter Book Id to delete: ");
    string bookId= Console.ReadLine ();

while (!int.TryParse(bookId, out int value)){
    Console.Write("Please enter correct id format. It shoud be digits");
    bookId = Console.ReadLine();
  }

  _bookService.DeleteBook(int.Parse(bookId));


}}