﻿using Microsoft.Extensions.DependencyInjection;
using SullyTech.Wpf.Windows.Simple.Window.ViewModels.Interfaces.SimpleWindow;

namespace SullyTech.Wpf.Windows.Simple.Window.ViewModels.SimpleWindow.Infrastructure.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddSimpleWindowViewModel<TISimpleWindowViewModel, TSimpleWindowViewModel>(this IServiceCollection @this)
        where TSimpleWindowViewModel : TISimpleWindowViewModel
        where TISimpleWindowViewModel : ISimpleWindowViewModel
    {
        @this.AddTransient(typeof(TISimpleWindowViewModel), typeof(TSimpleWindowViewModel));
    }
}