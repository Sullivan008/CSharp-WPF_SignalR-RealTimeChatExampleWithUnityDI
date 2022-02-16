using Application.Client.Windows.Core.Window.Interfaces;

namespace Application.Client.Windows.Core.Services.CurrentWindowService.Abstractions;

public abstract class CurrentWindowService
{
    protected readonly IWindow Window;

    protected CurrentWindowService(IWindow window)
    {
        Window = window;
    }

    public virtual async Task CloseWindow()
    {
        Window.Close();

        await Task.CompletedTask;
    }
}