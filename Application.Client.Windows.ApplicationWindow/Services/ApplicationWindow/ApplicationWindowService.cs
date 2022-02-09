using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Initializers.Interfaces;
using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.Window.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Services.ContentPresenter.Interfaces;
using Application.Client.Windows.Core.Services.WindowService.Abstractions;

namespace Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow;

public class ApplicationWindowService : WindowService, IApplicationWindowService
{
    public ApplicationWindowService(IServiceProvider serviceProvider, IContentPresenterService contentPresenterService) : base(serviceProvider, contentPresenterService)
    { }

    public async Task ShowAsync(IApplicationWindowShowOptionsModel applicationWindowOptions, IContentPresenterLoadOptions contentPresenterLoadOptions)
    {
        IApplicationWindow applicationWindow = (IApplicationWindow)CreateWindow(applicationWindowOptions.WindowType);

        IApplicationWindowViewModel applicationWindowViewModel = (IApplicationWindowViewModel)CreateWindowViewModel(applicationWindowOptions.WindowViewModelType);
        InitializeWindowViewModel(applicationWindowViewModel, applicationWindowOptions.WindowViewModelInitializerModel);

        ICurrentApplicationWindowService currentApplicationWindowService = (ICurrentApplicationWindowService)CreateCurrentWindowService(applicationWindow);
        LoadContentPresenter(contentPresenterLoadOptions, currentApplicationWindowService, applicationWindowViewModel);

        SetWindowDataContext(applicationWindow, applicationWindowViewModel);

        applicationWindow.Show();

        await Task.CompletedTask;
    }

    protected override Type CurrentWindowServiceType => typeof(ICurrentApplicationWindowService);

    protected override Type WindowViewModelInitializerGenericType => typeof(IApplicationWindowViewModelInitializer<,>);
}