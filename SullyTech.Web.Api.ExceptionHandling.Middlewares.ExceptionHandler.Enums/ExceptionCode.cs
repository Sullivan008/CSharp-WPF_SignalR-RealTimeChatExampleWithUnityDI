namespace SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Enums;

public enum ExceptionCode
{
    ApiException = 2,
    ApiValidationException = 4,
    ApiRequestModelValidationException = 8,
    ApiModelStateValidationAggregationException = 16,
    ApiInternalServerErrorException = 32
}