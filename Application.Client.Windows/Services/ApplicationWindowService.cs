using Application.Client.Windows.Abstractions.Windows;
using Application.Client.Windows.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Services;

public class ApplicationWindowService : IApplicationWindowService
{
    private readonly IServiceProvider _serviceProvider;

    public ApplicationWindowService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ShowAsync<TApplicationWindow>() where TApplicationWindow : ApplicationWindow
    {
        TApplicationWindow applicationWindow = _serviceProvider.GetRequiredService<TApplicationWindow>();
        
        applicationWindow.Show();

        await Task.CompletedTask;
    }
}