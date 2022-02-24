namespace Application.BusinessLogic.Modules.UserManagement.Module.Commands.SignIn.Exceptions;

public class IsCachedConnectionIdException : Exception
{
    public IsCachedConnectionIdException()
    { }

    public IsCachedConnectionIdException(string message) : base(message)
    { }

    public IsCachedConnectionIdException(string message, Exception innerException) : base(message, innerException)
    { }
}