using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Models.Interfaces;
using Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Interfaces;

namespace Application.Client.Windows.DialogWindow.ViewModels.DialogWindow.Initializers.Interfaces;

public interface IDialogWindowViewModelInitializer<in TDialogWindowViewModel, in TDialogWindowViewModelInitializerModel> where TDialogWindowViewModel : IDialogWindowViewModel
                                                                                                                         where TDialogWindowViewModelInitializerModel : IDialogWindowViewModelInitializerModel
{
    public void Initialize(TDialogWindowViewModel dialogWindowViewModel, TDialogWindowViewModelInitializerModel dialogWindowViewModelInitializerModel);
}