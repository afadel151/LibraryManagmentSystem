using System.Linq.Expressions;
using Common.Data;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repositories;


public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(params object[] keyValues);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<int> CountAsync();
    IQueryable<T> GetQueryable();
    IQueryable<T> GetQueryable(params Expression<Func<T, object>>[] includes);
     Task<T?> FindFirstAsync(Expression<Func<T, bool>> predicate);
}

public class BaseRepository<T>(LibraryDbContext context) : IBaseRepository<T> where T : class
{
    protected readonly LibraryDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public Task<int> CountAsync()
        => _dbSet.CountAsync();

    public virtual async Task<T?> GetByIdAsync(params object[] keyValues)
    {
        ArgumentNullException.ThrowIfNull(keyValues);
        return await _dbSet.FindAsync(keyValues);
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await _dbSet.Where(predicate).ToListAsync();
    }
    public virtual async Task<T?> FindFirstAsync(Expression<Func<T, bool>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await _dbSet.Where(predicate).FirstOrDefaultAsync();
    }
    public virtual async Task<T> AddAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual IQueryable<T> GetQueryable()
    {
        return _dbSet.AsQueryable();
    }

    public virtual IQueryable<T> GetQueryable(params Expression<Func<T, object>>[] includes)
    {
        ArgumentNullException.ThrowIfNull(includes);
        IQueryable<T> query = _dbSet.AsQueryable();
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return query;
    }
}
