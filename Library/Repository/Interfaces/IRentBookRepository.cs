namespace Library.Repository.Interfaces
{
    public interface IRentBookRepository
    {
        bool ReturnBook(int bookId, int userId);
        bool RentBook(int bookId, int userId);
    }
}
