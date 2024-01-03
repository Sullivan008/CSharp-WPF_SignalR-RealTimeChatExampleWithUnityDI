using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ApplicationException = SullyTech.Web.Api.ErrorHandling.Core.Exceptions.ApplicationException;

namespace SullyTech.Web.Api.ErrorHandling.Middlewares;

public sealed class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;


    private readonly ILogger _logger;

    private readonly IWebHostEnvironment _webHostEnvironment;


    private readonly ProblemDetailsFactory _problemDetailsFactory;

    public ErrorHandlingMiddleware(RequestDelegate next, IWebHostEnvironment webHostEnvironment, ILogger<ErrorHandlingMiddleware> logger,
        ProblemDetailsFactory problemDetailsFactory)
    {
        _next = next;

        _logger = logger;
        _webHostEnvironment = webHostEnvironment;

        _problemDetailsFactory = problemDetailsFactory;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ApplicationException ex)
        {
            _logger.LogError(ex, ex.Message);

            await RespondApplicationException(httpContext, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            await RespondUnhandledException(httpContext, ex);
        }
    }

    private async Task RespondApplicationException(HttpContext httpContext, ApplicationException ex)
    {
        ProblemDetails problemDetails = _problemDetailsFactory.CreateProblemDetails(httpContext: httpContext,
                                                                                    statusCode: (int)HttpStatusCode.InternalServerError,
                                                                                    title: ex.Error.Title,
                                                                                    detail: ex.Error.Detail);

        if (_webHostEnvironment.IsDevelopment())
        {
            problemDetails.Extensions.Add("exception", ex.ToString());
            problemDetails.Extensions.Add("headers", httpContext.Request.Headers);
            problemDetails.Extensions.Add("path", httpContext.Request.Path);
            problemDetails.Extensions.Add("endpoint", httpContext.GetEndpoint()?.DisplayName);
            problemDetails.Extensions.Add("routeValues", httpContext.Request.RouteValues);
        }

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/problem+json; charset=utf-8";

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }

    private async Task RespondUnhandledException(HttpContext httpContext, Exception ex)
    {
        ProblemDetails problemDetails = _problemDetailsFactory.CreateProblemDetails(httpContext: httpContext,
                                                                                    statusCode: (int)HttpStatusCode.InternalServerError,
                                                                                    title: "An unexpected error occurred!",
                                                                                    detail: "An unexpected error occurred while performing this operation!");

        if (_webHostEnvironment.IsDevelopment())
        {
            problemDetails.Extensions.Add("exception", ex.ToString());
            problemDetails.Extensions.Add("headers", httpContext.Request.Headers);
            problemDetails.Extensions.Add("path", httpContext.Request.Path);
            problemDetails.Extensions.Add("endpoint", httpContext.GetEndpoint()?.DisplayName);
            problemDetails.Extensions.Add("routeValues", httpContext.Request.RouteValues);
        }

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/problem+json; charset=utf-8";

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }
}