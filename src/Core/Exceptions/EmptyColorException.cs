namespace Core.Exceptions;

public class EmptyColorException : Exception
{
    public EmptyColorException() : base("The color cannot be empty") { }
}
