using Core.Contracts;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services.Implementations;

/// <summary>
/// Represents a generic repository that provides access to the data layer.
/// This class implements the <see cref="IRepository"/> interface, providing methods for
/// CRUD operations on entities within the application.
/// This implementation uses the repository pattern, which may be considered overengineering
/// for simple applications.
/// </summary>
public class Repository(AppDbContext _context) : IRepository
{

    public async Task<IEnumerable<T>> GetAllAsync<T>(CancellationToken cancellationToken) where T : class
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken) where T : class
    {
        if (predicate is not null)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync(cancellationToken);
        }
        else
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }
    }

    public IQueryable<T> GetAllAsQueryable<T>() where T : class
    {
        return _context.Set<T>().AsQueryable();
    }

    public async Task<T?> FindAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken) where T : class
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : class
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
