using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Client.Wpf.Modules.Identity.Presenter.SignIn.Infrastructure.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace App.Client.Wpf.Modules.Identity.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddIdentityModulePresenters(this IServiceCollection @this)
    {
        @this.AddSignInPresenter();
    }
}