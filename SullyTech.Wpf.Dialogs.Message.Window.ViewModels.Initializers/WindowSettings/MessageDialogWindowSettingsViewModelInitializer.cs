using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Initializers.WindowSettings.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Interfaces.WindowSettings;

namespace SullyTech.Wpf.Dialogs.Message.Window.ViewModels.Initializers.WindowSettings;

internal sealed class MessageDialogWindowSettingsViewModelInitializer : IDialogWindowSettingsViewModelInitializer<IMessageDialogWindowSettingsViewModel, IMessageDialogWindowSettingsViewModelInitializerModel>
{
    public void Initialize(IMessageDialogWindowSettingsViewModel windowSettingsViewModel, IMessageDialogWindowSettingsViewModelInitializerModel windowSettingsViewModelInitializerModel)
    {
        windowSettingsViewModel.Title = windowSettingsViewModelInitializerModel.Title;
    }
}