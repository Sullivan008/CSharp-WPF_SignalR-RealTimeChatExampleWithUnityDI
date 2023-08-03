namespace SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Enums;

public enum ErrorType
{
    ApiError = 2,
    ApiValidationError = 4,
    ApiRequestModelValidationError = 8,
    ApiModelStateValidationError = 16,
    ApiInternalServerError = 32
}