using Microsoft.AspNetCore.Builder;

namespace SullyTech.Web.Api.ErrorHandling.Middlewares.Infrastructure.Extensions.ApplicationBuilder;

public static class ApplicationBuilderExtensions
{
    public static void UseErrorHandlingMiddleware(this IApplicationBuilder @this)
    {
        @this.UseMiddleware<ErrorHandlingMiddleware>();
    }
}