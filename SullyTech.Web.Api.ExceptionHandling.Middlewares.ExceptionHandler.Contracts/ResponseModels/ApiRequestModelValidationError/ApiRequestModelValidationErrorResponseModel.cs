using SullyTech.Web.Api.Contracts.Interfaces.ResponseModels;

namespace SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiRequestModelValidationError;

public sealed class ApiRequestModelValidationErrorResponseModel : IApiResponseModel
{
    public required string TraceId { get; init; }

    public static int ErrorType => (int)Enums.ErrorType.ApiRequestModelValidationError;

    public required int ErrorCode { get; init; }

    public required string ErrorMessage { get; init; }
}