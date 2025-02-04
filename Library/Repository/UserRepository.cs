using Library.Models;
using Library.Repository.Context;
using Library.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository;

public class UserRepository : IUserRepository
{
    private readonly LibraryContext _context;

    public UserRepository(LibraryContext context)
    {
        _context = context;
    }

    public UserModel? GetUser(int id)
    {
        return _context.Users.FirstOrDefault(x => x.UserModelId == id);
    }

    public IEnumerable<UserModel?> GetAllUsers()
    {
        return _context.Users.ToList();
    }
    
    public void Add(UserModel? user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, UserModel user)
    {
        var existingUser = _context.Users.FirstOrDefault(x => x.UserModelId == id);
        if (existingUser == null) return;

        existingUser.Email = user.Email;
        existingUser.Name = user.Name;
        _context.Users.Update(existingUser).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var toRemove = _context.Users.FirstOrDefault(x => x.UserModelId == id);
        _context.Users.Remove(toRemove);
        _context.SaveChanges();
    }
}