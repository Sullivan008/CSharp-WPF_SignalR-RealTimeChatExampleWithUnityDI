using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using SullyTech.Web.Api.ErrorHandling.Filters.ActionFilters;

namespace App.Web.Api.Controllers.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddApiControllers(this IServiceCollection @this)
    {
        @this.AddControllers(options =>
        {
            options.Filters.Add(typeof(ModelStateErrorHandlingFilter));
        })
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
        });


        @this.AddFluentValidationAutoValidation(configuration =>
        {
            configuration.DisableDataAnnotationsValidation = true;
        });

        @this.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);


        @this.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });


        @this.AddEndpointsApiExplorer();
        @this.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(schemaIdSelector => schemaIdSelector.ToString());
        });
    }
}