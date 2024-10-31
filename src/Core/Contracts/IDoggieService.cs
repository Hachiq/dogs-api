using Core.Entities;
using Core.Requests;

namespace Core.Contracts;

public interface IDoggieService
{
    /// <summary>
    /// Retrieves a paginated and sorted collection of dogs based on the specified criteria.
    /// </summary>
    /// <param name="attribute">The attribute to sort by. Supported values are "name", "color", "tail_length", and "weight".</param>
    /// <param name="order">The order of sorting. Use "desc" for descending or any other value for ascending.</param>
    /// <param name="pageNumber">The page number for pagination. Represents the current page of data.</param>
    /// <param name="pageSize">The number of records to retrieve per page.</param>
    /// <returns>A task that represents the asynchronous operation, containing a paginated and sorted collection of <see cref="Dog"/> entities.</returns>
    /// <remarks>
    /// This method applies sorting based on the specified attribute and order, then applies pagination based on the page number and page size.
    /// </remarks>
    Task<IEnumerable<Dog>> GetDoggies(string attribute, string order, int pageNumber, int pageSize);
    /// <summary>
    /// Adds a new dog to the repository based on the specified <see cref="AddDogRequest"/>.
    /// </summary>
    /// <param name="request">The request containing the details of the dog to be added.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>This method validates the incoming request and adds a new dog record to the data store.</remarks>
    Task AddDoggie(AddDogRequest dog);
}
