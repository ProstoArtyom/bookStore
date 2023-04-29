using System.Text.RegularExpressions;

namespace BookStore;
public class Book
{
    public int Id { get; }

    public string Title { get; }
    
    public string Author { get; }
    
    public string Isbn { get; }
    
    public Book(int id, string title, string author, string isbn)
    {
        Id = id;
        Title = title;
        Author = author;
        Isbn = isbn;
    }

    internal static bool IsIsbn(string s)
    {
        if (s == null)
            return false;

        s = s.Replace("-", "")
             .Replace(" ", "")
             .ToUpper();

        return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");
    }
}
