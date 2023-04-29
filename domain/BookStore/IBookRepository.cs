namespace BookStore;

public interface IBookRepository
{
    Book[] GetAllByIsbn(string isbn);
    
    Book[] GetAllByTitleOrAuthor(string query);
}