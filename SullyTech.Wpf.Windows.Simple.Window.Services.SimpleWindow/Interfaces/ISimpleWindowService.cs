using SullyTech.Wpf.Windows.Core.Window.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Windows.Core.Window.Services.Window.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.Services.SimpleWindow.MethodParameters.WindowShowOptions.Interfaces;

namespace SullyTech.Wpf.Windows.Simple.Window.Services.SimpleWindow.Interfaces;

public interface ISimpleWindowService : IWindowService
{
    public Task<ISimpleWindow> GetWindowAsync(string windowId);

    public Task ShowAsync(ISimpleWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions);
}