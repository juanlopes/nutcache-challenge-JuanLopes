using NutcacheTest.Entities.Entity;

namespace NutcacheTest.Services;

public interface IUsersService {
    public List<User> GetAllUsers();
    public Task<User> AddUser(User user);
    public Task<User> EditUser(User user);
    public Task<bool> DeleteUser(int userId);
}