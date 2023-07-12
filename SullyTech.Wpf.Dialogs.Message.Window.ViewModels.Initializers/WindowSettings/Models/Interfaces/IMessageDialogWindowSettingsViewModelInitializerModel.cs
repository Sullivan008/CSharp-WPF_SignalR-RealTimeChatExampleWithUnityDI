using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.WindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

public interface IMessageDialogWindowSettingsViewModelInitializerModel : IDialogWindowSettingsViewModelInitializerModel
{
    public string Title { get; init; }
}