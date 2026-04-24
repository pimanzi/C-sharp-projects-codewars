using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models;

public class Comment
{
    public int Id { get; set; }

    [MinLength(10, ErrorMessage = "Comment must be at least 10 characters")]
    [MaxLength(500, ErrorMessage = "Comment cannot exceed 500 characters")]
    public string Note { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}