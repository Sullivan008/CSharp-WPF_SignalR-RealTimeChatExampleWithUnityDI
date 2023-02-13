using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace SullyTech.Web.Api.Validation.Fluent.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddApiFluentModelStateValidation(this IServiceCollection @this)
    {
        @this.AddFluentValidationAutoValidation(configuration =>
        {
            configuration.DisableDataAnnotationsValidation = true;
        });

        @this.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
    }
}