namespace Core.Exceptions;

public class NameTakenException : Exception
{
    public NameTakenException() : base("This doggie's name was already taken") { }
}
