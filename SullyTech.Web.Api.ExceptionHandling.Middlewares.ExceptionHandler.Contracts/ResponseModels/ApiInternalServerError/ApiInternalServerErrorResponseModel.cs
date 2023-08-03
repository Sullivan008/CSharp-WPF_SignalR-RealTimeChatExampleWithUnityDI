using SullyTech.Web.Api.Contracts.Interfaces.ResponseModels;

namespace SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiInternalServerError;

public sealed class ApiInternalServerErrorResponseModel : IApiResponseModel
{
    public required string TraceId { get; init; }

    public static int ErrorType => (int)Enums.ErrorType.ApiInternalServerError;

    public required string ExceptionType { get; init; }

    public required string ExceptionMessage { get; init; }

    public required string Exception { get; init; }
}