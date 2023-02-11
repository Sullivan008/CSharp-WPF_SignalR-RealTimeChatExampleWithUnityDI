using System.Windows.Input;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Commands.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Enums.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Interfaces.PresenterData;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Dialog.Window.Services.DialogWindow.Interfaces;

namespace SullyTech.Wpf.Dialogs.MessageDialog.Window.Presenter.ViewModels.Presenter;

public sealed class MessageDialogViewModel : PresenterViewModel<IMessageDialogDataViewModel>, IMessageDialogViewModel
{
    private readonly IDialogWindowService _dialogWindowService;

    public MessageDialogViewModel(IMessageDialogDataViewModel data, IDialogWindowService dialogWindowService) : base(data)
    {
        _dialogWindowService = dialogWindowService;
    }

    private IconType? _iconType;
    public IconType IconType
    {
        get
        {
            Guard.Guard.ThrowIfNull(_iconType, nameof(IconType));

            return _iconType!.Value;
        }

        set
        {
            _iconType = value;
            OnPropertyChanged();
        }
    }

    private ButtonType? _buttonType;
    public ButtonType ButtonType
    {
        get
        {
            Guard.Guard.ThrowIfNull(_buttonType, nameof(ButtonType));

            return _buttonType!.Value;
        }

        set
        {
            _buttonType = value;
            OnPropertyChanged();
        }
    }

    private ICommand? _okCommand;
    public ICommand OkCommand => _okCommand ??= new OkCommand(this, _dialogWindowService);

    private ICommand? _noCommand;
    public ICommand NoCommand => _noCommand ??= new NoCommand(this, _dialogWindowService);

    private ICommand? _yesCommand;
    public ICommand YesCommand => _yesCommand ??= new YesCommand(this, _dialogWindowService);

    private ICommand? _cancelCommand;
    public ICommand CancelCommand => _cancelCommand ??= new CancelCommand(this, _dialogWindowService);
}
