namespace Application.Client.Windows.Services.ApplicationWindow.Interfaces;

public interface IApplicationWindowService
{
    public Task ShowAsync<TApplicationWindow>() where TApplicationWindow : Windows.ApplicationWindow.Abstractions.ApplicationWindow;
}