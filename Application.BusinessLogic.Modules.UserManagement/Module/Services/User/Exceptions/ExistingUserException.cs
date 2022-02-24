namespace Application.BusinessLogic.Modules.UserManagement.Module.Services.User.Exceptions;

public class ExistingUserException : Exception
{
    public ExistingUserException()
    { }

    public ExistingUserException(string message) : base(message)
    { }

    public ExistingUserException(string message, Exception innerException) : base(message, innerException)
    { }
}