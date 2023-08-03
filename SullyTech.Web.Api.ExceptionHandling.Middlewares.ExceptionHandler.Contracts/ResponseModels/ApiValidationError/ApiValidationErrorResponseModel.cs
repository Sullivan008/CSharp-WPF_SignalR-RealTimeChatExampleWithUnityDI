using SullyTech.Web.Api.Contracts.Interfaces.ResponseModels;

namespace SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiValidationError;

public sealed class ApiValidationErrorResponseModel : IApiResponseModel
{
    public required string TraceId { get; init; }

    public static int ErrorType => (int)Enums.ErrorType.ApiValidationError;

    public required int ErrorCode { get; init; }

    public required string ErrorMessage { get; init; }
}