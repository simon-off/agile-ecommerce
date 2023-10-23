using System.Linq.Expressions;

namespace WebAPI.Interface.Repositories;

public interface IRepo<T> where T : class
{
    Task<T> CreateAsync(T entity);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<T?> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
}
