using Application.Client.Windows.Services.ApplicationWindow.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Services.ApplicationWindow;

public class ApplicationWindowService : IApplicationWindowService
{
    private readonly IServiceProvider _serviceProvider;

    public ApplicationWindowService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ShowAsync<TApplicationWindow>() where TApplicationWindow : Windows.ApplicationWindow.Abstractions.Window.ApplicationWindow
    {
        TApplicationWindow applicationWindow = _serviceProvider.GetRequiredService<TApplicationWindow>();
        
        applicationWindow.Show();

        await Task.CompletedTask;
    }
}