﻿using SullyTech.Web.Api.Contracts.Interfaces.ResponseModels;

namespace SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiRequestModelValidationError;

public sealed class ApiRequestModelValidationErrorResponseModel : IApiResponseModel
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

    public string? ErrorMessage { get; init; }

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