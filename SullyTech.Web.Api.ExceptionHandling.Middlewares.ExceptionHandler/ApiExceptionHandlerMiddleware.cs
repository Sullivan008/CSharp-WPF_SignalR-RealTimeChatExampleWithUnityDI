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
        catch (ApiModelStateValidationAggregateException ex)
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
            $"Exception Code: {(int)ExceptionCode.ApiException} | Error Code: {ex.ErrorDetails.Code} | Message: {ex.ErrorDetails.Message}");
    }

    private static ApiErrorResponseModel CreateApiErrorResponseModel(HttpContext httpContext, ApiException ex)
    {
        return new ApiErrorResponseModel
        {
            TraceId = httpContext.TraceIdentifier,
            ErrorCode = ex.ErrorDetails.Code,
            ErrorMessage = ex.ErrorDetails.Message,
            ExceptionType = ex.GetType().Name,
            ExceptionCode = (int)ExceptionCode.ApiException,
            Exception = ex.ToString()
        };
    }

    private async Task WriteApiErrorResponse(HttpContext httpContext, ApiErrorResponseModel responseModel)
    {
        JsonSerializerSettings jsonSerializerSettings = new()
        {
            ContractResolver = new IgnorePropertiesResolver(!_webHostEnvironment.IsDevelopment()
                ? new[] { nameof(responseModel.ExceptionType), nameof(responseModel.ExceptionCode) }
                : Array.Empty<string>())
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
            $"Exception Code: {(int)ExceptionCode.ApiValidationException} | Error Code: {ex.ErrorDetails.Code} | Message: {ex.ErrorDetails.Message}");
    }

    private static ApiValidationErrorResponseModel CreateApiValidationErrorResponseModel(HttpContext httpContext, ApiValidationException ex)
    {
        return new ApiValidationErrorResponseModel
        {
            TraceId = httpContext.TraceIdentifier,
            ErrorCode = ex.ErrorDetails.Code,
            ErrorMessage = ex.ErrorDetails.Message,
            ExceptionType = ex.GetType().Name,
            ExceptionCode = (int)ExceptionCode.ApiValidationException,
            Exception = ex.ToString()
        };
    }

    private async Task WriteApiValidationErrorResponse(HttpContext httpContext, ApiValidationErrorResponseModel responseModel)
    {
        JsonSerializerSettings jsonSerializerSettings = new()
        {
            ContractResolver = new IgnorePropertiesResolver(!_webHostEnvironment.IsDevelopment()
                ? new[] { nameof(responseModel.ExceptionType), nameof(responseModel.ExceptionCode) }
                : Array.Empty<string>())
        };

        string jsonText = JsonConvert.SerializeObject(responseModel, jsonSerializerSettings);

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
            $"Exception Code: {(int)ExceptionCode.ApiRequestModelValidationException} | Error Code: {ex.ErrorDetails.Code} | Message: {ex.ErrorDetails.Message}");
    }

    private static ApiRequestModelValidationErrorResponseModel CreateApiRequestModelValidationErrorResponseModel(HttpContext httpContext, ApiRequestModelValidationException ex)
    {
        return new ApiRequestModelValidationErrorResponseModel
        {
            TraceId = httpContext.TraceIdentifier,
            ErrorCode = ex.ErrorDetails.Code,
            ErrorMessage = ex.ErrorDetails.Message,
            ExceptionType = ex.GetType().Name,
            ExceptionCode = (int)ExceptionCode.ApiRequestModelValidationException,
            Exception = ex.ToString()
        };
    }

    private async Task WriteApiRequestModelValidationErrorResponse(HttpContext httpContext, ApiRequestModelValidationErrorResponseModel responseModel)
    {
        JsonSerializerSettings jsonSerializerSettings = new()
        {
            ContractResolver = new IgnorePropertiesResolver(!_webHostEnvironment.IsDevelopment()
                ? new[] { nameof(responseModel.ExceptionType), nameof(responseModel.ExceptionCode) }
                : Array.Empty<string>())
        };

        string jsonText = JsonConvert.SerializeObject(responseModel, jsonSerializerSettings);

        httpContext.Response.Clear();

        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(jsonText);
    }

    #endregion

    #region ApiModelStateValidationException Handle Methods

    private void LogApiModelStateValidationException(ApiModelStateValidationAggregateException ex)
    {
        _logger.LogError(ex,
            $"Exception Code: {(int)ExceptionCode.ApiModelStateValidationAggregationException} | Message: {ex.Message}");
    }

    private ApiModelStateValidationErrorResponseModel CreateApiModelStateValidationErrorResponseModel(HttpContext httpContext, ApiModelStateValidationAggregateException ex)
    {
        return new ApiModelStateValidationErrorResponseModel
        {
            TraceId = httpContext.TraceIdentifier,
            ExceptionType = ex.GetType().Name,
            ExceptionCode = (int)ExceptionCode.ApiModelStateValidationAggregationException,
            ExceptionMessage = ex.Message,
            Exception = ex.ToString()
        };
    }

    private async Task WriteApiModelStateValidationErrorResponse(HttpContext httpContext, ApiModelStateValidationErrorResponseModel responseModel)
    {
        JsonSerializerSettings jsonSerializerSettings = new()
        {
            ContractResolver = new IgnorePropertiesResolver(!_webHostEnvironment.IsDevelopment()
                ? new[] { nameof(responseModel.ExceptionType), nameof(responseModel.ExceptionCode) }
                : Array.Empty<string>())
        };

        string jsonText = JsonConvert.SerializeObject(responseModel, jsonSerializerSettings);

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
            $"Exception Code: {(int)ExceptionCode.ApiInternalServerErrorException} | Message: {ex.Message}");
    }

    private static ApiInternalServerErrorResponseModel CreateApiInternalServerErrorResponseModel(HttpContext httpContext, Exception ex)
    {
        return new ApiInternalServerErrorResponseModel
        {
            TraceId = httpContext.TraceIdentifier,
            ExceptionCode = (int)ExceptionCode.ApiInternalServerErrorException,
            ExceptionType = ex.GetType().Name,
            ExceptionMessage = ex.Message,
            Exception = ex.ToString()
        };
    }

    private async Task WriteApiInternalServerErrorResponse(HttpContext httpContext, ApiInternalServerErrorResponseModel responseModel)
    {
        JsonSerializerSettings jsonSerializerSettings = new()
        {
            ContractResolver = new IgnorePropertiesResolver(!_webHostEnvironment.IsDevelopment()
                ? new[] { nameof(responseModel.ExceptionType), nameof(responseModel.ExceptionMessage), nameof(responseModel.Exception) }
                : Array.Empty<string>())
        };

        string jsonText = JsonConvert.SerializeObject(responseModel, jsonSerializerSettings);

        httpContext.Response.Clear();

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsync(jsonText);
    }

    #endregion
}