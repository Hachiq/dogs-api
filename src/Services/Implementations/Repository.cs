using Core.Contracts;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services.Implementations;

/// <summary>
/// Represents a generic repository that provides access to the data layer.
/// This class implements the <see cref="IRepository"/> interface, providing methods for
/// CRUD operations on entities within the application.
/// </summary>
public class Repository(AppDbContext _context) : IRepository
{

    public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        if (predicate is not null)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        else
        {
            return await _context.Set<T>().ToListAsync();
        }
    }

    public IQueryable<T> GetAllAsQueryable<T>() where T : class
    {
        return _context.Set<T>().AsQueryable();
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
