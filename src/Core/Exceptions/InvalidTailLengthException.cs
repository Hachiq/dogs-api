namespace Core.Exceptions;

public class InvalidTailLengthException : Exception
{
    public InvalidTailLengthException() : base("The tail length cannot be less than 0") { }
}
