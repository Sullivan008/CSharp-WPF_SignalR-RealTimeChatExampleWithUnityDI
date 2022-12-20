using SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings.Models.Interfaces;

namespace SullyTech.Wpf.Dialogs.ExceptionDialog.Window.ViewModels.Initializers.WindowSettings.Models;

public sealed class ExceptionDialogWindowSettingsViewModelInitializerModel : IExceptionDialogWindowSettingsViewModelInitializerModel
{
    private readonly string? _title;
    public string Title
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_title, nameof(Title));

            return _title!;
        }

        init => _title = value;
    }
}