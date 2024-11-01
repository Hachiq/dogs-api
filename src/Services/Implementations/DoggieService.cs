﻿using Core.Contracts;
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
    public async Task AddDoggie(AddDogRequest request, CancellationToken cancellationToken)
    {
        DogValidator.ValidateAddDogRequest(request);

        if (await _db.FindAsync<Dog>(d => d.Name == request.Name, cancellationToken) is not null)
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

        await _db.AddAsync(doggie, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Dog>> GetDoggies(string attribute, string order, int pageNumber, int pageSize, CancellationToken cancellationToken)
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

        pageNumber = pageNumber < 1 ? 1 : pageNumber;
        pageSize = pageSize < 1 ? Pagination.PageSize : pageSize;

        dogs = dogs.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        return await dogs.ToListAsync(cancellationToken);
    }
}
