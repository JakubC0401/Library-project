using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Context;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BookModel> Books { get; set; }
    public DbSet<UserModel> Users { get; set; }
}