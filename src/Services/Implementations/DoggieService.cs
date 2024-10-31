using Core.Contracts;
using Core.Entities;
using Core.Requests;
using Microsoft.EntityFrameworkCore;
using Services.Constants;

namespace Services.Implementations;

/// <summary>
/// Provides services for managing and retrieving dog data, including adding a new dog and retrieving dogs with sorting and pagination.
/// Implements the <see cref="IDoggieService"/> interface.
/// </summary>
public class DoggieService(IRepository _db) : IDoggieService
{
    public async Task AddDoggie(AddDogRequest request)
    {
        // TODO: Validate request

        var doggie = new Dog
        {
            Name = request.Name,
            Color = request.Color,
            TailLength = request.TailLength,
            Weight = request.Weight
        };

        await _db.AddAsync(doggie);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Dog>> GetDoggies(string attribute, string order, int pageNumber, int pageSize)
    {
        var dogs = _db.GetAllAsQueryable<Dog>();

        dogs = attribute.ToLower() switch
        {
            Sorting.Name => order == Sorting.Descending ? dogs.OrderByDescending(d => d.Name) : dogs.OrderBy(d => d.Name),
            Sorting.Color => order == Sorting.Descending ? dogs.OrderByDescending(d => d.Color) : dogs.OrderBy(d => d.Color),
            Sorting.TailLength => order == Sorting.Descending ? dogs.OrderByDescending(d => d.TailLength) : dogs.OrderBy(d => d.TailLength),
            Sorting.Weight => order == Sorting.Descending ? dogs.OrderByDescending(d => d.Weight) : dogs.OrderBy(d => d.Weight),
            _ => dogs.OrderBy(d => d.Name)
        };

        var totalDogs = dogs.Count();
        dogs = dogs.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return await dogs.ToListAsync();
    }
}
