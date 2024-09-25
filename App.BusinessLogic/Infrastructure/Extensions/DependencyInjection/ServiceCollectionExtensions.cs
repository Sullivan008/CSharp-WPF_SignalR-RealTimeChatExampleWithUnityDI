using App.BusinessLogic.Modules.Identity.Infrastructure.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace App.BusinessLogic.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddBusinessLogic(this IServiceCollection @this)
    {
        @this.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(SullyTech.Web.Api.Cqrs.Query.PipelineBehaviors.ValidationBehavior<,>));
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(SullyTech.Web.Api.Cqrs.Command.PipelineBehaviors.ValidationBehavior<,>));
        });

        @this.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);

        @this.AddIdentityModule();
    }
}