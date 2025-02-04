using Library.Models;

namespace Library.Repository.Interfaces;

public interface IUserRepository
{
    UserModel? GetUser(int id);
    IEnumerable<UserModel?> GetAllUsers();
    void Add(UserModel? user);
    void Update(int id, UserModel user);
    void Delete(int id);
}