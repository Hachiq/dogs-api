using Core.Contracts;
using Core.Entities;
using Core.Exceptions;
using Core.Requests;
using Moq;
using Services.Constants;
using Services.Implementations;
using System.Linq.Expressions;
using System.Reflection;
using Tests.Extensions;

namespace Tests.Services;

public class DoggieServiceTests
{
    private readonly Mock<IRepository> _mockRepository;
    private readonly DoggieService _service;

    public DoggieServiceTests()
    {
        _mockRepository = new Mock<IRepository>();
        _service = new DoggieService(_mockRepository.Object);
    }

    #region AddDoggie Tests

    [Fact]
    public async Task AddDoggie_ShouldThrowEmptyNameException_WhenNameIsEmpty()
    {
        var request = new AddDogRequest("", "Brown", 5, 10);
        CancellationToken cancellationToken = CancellationToken.None;

        await Assert.ThrowsAsync<EmptyNameException>(() => _service.AddDoggie(request, cancellationToken));
    }

    [Fact]
    public async Task AddDoggie_ShouldThrowNameTooLongException_WhenNameIsTooLong()
    {
        var request = new AddDogRequest(new string('A', 51), "Brown", 5, 10 );
        CancellationToken cancellationToken = CancellationToken.None;

        await Assert.ThrowsAsync<NameTooLongException>(() => _service.AddDoggie(request, cancellationToken));
    }

    [Fact]
    public async Task AddDoggie_ShouldThrowEmptyColorException_WhenColorIsEmpty()
    {
        var request = new AddDogRequest("Buddy", "", 5, 10);
        CancellationToken cancellationToken = CancellationToken.None;

        await Assert.ThrowsAsync<EmptyColorException>(() => _service.AddDoggie(request, cancellationToken));
    }

    [Fact]
    public async Task AddDoggie_ShouldThrowColorTooLongException_WhenColorIsTooLong()
    {
        var request = new AddDogRequest("Buddy", new string('A', 51), 5, 10);
        CancellationToken cancellationToken = CancellationToken.None;

        await Assert.ThrowsAsync<ColorTooLongException>(() => _service.AddDoggie(request, cancellationToken));
    }

    [Fact]
    public async Task AddDoggie_ShouldThrowInvalidTailLengthException_WhenTailLengthIsNegative()
    {
        var request = new AddDogRequest("Buddy", "Brown", -1, 10);
        CancellationToken cancellationToken = CancellationToken.None;

        await Assert.ThrowsAsync<InvalidTailLengthException>(() => _service.AddDoggie(request, cancellationToken));
    }

    [Fact]
    public async Task AddDoggie_ShouldThrowInvalidWeightException_WhenWeightIsNegative()
    {
        var request = new AddDogRequest("Buddy", "Brown", 5, -5);
        CancellationToken cancellationToken = CancellationToken.None;

        await Assert.ThrowsAsync<InvalidWeightException>(() => _service.AddDoggie(request, cancellationToken));
    }

    [Fact]
    public async Task AddDoggie_ShouldThrowNameTakenException_WhenNameAlreadyExists()
    {
        var request = new AddDogRequest("Buddy", "Brown", 5, 10);
        CancellationToken cancellationToken = CancellationToken.None;

        _mockRepository.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<Dog, bool>>>(), cancellationToken))
            .ReturnsAsync(new Dog
            {
                Name = request.Name,
                Color = request.Color,
                Tail_length = request.Tail_Length,
                Weight = request.Weight
            });

        await Assert.ThrowsAsync<NameTakenException>(() => _service.AddDoggie(request, cancellationToken));
    }

    [Fact]
    public async Task AddDoggie_ShouldAddDog_WhenRequestIsValid()
    {
        var request = new AddDogRequest ("Buddy", "Brown", 5, 10);
        CancellationToken cancellationToken = CancellationToken.None;

        _mockRepository.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<Dog, bool>>>(), cancellationToken))
            .ReturnsAsync((Dog)null);

        await _service.AddDoggie(request, cancellationToken);

        _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Dog>(), cancellationToken), Times.Once);
        _mockRepository.Verify(repo => repo.SaveChangesAsync(cancellationToken), Times.Once);
    }

    #endregion

    #region GetDoggies Tests

    [Theory]
    [InlineData(Sorting.Name, Sorting.Ascending)]
    [InlineData(Sorting.Name, Sorting.Descending)]
    [InlineData(Sorting.Color, Sorting.Ascending)]
    [InlineData(Sorting.Color, Sorting.Descending)]
    [InlineData(Sorting.TailLength, Sorting.Ascending)]
    [InlineData(Sorting.TailLength, Sorting.Descending)]
    [InlineData(Sorting.Weight, Sorting.Ascending)]
    [InlineData(Sorting.Weight, Sorting.Descending)]
    public async Task GetDoggies_ShouldReturnSortedResults(string attribute, string order)
    {
        var dogList = new List<Dog>
        {
            new Dog { Name = "Buddy", Color = "Brown", Tail_length = 5, Weight = 10 },
            new Dog { Name = "Max", Color = "Black", Tail_length = 7, Weight = 15 }
        }.AsAsyncQueryable();

        CancellationToken cancellationToken = CancellationToken.None;

        _mockRepository.Setup(repo => repo.GetAllAsQueryable<Dog>()).Returns(dogList);

        var result = await _service.GetDoggies(attribute, order, 1, 10, cancellationToken);

        //var sortedList = order == Sorting.Descending
        //    ? result.OrderByDescending(d => EF.Property<object>(d, attribute))
        //    : result.OrderBy(d => EF.Property<object>(d, attribute));

        PropertyInfo property = typeof(Dog).GetProperty(attribute, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) ?? throw new ArgumentException($"No property '{attribute}' found on type {typeof(Dog)}");

        // Assert the list is sorted based on the attribute and order
        var sortedList = order == Sorting.Descending
            ? result.OrderByDescending(d => property.GetValue(d))
            : result.OrderBy(d => property.GetValue(d));

        Assert.Equal(sortedList, result);
    }

    [Fact]
    public async Task GetDoggies_ShouldReturnPaginatedResults()
    {
        var dogList = new List<Dog>
        {
            new Dog { Name = "Buddy", Color = "Brown", Tail_length = 5, Weight = 10 },
            new Dog { Name = "Max", Color = "Black", Tail_length = 7, Weight = 15 },
            new Dog { Name = "Lucy", Color = "White", Tail_length = 6, Weight = 12 }
        }.AsAsyncQueryable();

        CancellationToken cancellationToken = CancellationToken.None;

        _mockRepository.Setup(repo => repo.GetAllAsQueryable<Dog>()).Returns(dogList);

        var result = await _service.GetDoggies(Sorting.Name, Sorting.Ascending, 1, 2, cancellationToken);

        Assert.Equal(2, result.Count());
        Assert.Contains(result, d => d.Name == "Buddy");
        Assert.Contains(result, d => d.Name == "Lucy");
    }

    #endregion
}
