using Application.Client.Windows.Common.Services.CurrentWindowService.Interfaces;
using Application.Client.Windows.Common.Window.Interfaces;

namespace Application.Client.Windows.Common.Services.CurrentWindowService;

public class CurrentWindowService : ICurrentWindowService
{
    private readonly IWindow _window;

    public CurrentWindowService(IWindow window)
    {
        _window = window;
    }
}