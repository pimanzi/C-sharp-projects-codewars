using LibraryApp.Models;
using LibraryApp.DTOs;
namespace LibraryApp.Repositories.Interfaces;

public interface IBookRepository
{
    List<Book> GetAll();
    Book? GetById(int id);
    void Add(Book book);
    void Update(int id, UpdateBookDto dto);
    void Delete(int id);


    List<Book> GetByAuthor(string author);
    List<Book> GetByTitle(string title);

    List<Book> GetSortedByNewest();
    List<Book> GetSortedByOldest();
}