using System.Runtime.CompilerServices;
using SullyTech.Guard.Exceptions;

namespace SullyTech.Guard;

public static class Guard
{
    public static void ThrowIfNull<T>(T input, [CallerArgumentExpression(nameof(input))] string? parameterName = default, string? message = null)
    {
        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.String:
                {
                    ThrowIfNullOrWhitespace(input as string, parameterName, message);
                    break;
                }
            default:
                {
                    if (input is null)
                    {
                        throw new ArgumentNullException(parameterName, message ?? "The value cannot be null!");
                    }

                    break;
                }
        }
    }

    public static void ThrowIfNotNull<T>(T input, [CallerArgumentExpression(nameof(input))] string? parameterName = default, string? message = null)
    {
        switch (Type.GetTypeCode(typeof(T)))
        {
            case TypeCode.String:
                {
                    ThrowIfNotNullOrNotWhitespace(input as string, parameterName, message);
                    break;
                }
            default:
                {
                    if (input is not null)
                    {
                        throw new ArgumentNotNullException(parameterName, message ?? "The value is not null!");
                    }

                    break;
                }
        }
    }

    public static void ThrowIfNullOrWhitespace(string? input, [CallerArgumentExpression(nameof(input))] string? parameterName = default, string? message = null)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(parameterName, message ?? "The value cannot be null!");
        }
    }

    public static void ThrowIfNotNullOrNotWhitespace(string? input, [CallerArgumentExpression(nameof(input))] string? parameterName = default, string? message = null)
    {
        if (!string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNotNullException(parameterName, message ?? "The value is not null!");
        }
    }
}