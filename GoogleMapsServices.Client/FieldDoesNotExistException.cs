namespace GoogleMapsServices.Client;

public class FieldDoesNotExistException : Exception
{
    public FieldDoesNotExistException()
    {
    }

    public FieldDoesNotExistException(string message)
        : base(message)
    {
    }

    public FieldDoesNotExistException(string message, Exception inner)
        : base(message, inner)
    {
    }
}