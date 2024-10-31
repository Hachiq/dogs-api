namespace Core.Exceptions;

public class InvalidWeightException : Exception
{
    public InvalidWeightException() : base("The weight cannot be less than 0") { }
}
