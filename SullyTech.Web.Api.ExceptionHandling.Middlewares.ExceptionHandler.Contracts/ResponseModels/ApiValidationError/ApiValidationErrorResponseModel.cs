using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiValidationError;

public sealed class ApiValidationErrorResponseModel
{
    private readonly string? _traceId;
    public string TraceId
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_traceId, nameof(TraceId));

            return _traceId!;
        }

        init => _traceId = value;
    }

    private readonly string? _exceptionType;
    public string ExceptionType
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_exceptionType, nameof(ExceptionType));

            return _exceptionType!;
        }

        init => _exceptionType = value;
    }

    private readonly int? _errorCode;
    public int ErrorCode
    {
        get
        {
            Guard.Guard.ThrowIfNull(_errorCode, nameof(ErrorCode));

            return _errorCode!.Value;
        }

        init => _errorCode = value;
    }

    private readonly int? _exceptionCode;
    public int ExceptionCode
    {
        get
        {
            Guard.Guard.ThrowIfNull(_exceptionCode, nameof(ExceptionCode));

            return _exceptionCode!.Value;
        }

        init => _exceptionCode = value;
    }

    public string? ExceptionMessage { get; init; }

    private readonly string? _exception;
    public string Exception
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_exception, nameof(Exception));

            return _exception!;
        }

        init => _exception = value;
    }
}