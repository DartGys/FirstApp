using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TaskBoard.DAL.Interfaces.Repository;

namespace TaskBoard.DAL.Data.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    protected readonly ApplicationDbContext _context;
    
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<T?> GetById(Guid id, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _context.Set<T>().FindAsync(id, cancellationToken);
    }
    
    public async Task<T?> GetById(Guid id, CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsyncNoTracking(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsyncNoTracking(CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>().AsNoTracking();
        foreach(var include in includes)
            query = query.Include(include);

        return await query.ToListAsync(cancellationToken);    
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _context.Set<T>().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>().Where(predicate);
        foreach (var include in includes)
            query = query.Include(include);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> FindAsyncNoTracking(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> FindAsyncNoTracking(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _context.Set<T>().AsNoTracking().Where(predicate);
        foreach(var include in includes)
            query = query.Include(include);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken))
    {
        await _context.Set<T>().AddRangeAsync(entities, cancellationToken);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
}

public interface IEntity
{
    Guid Id { get; set; }
}