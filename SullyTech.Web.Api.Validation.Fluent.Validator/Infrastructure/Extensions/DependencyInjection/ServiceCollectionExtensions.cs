using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Web.Api.Contracts.Interfaces.RequestModels;

namespace SullyTech.Web.Api.Validation.Fluent.Validator.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddApiRequestModelValidator<TApiRequestModel, TAbstractValidator>(this IServiceCollection @this)
        where TApiRequestModel : IApiRequestModel
        where TAbstractValidator : AbstractValidator<TApiRequestModel>
    {
        @this.AddScoped<IValidator<TApiRequestModel>, TAbstractValidator>();
    }
}