using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace SullyTech.Web.Api.ExceptionHandling.Middlewares.ExceptionHandler.Infrastructure.Extensions.ApplicationBuilder;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseApiExceptionHandlerMiddleware(this IApplicationBuilder @this)
    {
        @this.UseWhen(httpContext => httpContext.Request.Path.HasValue && httpContext.Request.Path.StartsWithSegments(new PathString("/api")),
                      applicationBuilder =>
                      {
                          applicationBuilder.UseMiddleware<ApiExceptionHandlerMiddleware>();
                      });

        return @this;
    }
}