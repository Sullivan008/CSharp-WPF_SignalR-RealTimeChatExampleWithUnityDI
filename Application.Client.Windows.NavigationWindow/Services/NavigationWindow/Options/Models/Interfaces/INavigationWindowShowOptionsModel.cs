using Application.Client.Windows.NavigationWindow.ViewModels.NavigationWindow.Initializers.Models.Interfaces;

namespace Application.Client.Windows.NavigationWindow.Services.NavigationWindow.Options.Models.Interfaces;

public interface INavigationWindowShowOptionsModel
{
    public Type WindowType { get; }

    public Type WindowViewModelType { get; }

    internal INavigationWindowViewModelInitializerModel WindowViewModelInitializerModel { get; }
}