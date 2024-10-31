namespace Core.Exceptions;

public class EmptyNameException : Exception
{
    public EmptyNameException() : base("The name cannot be empty") { }
}
