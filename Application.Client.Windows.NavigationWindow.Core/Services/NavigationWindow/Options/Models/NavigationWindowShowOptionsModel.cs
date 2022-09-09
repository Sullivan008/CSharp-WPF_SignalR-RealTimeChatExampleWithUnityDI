using Application.Client.Windows.NavigationWindow.Core.Services.NavigationWindow.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Core.Window.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.NavigationWindow.Core.Services.NavigationWindow.Options.Models;

public class NavigationWindowShowOptionsModel<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel> : INavigationWindowShowOptionsModel 
    where TNavigationWindow : INavigationWindow
    where TNavigationWindowViewModel : INavigationWindowViewModel
    where TNavigationWindowViewModelInitializerModel : INavigationWindowViewModelInitializerModel
{
    Type INavigationWindowShowOptionsModel.WindowType => typeof(TNavigationWindow);

    Type INavigationWindowShowOptionsModel.WindowViewModelType => typeof(TNavigationWindowViewModel);

    INavigationWindowViewModelInitializerModel INavigationWindowShowOptionsModel.WindowViewModelInitializerModel => WindowViewModelInitializerModel;

    private readonly TNavigationWindowViewModelInitializerModel? _windowViewModelInitializerModel;
    public TNavigationWindowViewModelInitializerModel WindowViewModelInitializerModel
    {
        get
        {
            Guard.ThrowIfNull(_windowViewModelInitializerModel, nameof(WindowViewModelInitializerModel));
            return _windowViewModelInitializerModel!;
        }

        init
        {
            Guard.ThrowIfNull(value, nameof(WindowViewModelInitializerModel));
            _windowViewModelInitializerModel = value;
        }
    }
}
