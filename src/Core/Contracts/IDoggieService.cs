using Core.Entities;
using Core.Requests;

namespace Core.Contracts;

public interface IDoggieService
{
    Task<IEnumerable<Dog>> GetDoggies(string attribute, string order, int pageNumber, int pageSize);
    Task AddDoggie(AddDogRequest dog);
}
