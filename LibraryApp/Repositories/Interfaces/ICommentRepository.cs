using LibraryApp.Models;
namespace LibraryApp.Repositories.Interfaces;

public interface ICommentRepository
{
      
    void Add(Comment comment);
    void Update(int id, string note);
    void Delete(int id);
}