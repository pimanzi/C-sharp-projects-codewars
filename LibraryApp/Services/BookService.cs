using LibraryApp.Models;
using LibraryApp.Models.Enums;
using LibraryApp.Repositories.Interfaces;
using LibraryApp.DTOs;

namespace LibraryApp.Services;

public class BookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    
    public List<Book> GetAllBooks()
    {
        return _repository.GetAll();
    }

    
    public Book? GetBookById(int id)
    {
        var book = _repository.GetById(id);

        if (book == null)
            Console.WriteLine($"Book with id {id} was not found");

        return book;
    }

    
    public void AddBook(AddBookDto book)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
        {
            Console.WriteLine("Title is required");
            return;
        }

        if (book.Title.Length > 100)
        {
            Console.WriteLine("Title cannot exceed 100 characters");
            return;
        }

        if (string.IsNullOrWhiteSpace(book.Author))
        {
            Console.WriteLine("Author is required");
            return;
        }

        if (book.Author.Length > 50)
        {
            Console.WriteLine("Author cannot exceed 50 characters");
            return;
        }

        if (book.Pages <= 0)
        {
            Console.WriteLine("Pages must be greater than 0");
            return;
        }

        if (!Enum.TryParse<BookGenre>(book.Genre, ignoreCase: true, out BookGenre genre))
        {
            Console.WriteLine("Invalid genre.");
            return;
        }

        var newBook = new Book
        {
            Title = book.Title,
            Author = book.Author,
            Description = book.Description,
            Pages = book.Pages,
            Genre = genre
        };
        _repository.Add(newBook);
    }

    
    public void UpdateBook(int id, UpdateBookDto dto)
    {
       
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            dto.Title= null;
        }

        if (string.IsNullOrWhiteSpace(dto.Author))
        {
            dto.Title= null;
        }

    if (string.IsNullOrWhiteSpace(dto.Pages.ToString())){
        dto.Pages= null;
       }
    
        if (dto.Pages <= 0)
        {
            Console.WriteLine("Pages must be greater than 0");
            return;
        }
       
        if (string.IsNullOrWhiteSpace(dto.Genre)){
        dto.Genre= null;
       }
    
      
        if (Enum.TryParse<BookGenre>(dto.Genre, ignoreCase: true, out BookGenre genre))
        {
            Console.WriteLine("Please provide a valid genre");
            return;
        }



        _repository.Update(id, dto);
    }

   
    public void DeleteBook(int id)
    {
        if (id <= 0)
        {
            Console.WriteLine("Please provide a valid id");
            return;
        }

        _repository.Delete(id);
    }

    
    public List<Book> SearchByAuthor(string author)
    {
        if (string.IsNullOrWhiteSpace(author))
        {
            Console.WriteLine("Please provide an author name to search");
            return new List<Book>();
        }

        return _repository.GetByAuthor(author);
    }

    
    public List<Book> SearchByTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Please provide a title to search");
            return new List<Book>();
        }

        return _repository.GetByTitle(title);
    }

    public List<Book> GetNewestBooks()
    {
        return _repository.GetSortedByNewest();
    }

    
    public List<Book> GetOldestBooks()
    {
        return _repository.GetSortedByOldest();
    }
}