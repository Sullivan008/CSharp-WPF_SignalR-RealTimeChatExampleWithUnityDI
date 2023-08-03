using SullyTech.Web.Api.Contracts.Interfaces.ResponseModels;

namespace SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiError;

public sealed class ApiErrorResponseModel : IApiResponseModel
{
    public required string TraceId { get; init; }

    public static int ErrorType => (int)Enums.ErrorType.ApiError;

    public required int ErrorCode { get; init; }

    public required string ErrorMessage { get; init; }

    public required string Exception { get; init; }
}