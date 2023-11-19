using SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions;
using SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Controls.Window.Standard.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.MethodParameters.WindowShowOptions.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.ViewModels.Interfaces.Window;

namespace SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow;

public sealed class StandardWindowService : WindowService, IStandardWindowService
{
    public StandardWindowService(IServiceProvider serviceProvider) : base(serviceProvider)
    { }

    public async Task ShowWindowAsync(IStandardWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions)
    {
        IStandardWindow window = (IStandardWindow)CreateWindow(windowShowOptions.WindowType);
        IStandardWindowViewModel windowViewModel = (IStandardWindowViewModel)CreateWindowViewModel(window, windowShowOptions.WindowViewModelType);

        IPresenter presenter = CreatePresenter(window, presenterLoadOptions.PresenterType);
        IPresenterViewModel presenterViewModel = CreatePresenterViewModel(window, presenterLoadOptions.PresenterViewModelType);

        InitializeWindowViewModels(windowViewModel, windowShowOptions);
        InitializePresenterViewModels(presenterViewModel, presenterLoadOptions);

        SetWindow(window, windowViewModel, presenter, presenterViewModel);

        await OnBeforeLoadAsync(windowViewModel, presenter, presenterViewModel);

        window.Show();
    }

    private void InitializeWindowViewModels(IWindowViewModel windowViewModel, IStandardWindowShowOptions windowShowOptions)
    {
        InitializeWindowViewModel(windowViewModel, windowShowOptions.WindowViewModelType, 
                                  windowShowOptions.WindowViewModelInitializerModel, windowShowOptions.WindowViewModelInitializerModelType);

        InitializeWindowSettingsViewModel(windowViewModel.Settings, windowShowOptions.WindowSettingsViewModelType,
                                          windowShowOptions.WindowSettingsViewModelInitializerModel, windowShowOptions.WindowSettingsViewModelInitializerModelType);
    }

    private void InitializePresenterViewModels(IPresenterViewModel presenterViewModel, IPresenterLoadOptions presenterLoadOptions)
    {
        InitializePresenterViewModel(presenterViewModel, presenterLoadOptions.PresenterViewModelType,
                                     presenterLoadOptions.PresenterViewModelInitializerModel, presenterLoadOptions.PresenterViewModelInitializerModelType);

        InitializePresenterDataViewModel(presenterViewModel.Data, presenterLoadOptions.PresenterDataViewModelType,
                                         presenterLoadOptions.PresenterDataViewModelInitializerModel, presenterLoadOptions.PresenterDataViewModelInitializerModelType);
    }

    private void SetWindow(IStandardWindow window, IStandardWindowViewModel windowViewModel, IPresenter presenter, IPresenterViewModel presenterViewModel)
    {
        SetPresenterDataContext(presenter, presenterViewModel);
        SetWindowPresenter(windowViewModel, presenter);
        SetWindowDataContext(window, windowViewModel);
    }

    private static async Task OnBeforeLoadAsync(IStandardWindowViewModel windowViewModel, IPresenter presenter, IPresenterViewModel presenterViewModel)
    {
        await presenterViewModel.Data.OnBeforeLoadAsync();
        await presenterViewModel.OnBeforeLoadAsync();
        await presenter.OnBeforeLoadAsync();

        await windowViewModel.Settings.OnBeforeLoadAsync();
        await windowViewModel.OnBeforeLoadAsync();
    }
}