using SullyTech.Web.Api.Contracts.Interfaces.ResponseModels;

namespace SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Contracts.ResponseModels.ApiModelStateValidationError;

public sealed class ApiModelStateValidationErrorResponseModel : IApiResponseModel
{
    public required string TraceId { get; init; }

    public static int ErrorType => (int)Enums.ErrorType.ApiModelStateValidationError;

    public required string ErrorMessage { get; init; }
}