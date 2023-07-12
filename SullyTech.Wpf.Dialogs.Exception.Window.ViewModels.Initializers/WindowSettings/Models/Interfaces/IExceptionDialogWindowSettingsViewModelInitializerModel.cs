using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.WindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

public interface IExceptionDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{
    public string Title { get; init; }
}