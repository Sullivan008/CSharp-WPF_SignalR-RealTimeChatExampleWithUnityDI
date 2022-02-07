using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.Window.Interfaces;
using Application.Client.Windows.Common.Services.CurrentWindowService.Interfaces;

namespace Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow.Interfaces;

public interface ICurrentApplicationWindowService : ICurrentWindowService
{
    public IApplicationWindow ApplicationWindow { get; }

    public void ReInitializeWindowSettings(Func<IApplicationWindowSettingsViewModelInitializerModel> applicationWindowSettingsViewModelInitializerModelFactory);
}