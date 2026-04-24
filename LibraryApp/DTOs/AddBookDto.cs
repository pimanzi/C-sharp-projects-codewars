using LibraryApp.Models;
using LibraryApp.Models.Enums;
namespace LibraryApp.DTOs;


public class AddBookDto
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ? Description { get; set; }
    public int Pages { get; set; }
    public string  Genre { get; set; }
}