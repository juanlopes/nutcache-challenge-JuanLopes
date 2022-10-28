using System.Net.Http.Json;
using NutcacheTest.Entities.Entity;
using NutcacheTest.Repository.Interfaces;

namespace NutcacheTest.Services;

public class UsersService : IUsersService
{
    private readonly IUserRepository _userRepository;
    public UsersService(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public List<User> GetAllUsers() => _userRepository.Get().ToList();

    public async Task<User> AddUser(User user) => await _userRepository.Add(user);

    public async Task<User> EditUser(User user) => await _userRepository.Update(user);

    public async Task<bool> DeleteUser(int userId) => await _userRepository.Delete(userId) > 0;
}
