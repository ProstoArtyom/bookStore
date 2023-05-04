namespace BookStore.Tests;

public class StudBookRepository : IBookRepository
{
    public Book[] ResultOfGetAllByIsbn { get; set; }
    
    public Book[] ResultOfGetAllByTitleOrAuthor { get; set; }

    public Book[] GetAllByIsbn(string isbn)
    {
        return ResultOfGetAllByIsbn;
    }

    public Book[] GetAllByTitleOrAuthor(string query)
    {
        return ResultOfGetAllByTitleOrAuthor;
    }

    public Book GetById(int id)
    {
        throw new NotImplementedException();
    }
}