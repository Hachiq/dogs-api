namespace Core.Exceptions;

public class ColorTooLongException : Exception
{
    public ColorTooLongException() : base("The color cannot be longer than 50 symbols") { }
}
