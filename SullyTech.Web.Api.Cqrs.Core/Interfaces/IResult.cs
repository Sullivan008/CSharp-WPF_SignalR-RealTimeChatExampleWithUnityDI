using SullyTech.Web.Api.ErrorHandling.Core.Models.Abstractions;

namespace SullyTech.Web.Api.Cqrs.Core.Interfaces;

public interface IResult
{
    public object? Value { get; }

    public Error? Errors { get; }

    public bool IsSuccessful { get; }

    public bool HasValue { get; }

    public Result Success();

    public Result Success<T>(T value)
        where T : notnull;

    public Result Error(Error errors);

    public T GetValue<T>()
        where T : notnull;

    public Error GetErrors();
}