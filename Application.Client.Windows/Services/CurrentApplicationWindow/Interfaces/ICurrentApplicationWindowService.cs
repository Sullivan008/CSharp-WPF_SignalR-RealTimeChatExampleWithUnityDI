using Application.Client.Windows.ApplicationWindow.ViewModels.ApplicationWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.ApplicationWindow.Window.Interfaces;

namespace Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow.Interfaces;

public interface ICurrentApplicationWindowService
{
    public IApplicationWindow ApplicationWindow { get; }

    public void ReInitializeWindowSettings(Func<IApplicationWindowSettingsViewModelInitializerModel> applicationWindowSettingsViewModelInitializerModelFactory);
}