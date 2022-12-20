﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Models.Interfaces;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Initializers.PresenterData.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddPresenterDataViewModelInitializer<TIPresenterDataViewModel, TIPresenterDataViewModelInitializerModel>(this IServiceCollection @this)
        where TIPresenterDataViewModel : IPresenterDataViewModel
        where TIPresenterDataViewModelInitializerModel : IPresenterDataViewModelInitializerModel
    {
        Type implementationInterfaceType =
            typeof(IPresenterDataViewModelInitializer<TIPresenterDataViewModel, TIPresenterDataViewModelInitializerModel>);

        Type implementationType =
            Assembly.GetCallingAssembly().DefinedTypes.Where(x => x.IsClass)
                                                      .Where(x => !x.IsAbstract)
                                                      .Single(x => x.GetInterfaces().Any(y => y == implementationInterfaceType && y.IsGenericType));

        @this.AddTransient(implementationInterfaceType, implementationType);
    }
}