
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SullyTech.Guid.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Initializer.Models.Interfaces.PresenterData;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Controls.Window.Core.Services.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializer.Models.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Initializer.Models.Interfaces.WindowSettings;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions;

public abstract class WindowService : IWindowService
{
    protected readonly IGuid Guid;

    protected readonly IMapper Mapper;

    protected readonly IServiceProvider ServiceProvider;

    protected WindowService(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;

        Guid = serviceProvider.GetRequiredService<IGuid>();
        Mapper = serviceProvider.GetRequiredService<IMapper>();
    }

    protected virtual IWindow CreateWindow(Type windowType)
    {
        IWindow window = (IWindow)ServiceProvider.GetRequiredService(windowType);
        window.Id = Guid.NewGuid().ToString();

        return window;
    }

    protected virtual IWindowViewModel CreateWindowViewModel(IWindow window, Type windowViewModelType)
    {
        IWindowViewModel windowViewModel = (IWindowViewModel)ServiceProvider.GetRequiredService(windowViewModelType);
        windowViewModel.WindowId = window.Id;

        return windowViewModel;
    }

    protected virtual IPresenter CreatePresenter(IWindow window, Type presenterType)
    {
        IPresenter presenter = (IPresenter)ServiceProvider.GetRequiredService(presenterType);
        presenter.WindowId = window.Id;

        return presenter;
    }

    protected virtual IPresenterViewModel CreatePresenterViewModel(IWindow window, Type presenterViewModelType)
    {
        IPresenterViewModel presenterViewModel = (IPresenterViewModel)ServiceProvider.GetRequiredService(presenterViewModelType);
        presenterViewModel.WindowId = window.Id;

        return presenterViewModel;
    }

    protected virtual void InitializeWindowViewModel(IWindowViewModel windowViewModel, Type windowViewModelType,
        IWindowViewModelInitializerModel? windowViewModelInitializerModel, Type? windowViewModelInitializerModelType)
    {
        if (windowViewModelInitializerModel is not null && windowViewModelInitializerModelType is not null)
        {
            Mapper.Map(windowViewModelInitializerModel, windowViewModel,
                       windowViewModelInitializerModelType, windowViewModelType);
        }
    }

    protected virtual void InitializeWindowSettingsViewModel(IWindowSettingsViewModel windowSettingsViewModel, Type windowSettingsViewModelType,
        IWindowSettingsViewModelInitializerModel? windowSettingsViewModelInitializerModel, Type? windowSettingsViewModelInitializerModelType)
    {
        if (windowSettingsViewModelInitializerModel is not null && windowSettingsViewModelInitializerModelType is not null)
        {
            Mapper.Map(windowSettingsViewModelInitializerModel, windowSettingsViewModel,
                       windowSettingsViewModelInitializerModelType, windowSettingsViewModelType);
        }
    }

    protected virtual void InitializePresenterViewModel(IPresenterViewModel presenterViewModel, Type presenterViewModelType,
        IPresenterViewModelInitializerModel? presenterViewModelInitializerModel, Type? presenterViewModelInitializerModelType)
    {
        if (presenterViewModelInitializerModel is not null && presenterViewModelInitializerModelType is not null)
        {
            Mapper.Map(presenterViewModelInitializerModel, presenterViewModel,
                       presenterViewModelInitializerModelType, presenterViewModelType);
        }
    }

    protected virtual void InitializePresenterDataViewModel(IPresenterDataViewModel presenterDataViewModel, Type presenterDataViewModelType,
        IPresenterDataViewModelInitializerModel? presenterDataViewModelInitializerModel, Type? presenterDataViewModelInitializerModelType)
    {
        if (presenterDataViewModelInitializerModel is not null && presenterDataViewModelInitializerModelType is not null)
        {
            Mapper.Map(presenterDataViewModelInitializerModel, presenterDataViewModel,
                       presenterDataViewModelInitializerModelType, presenterDataViewModelType);
        }
    }

    protected virtual void SetPresenterDataContext(IPresenter presenter, IPresenterViewModel presenterViewModel)
    {
        presenter.DataContext = presenterViewModel;
    }

    protected virtual void SetWindowPresenter(IWindowViewModel windowViewModel, IPresenter presenter)
    {
        windowViewModel.Presenter = presenter;
    }

    protected virtual void SetWindowDataContext(IWindow window, IWindowViewModel windowViewModel)
    {
        window.DataContext = windowViewModel;
    }
}