using SullyTech.Wpf.Controls.Window.Core.Services.Window.Abstractions.MethodParameters.PresenterLoadOptions.Interfaces;
using SullyTech.Wpf.Controls.Window.Core.Services.Window.Interfaces;
using SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.MethodParameters.WindowShowOptions.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Standard.Services.StandardWindow.Interfaces;

public interface IStandardWindowService : IWindowService
{
    public Task ShowWindowAsync(IStandardWindowShowOptions windowShowOptions, IPresenterLoadOptions presenterLoadOptions);
}