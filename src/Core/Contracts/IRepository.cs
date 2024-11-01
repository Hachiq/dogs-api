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
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation, containing a collection of entities.</returns>
    Task<IEnumerable<T>> GetAllAsync<T>(CancellationToken cancellationToken) where T : class;
    /// <summary>
    /// Retrieves all entities of the specified type that match the given predicate asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the entities to retrieve.</typeparam>
    /// <param name="predicate">An expression used to filter the entities.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation, containing a collection of filtered entities.</returns>
    Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken) where T : class;
    /// <summary>
    /// Retrieves all entities of the specified type as an <see cref="IQueryable{T}"/>.
    /// This allows for deferred execution and further filtering or ordering to be applied in LINQ queries.
    /// </summary>
    /// <typeparam name="T">The type of the entities to retrieve.</typeparam>
    /// <returns>An <see cref="IQueryable{T}"/> that represents all entities of the specified type.</returns>
    IQueryable<T> GetAllAsQueryable<T>() where T : class;
    /// <summary>
    /// Asynchronously finds an entity of the specified type that matches the given predicate.
    /// </summary>
    /// <typeparam name="T">The type of the entity to retrieve.</typeparam>
    /// <param name="predicate">A lambda expression representing the condition to filter the entity.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation, containing the first entity 
    /// that matches the specified condition or <c>null</c> if no matching entity is found.
    /// </returns>
    /// <remarks>
    /// This method is useful for retrieving a single entity based on a specified condition, such as by ID or unique property.
    /// If no entity matches the predicate, the method returns <c>null</c>.
    /// </remarks>
    Task<T?> FindAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken) where T : class;
    /// <summary>
    /// Adds a new entity of the specified type to the database asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the entity to add.</typeparam>
    /// <param name="entity">The entity to add to the database.</param>
    Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
    /// <summary>
    /// Saves all changes made in the context to the database asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous save operation.</returns>
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
