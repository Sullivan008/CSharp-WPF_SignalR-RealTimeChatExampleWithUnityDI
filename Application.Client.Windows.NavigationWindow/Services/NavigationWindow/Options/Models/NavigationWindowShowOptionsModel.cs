using Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Interfaces;
using Application.Client.Windows.NavigationWindow.Window.Interfaces;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models;

public class NavigationWindowShowOptionsModel<TNavigationWindow, TNavigationWindowViewModel, TNavigationWindowViewModelInitializerModel> : INavigationWindowShowOptionsModel 
    where TNavigationWindow : INavigationWindow
    where TNavigationWindowViewModel : INavigationWindowViewModel
    where TNavigationWindowViewModelInitializerModel : INavigationWindowViewModelInitializerModel
{
    public Type WindowType => typeof(TNavigationWindow);

    public Type WindowViewModelType => typeof(TNavigationWindowViewModel);
    
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

    INavigationWindowViewModelInitializerModel INavigationWindowShowOptionsModel.WindowViewModelInitializerModel => WindowViewModelInitializerModel;
}
