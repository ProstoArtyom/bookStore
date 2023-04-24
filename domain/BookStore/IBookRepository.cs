namespace BookStore;

public interface IBookRepository
{
    Book[] GetAllByTitle(string titlePart);
}