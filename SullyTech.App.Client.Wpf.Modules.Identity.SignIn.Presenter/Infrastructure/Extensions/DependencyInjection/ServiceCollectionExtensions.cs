using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Infrastructure.Extensions.DependencyInjection;
using SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.ViewModels.Validators.Infrastructure.Extensions.DependencyInjection;

namespace SullyTech.App.Client.Wpf.Modules.Identity.SignIn.Presenter.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSignInPresenter(this IServiceCollection @this)
    {
        @this.AddSignInViewModel();
        @this.AddSignInDataViewModel();

        @this.AddSignInDataViewModelValidator();
    }
}