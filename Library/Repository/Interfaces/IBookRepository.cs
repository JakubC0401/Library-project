using Library.Models;

namespace Library.Repository.Interfaces;

public interface IBookRepository
{
    BookModel? Get(int id);
    IEnumerable<BookModel?> GetAll();
    void Add(BookModel? book);
    void Update(int id, BookModel book);
    void Delete(int id);
}