// Repositories/CommentRepository.cs
using LibraryApp.Models;
using LibraryApp.Data;
using LibraryApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly LibraryContext _context;

    public CommentRepository(LibraryContext context)
    {
        _context = context;
    }

   
    public void Add(Comment comment)
    {
        try
        {
            // first check the book actually exists
            var book = _context.Books.Find(comment.BookId);

            if (book == null)
            {
                Console.WriteLine($"Book with Id {comment.BookId} not found");
                return;
            }

            _context.Comments.Add(comment);
            _context.SaveChanges();
            Console.WriteLine($"Comment successfully added to book '{book.Title}'");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Could not add comment: {ex.Message}");
        }
    }

    
    public void Update(int id, string note)
    {
        try
        {
            var existing = _context.Comments.Find(id);

            if (existing == null)
            {
                Console.WriteLine($"Comment with Id {id} not found");
                return;
            }

             existing.Note = note;

            _context.SaveChanges();
            Console.WriteLine($"Comment successfully updated");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Could not update comment: {ex.Message}");
        }
    }

   
    public void Delete(int id)
    {
        try
        {
            var comment = _context.Comments.Find(id);

            if (comment == null)
            {
                Console.WriteLine($"Comment with Id {id} not found");
                return;
            }

            _context.Comments.Remove(comment);
            _context.SaveChanges();
            Console.WriteLine($"Comment successfully deleted");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Could not delete comment: {ex.Message}");
        }
    }
}