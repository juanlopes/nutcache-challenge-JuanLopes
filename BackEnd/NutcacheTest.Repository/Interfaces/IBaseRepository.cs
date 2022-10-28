using System.Linq.Expressions;

namespace NutcacheTest.Repository.Interfaces;

public interface IBaseRepository<T> where T : class
{
    public ICollection<T> Get();
    public Task<IQueryable<T>> Get(Expression<Func<T, bool>> predicate);
    public Task<T> Add(T entity);
    public Task<T> Update(T entity);
    public Task<int> Delete(int id);
}