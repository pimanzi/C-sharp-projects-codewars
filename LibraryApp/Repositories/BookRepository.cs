using LibraryApp.Models;
using LibraryApp.Models.Enums;
using LibraryApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Data;
using LibraryApp.DTOs;
namespace LibraryApp.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    
    public List<Book> GetAll()
    {
        try
        {
            return _context.Books.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting books: {ex.Message}");
            return new List<Book>();
        }
    }

    
    public Book? GetById(int id)
    {
        try
        {
            return _context.Books
                .Include(b => b.Comments)  
                .FirstOrDefault(b => b.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error finding book: {ex.Message}");
            return null;
        }
    }

    
    public void Add(Book book)
    {
        try
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            Console.WriteLine($"Book '{book.Title}' successfully added with Id {book.Id}");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Could not add book: {ex.Message}");
        }
    }

    
    public void Update(int id, UpdateBookDto dto)
{
    try
    {
        var existing = _context.Books.Find(id);

        if (existing == null)
        {
            Console.WriteLine($"Book with Id {id} not found");
            return;
        }

        
        if (dto.Title != null)
            existing.Title = dto.Title;

        if (dto.Author != null)
            existing.Author = dto.Author;

        if (dto.Description != null)
            existing.Description = dto.Description;

        if (dto.Pages != null)
            existing.Pages = dto.Pages.Value;

        if (dto.Genre != null)

            existing.Genre = Enum.Parse <BookGenre> (dto.Genre);

        _context.SaveChanges();
        Console.WriteLine($"Book successfully updated");
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Could not update book: {ex.Message}");
    }
}

   
    public void Delete(int id)
    {
        try
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                Console.WriteLine($"Book with Id {id} not found");
                return;
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            Console.WriteLine($"Book '{book.Title}' successfully deleted");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Could not delete book: {ex.Message}");
        }
    }

    
    public List<Book> GetByAuthor(string author)
    {
        try
        {
            return _context.Books
                .Where(b => b.Author.ToLower().Contains(author.ToLower()))
                .ToList();
               
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error searching by author: {ex.Message}");
            return new List<Book>();
        }
    }

    
    public List<Book> GetByTitle(string title)
    {
        try
        {
            return _context.Books
                .Where(b => b.Title.ToLower().Contains(title.ToLower()))
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error searching by title: {ex.Message}");
            return new List<Book>();
        }
    }

    
    public List<Book> GetSortedByNewest()
    {
        try
        {
            return _context.Books
                .OrderByDescending(b => b.CreatedAt)
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sorting books: {ex.Message}");
            return new List<Book>();
        }
    }

   
    public List<Book> GetSortedByOldest()
    {
        try
        {
            return _context.Books
                .OrderBy(b => b.CreatedAt)
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sorting books: {ex.Message}");
            return new List<Book>();
        }
    }
}