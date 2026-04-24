using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using  LibraryApp.Models.Enums;

namespace LibraryApp.Models;

public class Book
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int Pages { get; set; }

    [Required, MaxLength(50)]
    public string Author { get; set; } = null!;

  public BookGenre Genre { get; set; }
     public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Comment> Comments { get; set; } = null!;
}