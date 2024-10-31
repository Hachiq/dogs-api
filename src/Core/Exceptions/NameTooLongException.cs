namespace Core.Exceptions;

public class NameTooLongException : Exception
{
    public NameTooLongException(): base("The name cannot be longer than 50 symbols") { }
}
