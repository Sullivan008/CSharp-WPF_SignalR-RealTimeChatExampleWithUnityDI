using Application.Client.Windows.Abstractions.Windows;

namespace Application.Client.Windows.Services.Interfaces;

public interface IApplicationWindowService
{
    public Task ShowAsync<TApplicationWindow>() where TApplicationWindow : ApplicationWindow;
}