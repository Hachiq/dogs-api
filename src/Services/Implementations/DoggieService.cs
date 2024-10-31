using Core.Contracts;
using Core.Entities;
using Core.Exceptions;
using Core.Requests;
using Microsoft.EntityFrameworkCore;
using Services.Constants;
using Services.Validators;

namespace Services.Implementations;

/// <summary>
/// Provides services for managing and retrieving dog data, including adding a new dog and retrieving dogs with sorting and pagination.
/// Implements the <see cref="IDoggieService"/> interface.
/// </summary>
public class DoggieService(IRepository _db) : IDoggieService
{
    public async Task AddDoggie(AddDogRequest request)
    {
        DogValidator.ValidateAddDogRequest(request);

        if (await _db.FindAsync<Dog>(d => d.Name == request.Name) is not null)
        {
            throw new NameTakenException();
        }

        var doggie = new Dog
        {
            Name = request.Name,
            Color = request.Color,
            Tail_length = request.Tail_Length,
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
            Sorting.TailLength => order == Sorting.Descending ? dogs.OrderByDescending(d => d.Tail_length) : dogs.OrderBy(d => d.Tail_length),
            Sorting.Weight => order == Sorting.Descending ? dogs.OrderByDescending(d => d.Weight) : dogs.OrderBy(d => d.Weight),
            _ => dogs.OrderBy(d => d.Name)
        };

        var totalDogs = dogs.Count();
        dogs = dogs.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return await dogs.ToListAsync();
    }
}
