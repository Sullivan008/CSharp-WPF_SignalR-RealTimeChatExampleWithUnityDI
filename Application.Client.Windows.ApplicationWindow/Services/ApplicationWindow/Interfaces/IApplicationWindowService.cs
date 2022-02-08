using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models.Interfaces;

namespace Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Interfaces;

public interface IApplicationWindowService
{
    public Task ShowAsync(IApplicationWindowShowOptionsModel applicationWindowOptions);
}