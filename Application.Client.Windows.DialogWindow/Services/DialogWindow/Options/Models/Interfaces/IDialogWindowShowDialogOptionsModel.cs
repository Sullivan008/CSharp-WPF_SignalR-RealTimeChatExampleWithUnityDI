using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Models.Interfaces;

namespace Application.Client.Windows.DialogWindow.Services.DialogWindow.Options.Models.Interfaces;

public interface IDialogWindowShowDialogOptionsModel
{
    internal Type WindowType { get; }

    internal Type WindowViewModelType { get; }

    internal IDialogWindowViewModelInitializerModel WindowViewModelInitializerModel { get; }
}