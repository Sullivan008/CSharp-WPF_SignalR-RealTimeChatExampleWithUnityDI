using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace SullyTech.Web.Api.Validation.Fluent.Validator.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddApiModelValidatorsFromAssembly(this IServiceCollection @this, Assembly assembly)
    {
        @this.AddValidatorsFromAssembly(assembly);
    }
}