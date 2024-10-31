using Core.Exceptions;
using Core.Requests;

namespace Services.Validators;

public static class DogValidator
{
    public static void ValidateAddDogRequest(AddDogRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new EmptyNameException();
        if (request.Name.Length > 50)
            throw new NameTooLongException();
        if (string.IsNullOrWhiteSpace(request.Color))
            throw new EmptyColorException();
        if (request.Color.Length > 50)
            throw new ColorTooLongException();
        if (request.Tail_Length < 0)
            throw new InvalidTailLengthException();
        if (request.Weight < 0)
            throw new InvalidWeightException();
    }
}
