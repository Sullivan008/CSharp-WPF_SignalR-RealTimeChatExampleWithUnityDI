using SullyTech.Wpf.Controls.Window.Dialog.ViewModels.Window;
using SullyTech.Wpf.Dialogs.Exception.Window.Result.Interfaces;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Commands.Window.Closing;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Commands.Window.Loaded;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.Window;
using SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Interfaces.WindowSettings;
using SullyTech.Wpf.Services.Window.Destroyer.Interfaces;

namespace SullyTech.Wpf.Dialogs.Exception.Window.ViewModels.Window;

public sealed class ExceptionDialogWindowViewModel : DialogWindowViewModel<IExceptionDialogWindowSettingsViewModel, IExceptionDialogResult>, IExceptionDialogWindowViewModel
{
    public ExceptionDialogWindowViewModel(IExceptionDialogWindowSettingsViewModel settings, IWindowDestroyerService windowDestroyerService) : base(settings)
    {
        LoadedCommand = new LoadedCommand(this);
        ClosingCommand = new ClosingCommand(this, windowDestroyerService);
    }
}