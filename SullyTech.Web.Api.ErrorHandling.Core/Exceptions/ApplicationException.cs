using SullyTech.Web.Api.ErrorHandling.Core.Models;

namespace SullyTech.Web.Api.ErrorHandling.Core.Exceptions;

public sealed class ApplicationException : Exception
{
    public ApplicationError Error { get; }

    public ApplicationException(ApplicationError error)
    {
        Guard.Guard.ThrowIfNull(error);

        Error = error;
    }

    public ApplicationException(ApplicationError error, Exception innerException) : base(default, innerException)
    {
        Guard.Guard.ThrowIfNull(error);

        Error = error;
    }
}