using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using NutcacheTest.Entities.Entity;
using NutcacheTest.Entities.Enums;
using NutcacheTest.Repository.Interfaces;

namespace NutcacheTest.Repository;
public class UserRepository : IUserRepository
{
    private readonly IDataContext _data;

    public UserRepository(IDataContext data)
    {
        _data = data;
    }

    public async Task<User> Add(User entity)
    {
        try {
            var result = _data.Users.Add(entity);
            await _data.Commit();
            return result.Entity;
        } catch (Exception ex) {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> Delete(int userId)
    {
        try {
            var user = _data.Users.Where(e => e.Id == userId).First();
            _data.Users.Remove(user);
            return await _data.Commit();
        } catch (Exception ex){
            throw new Exception(ex.Message);
        }
    }

    public async Task<User> Update(User entity)
    {
        try {
            var result = _data.Users.Update(entity);
            await _data.Commit();
            return result.Entity;
        } catch (Exception ex){
            throw new Exception(ex.Message);
        }
    }

    public ICollection<User> Get()
    {
        try
        {
            return _data.Users.ToList();
        } catch (Exception ex) {
            throw new Exception(ex.Message);
        }
    }

    public Task<IQueryable<User>> Get(Expression<Func<User, bool>> predicate)
    {
        try
        {
            return (Task<IQueryable<User>>)_data.Users.Where(predicate);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
