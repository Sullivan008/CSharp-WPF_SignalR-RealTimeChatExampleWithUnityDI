﻿namespace SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiValidation.Models;

public class ErrorDetails
{
    public required int Code { get; init; }

    public required string Message { get; init; }
}