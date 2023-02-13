namespace SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Enums;

public enum ExceptionCode
{
    ApiException = 2,
    ApiValidationException = 4,
    ApiFluentModelStateValidationException = 8,
    ApiInternalModelStateValidationAggregationException = 16,
    ApiInternalServerErrorException = 32
}