﻿namespace SullyTech.Api.ExceptionHandling.Exceptions.Api.Models;

public class ErrorDetails
{
    private readonly int? _code;
    public int Code
    {
        get => _code ?? 0;
        init => _code = value;
    }

    public string? Message { get; init; }
}