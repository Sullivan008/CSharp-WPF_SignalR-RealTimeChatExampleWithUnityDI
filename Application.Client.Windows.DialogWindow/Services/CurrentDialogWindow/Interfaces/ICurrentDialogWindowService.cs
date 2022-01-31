using Application.Client.Windows.DialogWindow.ViewModels.DialogWindowSettings.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.Window.Interfaces;

namespace Application.Client.Windows.DialogWindow.Services.CurrentDialogWindow.Interfaces;

public interface ICurrentDialogWindowService
{
    internal IDialogWindow DialogWindow { get; }

    public void ReInitializeWindowSettings(Func<IDialogWindowSettingsViewModelInitializerModel> dialogWindowSettingsViewModelInitializerModelFactory);
}