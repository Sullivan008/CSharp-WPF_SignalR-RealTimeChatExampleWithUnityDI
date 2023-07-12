using SullyTech.Wpf.Controls.Window.Core.Interfaces;
using SullyTech.Wpf.Controls.Window.Dialog.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.Interfaces;
using SullyTech.Wpf.Services.Navigation.Models.MethodParameters.NavigateToOptions.Interfaces;

namespace SullyTech.Wpf.Services.Navigation.Interfaces;

public interface INavigationService
{
    public Task NavigateToAsync(string windowId, INavigateToOptions navigateToOptions);

    public Task NavigateToAsync(IWindow window, INavigateToOptions navigateToOptions);

    public Task NavigateToAsync(IStandardWindow window, INavigateToOptions navigateToOptions);

    public Task NavigateToAsync(IDialogWindow window, INavigateToOptions navigateToOptions);
}