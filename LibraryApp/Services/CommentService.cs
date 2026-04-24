using LibraryApp.Models;
using LibraryApp.DTOs;
using LibraryApp.Repositories.Interfaces;

namespace LibraryApp.Services;

public class CommentService
{
    private readonly ICommentRepository _repository;

    public CommentService(ICommentRepository repository)
    {
        _repository = repository;
    }

    
    public void AddComment(Comment comment)
    {
        if (string.IsNullOrWhiteSpace(comment.Note))
        {
            Console.WriteLine("Please write a valid comment");
            return;
        }

        if (comment.Note.Length < 10)
        {
            Console.WriteLine("Comment must be at least 10 characters");
            return;
        }

        if (comment.Note.Length > 500)
        {
            Console.WriteLine("Comment cannot exceed 500 characters");
            return;
        }

        if (comment.BookId <= 0)
        {
            Console.WriteLine("Please provide a valid book id");
            return;
        }

        _repository.Add(comment);
    }

    
    public void UpdateComment(int id, string note)
    {
        if (id <= 0)
        {
            Console.WriteLine("Please provide a valid id");
            return;
        }

        if (string.IsNullOrWhiteSpace(note))
        {
            Console.WriteLine("Please provide a valid note");
            return;
        }

        if (note.Length < 10)
        {
            Console.WriteLine("Comment must be at least 10 characters");
            return;
        }

        if (note.Length > 500)
        {
            Console.WriteLine("Comment cannot exceed 500 characters");
            return;
        }

       
        _repository.Update(id, note);
    }

  
    public void DeleteComment(int id)
    {
        if (id <= 0)
        {
            Console.WriteLine("Please provide a valid id");
            return;
        }

        _repository.Delete(id);
    }
}