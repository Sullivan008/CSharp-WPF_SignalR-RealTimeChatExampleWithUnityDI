using SullyTech.Wpf.Windows.Core.Services.CurrentWindow.Interfaces;
using SullyTech.Wpf.Windows.Core.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Windows.Core.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Core.Services.CurrentWindow.Abstractions;

public abstract class CurrentWindowService : ICurrentWindowService
{
    protected readonly IWindow Window;

    protected CurrentWindowService(IWindow window)
    {
        Window = window;
    }

    public virtual async Task CloseWindowAsync()
    {
        Window.Close();

        await Task.CompletedTask;
    }

    public virtual async Task SetWindowHeightAsync(double height)
    {
        ((IWindowViewModel)Window.DataContext).Settings.Height = height;

        await Task.CompletedTask;
    }

    public virtual async Task SetWindowWidthAsync(double width)
    {
        ((IWindowViewModel)Window.DataContext).Settings.Width = width;

        await Task.CompletedTask;
    }
}