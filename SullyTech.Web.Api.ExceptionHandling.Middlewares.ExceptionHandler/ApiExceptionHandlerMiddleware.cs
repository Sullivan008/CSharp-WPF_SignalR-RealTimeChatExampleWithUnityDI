using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SullyTech.Json.Resolvers;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.Api;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiModelStateValidation;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiRequestModelValidation;
using SullyTech.Web.Api.ExceptionHandling.Exceptions.ApiValidation;
using SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiError;
using SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiInternalServerError;
using SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiModelStateValidationError;
using SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiRequestModelValidationError;
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
        catch (ApiRequestModelValidationException ex)
        {
            LogApiRequestModelValidationException(ex);

            ApiRequestModelValidationErrorResponseModel responseModel = CreateApiRequestModelValidationErrorResponseModel(httpContext, ex);

            await WriteApiRequestModelValidationErrorResponse(httpContext, responseModel);
        }
        catch (ApiModelStateValidationException ex)
        {
            LogApiModelStateValidationException(ex);

            ApiModelStateValidationErrorResponseModel responseModel = CreateApiModelStateValidationErrorResponseModel(httpContext, ex);

            await WriteApiModelStateValidationErrorResponse(httpContext, responseModel);
        }
        catch (Exception ex)
        {
            LogApiInternalServerErrorException(ex);

            ApiInternalServerErrorResponseModel responseModel = CreateApiInternalServerErrorResponseModel(httpContext, ex);

            await WriteApiInternalServerErrorResponse(httpContext, responseModel);
        }
    }

    #region ApiException Handle Methods

    private void LogApiException(ApiException ex)
    {
        _logger.LogError(ex,
            $"Error Type: {(int)ErrorType.ApiError} | Error Code: {ex.ErrorDetails.Code} | Message: {ex.ErrorDetails.Message}");
    }

    private static ApiErrorResponseModel CreateApiErrorResponseModel(HttpContext httpContext, ApiException ex)
    {
        return new ApiErrorResponseModel
        {
            TraceId = httpContext.TraceIdentifier,
            ErrorCode = ex.ErrorDetails.Code,
            ErrorMessage = ex.ErrorDetails.Message,
            Exception = ex.ToString()
        };
    }

    private async Task WriteApiErrorResponse(HttpContext httpContext, ApiErrorResponseModel responseModel)
    {
        JsonSerializerSettings jsonSerializerSettings = new()
        {
            ContractResolver = new IgnorePropertiesResolver(!_webHostEnvironment.IsDevelopment() ?
                new[] { nameof(responseModel.Exception) } :
                Array.Empty<string>())
        };

        string jsonText = JsonConvert.SerializeObject(responseModel, jsonSerializerSettings);

        httpContext.Response.Clear();

        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(jsonText);
    }

    #endregion

    #region ApiValidationException Handle Methods

    private void LogApiValidationException(ApiValidationException ex)
    {
        _logger.LogError(ex,
            $"Error Type: {(int)ErrorType.ApiValidationError} | Error Code: {ex.ErrorDetails.Code} | Message: {ex.ErrorDetails.Message}");
    }

    private static ApiValidationErrorResponseModel CreateApiValidationErrorResponseModel(HttpContext httpContext, ApiValidationException ex)
    {
        return new ApiValidationErrorResponseModel
        {
            TraceId = httpContext.TraceIdentifier,
            ErrorCode = ex.ErrorDetails.Code,
            ErrorMessage = ex.ErrorDetails.Message
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

    #region ApiRequestModelValidationException Handle Methods

    private void LogApiRequestModelValidationException(ApiRequestModelValidationException ex)
    {
        _logger.LogError(ex,
            $"Error Type: {(int)ErrorType.ApiRequestModelValidationError} | Error Code: {ex.ErrorDetails.Code} | Message: {ex.ErrorDetails.Message}");
    }

    private static ApiRequestModelValidationErrorResponseModel CreateApiRequestModelValidationErrorResponseModel(HttpContext httpContext, ApiRequestModelValidationException ex)
    {
        return new ApiRequestModelValidationErrorResponseModel
        {
            TraceId = httpContext.TraceIdentifier,
            ErrorCode = ex.ErrorDetails.Code,
            ErrorMessage = ex.ErrorDetails.Message
        };
    }

    private async Task WriteApiRequestModelValidationErrorResponse(HttpContext httpContext, ApiRequestModelValidationErrorResponseModel responseModel)
    {
        string jsonText = JsonConvert.SerializeObject(responseModel);

        httpContext.Response.Clear();

        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(jsonText);
    }

    #endregion

    #region ApiModelStateValidationException Handle Methods

    private void LogApiModelStateValidationException(ApiModelStateValidationException ex)
    {
        _logger.LogError(ex,
            $"Error Type: {(int)ErrorType.ApiModelStateValidationError} | Message: {ex.Message}");
    }

    private ApiModelStateValidationErrorResponseModel CreateApiModelStateValidationErrorResponseModel(HttpContext httpContext, ApiModelStateValidationException ex)
    {
        return new ApiModelStateValidationErrorResponseModel
        {
            TraceId = httpContext.TraceIdentifier,
            ErrorMessage = ex.ErrorDetails.Message
        };
    }

    private static async Task WriteApiModelStateValidationErrorResponse(HttpContext httpContext, ApiModelStateValidationErrorResponseModel responseModel)
    {
        string jsonText = JsonConvert.SerializeObject(responseModel);

        httpContext.Response.Clear();

        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(jsonText);
    }

    #endregion

    #region ApiInternalServerErrorException Handle Methods

    private void LogApiInternalServerErrorException(Exception ex)
    {
        _logger.LogError(ex,
            $"Error Type: {(int)ErrorType.ApiInternalServerError} | Message: {ex.Message}");
    }

    private static ApiInternalServerErrorResponseModel CreateApiInternalServerErrorResponseModel(HttpContext httpContext, Exception ex)
    {
        return new ApiInternalServerErrorResponseModel
        {
            TraceId = httpContext.TraceIdentifier,
            Exception = ex.ToString(),
            ExceptionType = ex.GetType().FullName!,
            ExceptionMessage = ex.Message
        };
    }

    private async Task WriteApiInternalServerErrorResponse(HttpContext httpContext, ApiInternalServerErrorResponseModel responseModel)
    {
        JsonSerializerSettings jsonSerializerSettings = new()
        {
            ContractResolver = new IgnorePropertiesResolver(!_webHostEnvironment.IsDevelopment() ?
                new[] { nameof(responseModel.Exception), nameof(responseModel.ExceptionType), nameof(responseModel.ExceptionMessage) } :
                Array.Empty<string>())
        };

        string jsonText = JsonConvert.SerializeObject(responseModel, jsonSerializerSettings);

        httpContext.Response.Clear();

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(jsonText);
    }

    #endregion
}