using Library.Repository.Context;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class RentBookRepository : IRentBookRepository
    {
        private readonly LibraryContext _context;

        public RentBookRepository(LibraryContext context)
        {
            _context = context;
        }

        public bool ReturnBook(int bookId, int userId)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            var user = _context.Users.FirstOrDefault(x => x.UserModelId == userId);
            if (book == null || user == null || book.UserModelId == -1) return false;

            book.UserModelId = -1;

            _context.Books.Update(book).State = EntityState.Modified;
            _context.Users.Update(user).State = EntityState.Modified;

            _context.SaveChanges();
            return true;
        }

        public bool RentBook(int bookId, int userId)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            var user = _context.Users.FirstOrDefault(x => x.UserModelId == userId);
            if (book == null || user == null || book.UserModelId != -1) return false;

            book.UserModelId = user.UserModelId;

            _context.Books.Update(book).State = EntityState.Modified;
            _context.Users.Update(user).State = EntityState.Modified;

            _context.SaveChanges();
            return true;
        }
    }
}
