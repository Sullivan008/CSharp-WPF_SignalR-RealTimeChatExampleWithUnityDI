using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.Api;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiFluentModelStateValidation;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiInternalModelStateValidation;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiValidation;
using SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiError;
using SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiFluentModelStateValidation;
using SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiInternalModelStateValidationError;
using SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiInternalServerError;
using SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiValidationError;
using SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Enums;

namespace SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler;

public sealed class ApiExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    private readonly IWebHostEnvironment _webHostEnvironment;

    private readonly ILogger<ApiExceptionHandlerMiddleware> _logger;

    public ApiExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment webHostEnvironment, ILogger<ApiExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ApiException ex)
        {
            LogApiException(ex);

            ApiErrorResponseModel responseModel = CreateApiErrorResponseModel(httpContext, ex);

            await WriteApiErrorResponse(httpContext, responseModel);
        }
        catch (ApiValidationException ex)
        {
            LogApiValidationException(ex);

            ApiValidationErrorResponseModel responseModel = CreateApiValidationErrorResponseModel(httpContext, ex);

            await WriteApiValidationErrorResponse(httpContext, responseModel);
        }
        catch (ApiFluentModelStateValidationException ex)
        {
            LogApiFluentModelStateValidationException(ex);

            ApiFluentModelStateValidationErrorResponseModel responseModel = CreateApiFluentModelStateValidationErrorResponseModel(httpContext, ex);

            await WriteApiFluentModelStateValidationErrorResponse(httpContext, responseModel);
        }
        catch (ApiInternalModelStateValidationAggregateException ex)
        {
            LogApiInternalModelStateValidationException(ex);

            ApiInternalModelStateValidationErrorResponseModel responseModel = CreateApiInternalModelStateValidationErrorResponseModel(httpContext, ex);

            await WriteApiInternalModelStateValidationErrorResponse(httpContext, responseModel);
        }
        catch (Exception ex)
        {
            LogApiInternalServerErrorException(ex);

            ApiInternalServerErrorResponseModel responseModel = CreateApiInternalServerErrorResponseModel(httpContext, ex);

            await WriteApiInternalServerErrorResponse(httpContext, responseModel);
        }

    }

    #region APIException Handle Methods

    private void LogApiException(ApiException ex)
    {
        _logger.LogError(ex,
            $"Exception Code: {(int)ExceptionCode.ApiException} | Error Code: {ex.ErrorDetails.Code} | Message: {ex.ErrorDetails.Message}");
    }

    private ApiErrorResponseModel CreateApiErrorResponseModel(HttpContext httpContext, ApiException ex)
    {
        const string NON_DEVELOPMENT_EXCEPTION = "The exception available only in development environment!";

        return new ApiErrorResponseModel
        {
            ErrorCode = ex.ErrorDetails.Code,
            ExceptionType = ex.GetType().Name,
            ExceptionMessage = ex.ErrorDetails.Message,
            ExceptionCode = (int)ExceptionCode.ApiException,
            Exception = _webHostEnvironment.IsDevelopment() ? ex.ToString() : NON_DEVELOPMENT_EXCEPTION,
            TraceId = httpContext.TraceIdentifier
        };
    }

    private async Task WriteApiErrorResponse(HttpContext httpContext, ApiErrorResponseModel responseModel)
    {
        string jsonText = JsonConvert.SerializeObject(responseModel);

        httpContext.Response.Clear();

        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(jsonText);
    }
    
    #endregion

    #region APIValidationException Handle Methods

    private void LogApiValidationException(ApiValidationException ex)
    {
        _logger.LogError(ex,
            $"Exception Code: {(int)ExceptionCode.ApiValidationException} | Error Code: {ex.ErrorDetails.Code} | Message: {ex.ErrorDetails.Message}");
    }

    private ApiValidationErrorResponseModel CreateApiValidationErrorResponseModel(HttpContext httpContext, ApiValidationException ex)
    {
        const string NON_DEVELOPMENT_EXCEPTION = "The exception available only in development environment!";

        return new ApiValidationErrorResponseModel
        {
            ErrorCode = ex.ErrorDetails.Code,
            ExceptionType = ex.GetType().Name,
            ExceptionMessage = ex.ErrorDetails.Message,
            ExceptionCode = (int)ExceptionCode.ApiValidationException,
            Exception = _webHostEnvironment.IsDevelopment() ? ex.ToString() : NON_DEVELOPMENT_EXCEPTION,
            TraceId = httpContext.TraceIdentifier
        };
    }

    private async Task WriteApiValidationErrorResponse(HttpContext httpContext, ApiValidationErrorResponseModel responseModel)
    {
        string jsonText = JsonConvert.SerializeObject(responseModel);

        httpContext.Response.Clear();

        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        httpContext.Response.ContentType = "application/json";


        await httpContext.Response.WriteAsync(jsonText);
    }

    #endregion

    #region APIFluentModelStateValidationException Handle Methods

    private void LogApiFluentModelStateValidationException(ApiFluentModelStateValidationException ex)
    {
        _logger.LogError(ex,
            $"Exception Code: {(int)ExceptionCode.ApiFluentModelStateValidationException} | Error Code: {ex.ErrorDetails.Code} | Message: {ex.ErrorDetails.Message}");
    }

    private ApiFluentModelStateValidationErrorResponseModel CreateApiFluentModelStateValidationErrorResponseModel(HttpContext httpContext, ApiFluentModelStateValidationException ex)
    {
        const string NON_DEVELOPMENT_EXCEPTION = "The exception available only in development environment!";

        return new ApiFluentModelStateValidationErrorResponseModel
        {
            ErrorCode = ex.ErrorDetails.Code,
            ExceptionType = ex.GetType().Name,
            ExceptionMessage = ex.ErrorDetails.Message,
            ExceptionCode = (int)ExceptionCode.ApiFluentModelStateValidationException,
            Exception = _webHostEnvironment.IsDevelopment() ? ex.ToString() : NON_DEVELOPMENT_EXCEPTION,
            TraceId = httpContext.TraceIdentifier
        };
    }

    private async Task WriteApiFluentModelStateValidationErrorResponse(HttpContext httpContext, ApiFluentModelStateValidationErrorResponseModel responseModel)
    {
        string jsonText = JsonConvert.SerializeObject(responseModel);

        httpContext.Response.Clear();

        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(jsonText);
    }

    #endregion

    #region APIInternalModelStateValidationException Handle Methods

    private void LogApiInternalModelStateValidationException(ApiInternalModelStateValidationAggregateException ex)
    {
        _logger.LogError(ex, 
            $"Exception Code: {(int)ExceptionCode.ApiInternalModelStateValidationAggregationException} | Message: {ex.Message}");
    }

    private ApiInternalModelStateValidationErrorResponseModel CreateApiInternalModelStateValidationErrorResponseModel(HttpContext httpContext, ApiInternalModelStateValidationAggregateException ex)
    {
        const string NON_DEVELOPMENT_EXCEPTION = "The exception available only in development environment!";

        return new ApiInternalModelStateValidationErrorResponseModel
        {
            ExceptionType = ex.GetType().Name,
            ExceptionCode = (int)ExceptionCode.ApiInternalModelStateValidationAggregationException,
            ExceptionMessage = ex.Message,
            Exception = _webHostEnvironment.IsDevelopment() ? ex.ToString() : NON_DEVELOPMENT_EXCEPTION,
            TraceId = httpContext.TraceIdentifier
        };
    }

    private async Task WriteApiInternalModelStateValidationErrorResponse(HttpContext httpContext, ApiInternalModelStateValidationErrorResponseModel responseModel)
    {
        string jsonText = JsonConvert.SerializeObject(responseModel);

        httpContext.Response.Clear();

        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(jsonText);
    }

    #endregion

    #region APIInternalServerErrorException Handle Methods

    private void LogApiInternalServerErrorException(Exception ex)
    {
        _logger.LogError(ex, 
            $"Exception Code: {(int)ExceptionCode.ApiInternalServerErrorException} | Message: {ex.Message}");
    }

    private ApiInternalServerErrorResponseModel CreateApiInternalServerErrorResponseModel(HttpContext httpContext, Exception ex)
    {
        const string NON_DEVELOPMENT_EXCEPTION = "The exception available only in development environment!";
        const string NON_DEVELOPMENT_EXCEPTION_TYPE = "The exception type available only in development environment!";
        const string NON_DEVELOPMENT_EXCEPTION_MESSAGE = "One or more error occurred! Please contact us for more information!";

        return new ApiInternalServerErrorResponseModel
        {
            ExceptionCode = (int)ExceptionCode.ApiInternalServerErrorException,
            Exception = _webHostEnvironment.IsDevelopment() ? ex.ToString() : NON_DEVELOPMENT_EXCEPTION,
            ExceptionMessage = _webHostEnvironment.IsDevelopment() ? ex.Message : NON_DEVELOPMENT_EXCEPTION_MESSAGE,
            ExceptionType = _webHostEnvironment.IsDevelopment() ? ex.GetType().Name : NON_DEVELOPMENT_EXCEPTION_TYPE,
            TraceId = httpContext.TraceIdentifier
        };
    }

    private async Task WriteApiInternalServerErrorResponse(HttpContext httpContext, ApiInternalServerErrorResponseModel responseModel)
    {
        string jsonText = JsonConvert.SerializeObject(responseModel);

        httpContext.Response.Clear();

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(jsonText);
    }

    #endregion
}