namespace LibraryApp.Helpers;
using LibraryApp.Models;
using LibraryApp.Models.Enums;

public static  class LibraryHelper{

public  static  void ShowAvailableGenres()
{
    Console.WriteLine("Available genres:");
    foreach (var genre in Enum.GetNames<BookGenre>())
    {
        Console.WriteLine($"  → {genre}");
    }
}
}