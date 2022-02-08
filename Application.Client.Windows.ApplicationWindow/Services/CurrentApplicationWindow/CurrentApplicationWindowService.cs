using Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow.Interfaces;
using Application.Client.Windows.ApplicationWindow.Window.Interfaces;
using Application.Client.Windows.Core.Services.CurrentWindowService.Abstractions;

namespace Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow;

public class CurrentApplicationWindowService : CurrentWindowService, ICurrentApplicationWindowService
{
    public CurrentApplicationWindowService(IApplicationWindow applicationWindow) : base(applicationWindow)
    { }
}