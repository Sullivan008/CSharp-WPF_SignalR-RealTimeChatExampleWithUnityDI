using Application.Client.Windows.DialogWindow.Core.ViewModels.DialogWindow.Initializers.Models.Interfaces;

namespace Application.Client.Windows.DialogWindow.Core.Services.DialogWindow.Options.Models.Interfaces;

public interface IDialogWindowShowDialogOptionsModel
{
    internal Type WindowType { get; }

    internal Type WindowViewModelType { get; }

    internal IDialogWindowViewModelInitializerModel WindowViewModelInitializerModel { get; }
}