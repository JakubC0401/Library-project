using Library.Models;
using Library.Repository.Context;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    public BookModel? Get(int id)=>_context.Books.FirstOrDefault(x => x.Id == id);

    public IEnumerable<BookModel?> GetAll()=>_context.Books.ToList();
    
    public void Add(BookModel? book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void Update(int id, BookModel book)
    {
        var existingBook = _context.Books.FirstOrDefault(x => x.Id == id);
        if (existingBook == null) return;

        existingBook.Author = book.Author;
        existingBook.Title = book.Title;
        _context.Books.Update(existingBook).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var book = _context.Books.FirstOrDefault(x => x.Id == id);

        if (book == null) return;

        _context.Books.Remove(book);
        _context.SaveChanges();
    }
}