using System.Linq.Expressions;

namespace Core.Contracts;

/// <summary>
/// Defines a generic repository interface for accessing data in the application.
/// This interface provides methods for CRUD operations on entities.
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Retrieves all entities of the specified type asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the entities to retrieve.</typeparam>
    /// <returns>A task that represents the asynchronous operation, containing a collection of entities.</returns>
    Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
    /// <summary>
    /// Retrieves all entities of the specified type that match the given predicate asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the entities to retrieve.</typeparam>
    /// <param name="predicate">An expression used to filter the entities.</param>
    /// <returns>A task that represents the asynchronous operation, containing a collection of filtered entities.</returns>
    Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
    /// <summary>
    /// Adds a new entity of the specified type to the database asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the entity to add.</typeparam>
    /// <param name="entity">The entity to add to the database.</param>
    Task AddAsync<T>(T entity) where T : class;
    /// <summary>
    /// Saves all changes made in the context to the database asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous save operation.</returns>
    Task SaveChangesAsync();
}
