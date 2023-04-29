using BookStore;

namespace Store.Memory;

public class BookRepository : IBookRepository
{
    private readonly Book[] books = {
        new Book(1, "Art of Programming", "D. Knuth", "ISBN 12312-31231"),
        new Book(2, "Refactoring", "M. Fowler", "ISBN 12312-31232"),
        new Book(3, "C Programming Language", "B. Kerninghan, D. Ritchie", "ISBN 12312-31233")
    };

    public Book[] GetAllByIsbn(string isbn)
    {
        return books.Where(book => book.Isbn == isbn)
                    .ToArray();
    }

    public Book[] GetAllByTitleOrAuthor(string query)
    {
        return books.Where(book => book.Title.Contains(query)
                                || book.Author.Contains(query))
                    .ToArray();
    }
}