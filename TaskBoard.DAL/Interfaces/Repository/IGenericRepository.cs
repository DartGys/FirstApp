using System.Linq.Expressions;

namespace TaskBoard.DAL.Interfaces.Repository;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetById(Guid id, CancellationToken cancellationToken = default(CancellationToken));
    Task<T?> GetById(Guid id, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<T>> GetAllAsyncNoTracking(CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<T>> GetAllAsyncNoTracking(CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> FindAsyncNoTracking(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
    Task<IEnumerable<T>> FindAsyncNoTracking(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<T, object>>[] includes);

    Task AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}