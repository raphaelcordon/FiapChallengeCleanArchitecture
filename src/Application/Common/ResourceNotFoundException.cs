namespace Application.Common;

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException(string? message) : base(message)
    {
    }

    public ResourceNotFoundException(string message, Exception? innerException) : base(message, innerException)
    {
    }
}