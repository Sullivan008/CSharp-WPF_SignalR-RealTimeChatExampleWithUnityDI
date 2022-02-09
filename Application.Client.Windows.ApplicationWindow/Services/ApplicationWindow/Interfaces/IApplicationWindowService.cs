using Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Options.Models.Interfaces;
using Application.Client.Windows.Core.ContentPresenter.Options.Models.Interfaces;
using Application.Client.Windows.Core.Services.WindowService.Interfaces;

namespace Application.Client.Windows.ApplicationWindow.Services.ApplicationWindow.Interfaces;

public interface IApplicationWindowService : IWindowService
{
    public Task ShowAsync(IApplicationWindowShowOptionsModel applicationWindowOptions, IContentPresenterLoadOptions contentPresenterLoadOptions);
}