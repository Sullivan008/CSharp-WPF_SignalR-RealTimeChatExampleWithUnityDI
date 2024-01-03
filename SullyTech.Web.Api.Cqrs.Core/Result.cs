using SullyTech.Web.Api.Cqrs.Core.Interfaces;
using SullyTech.Web.Api.ErrorHandling.Core.Models.Abstractions;

namespace SullyTech.Web.Api.Cqrs.Core;

public sealed class Result : IResult
{
    public object? Value { get; private set; }

    public Error? Errors { get; private set; }


    private bool? _isSuccessful;
    public bool IsSuccessful
    {
        get
        {
            if (_isSuccessful is null)
            {
                throw new NullReferenceException($"Before accessing '{nameof(IsSuccessful)}' call either '{nameof(Success)}' or '{nameof(Error)}' method!");
            }

            return _isSuccessful.Value;
        }
    }

    public bool HasValue
    {
        get
        {
            if (_isSuccessful is null)
            {
                throw new NullReferenceException($"Before accessing '{nameof(HasValue)}' call either '{nameof(Success)}' or '{nameof(Error)}' method!");
            }

            return Value is not null;
        }
    }

    public Result Success()
    {
        _isSuccessful = true;

        return this;
    }

    public Result Success<T>(T value)
        where T : notnull
    {
        Guard.Guard.ThrowIfNull(value);

        Value = value;
        _isSuccessful = true;

        return this;
    }

    public Result Error(Error errors)
    {
        Guard.Guard.ThrowIfNull(errors);

        Errors = errors;
        _isSuccessful = false;

        return this;
    }

    public T GetValue<T>()
        where T : notnull
    {
        if (_isSuccessful is null)
        {
            throw new NullReferenceException($"Before accessing '{nameof(GetValue)}' call '{nameof(Success)}' method!");
        }

        Guard.Guard.ThrowIfNull(Value);

        return (T)Value!;
    }

    public Error GetErrors()
    {
        if (_isSuccessful is null)
        {
            throw new NullReferenceException($"Before accessing '{nameof(GetErrors)}' call '{nameof(Error)}' method!");
        }

        Guard.Guard.ThrowIfNull(Errors);

        return Errors!;
    }
}