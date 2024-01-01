using System.Windows.Input;
using SullyTech.Wpf.Controls.Presenter.Core.ViewModels.Presenter;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Commands;
using SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter.Enums;

namespace SullyTech.Wpf.Dialogs.Message.Presenter.ViewModels.Presenter;

public sealed class MessageDialogPresenterViewModel : PresenterViewModel
{
    private readonly IDialogWindowService _dialogWindowService;

    public MessageDialogPresenterViewModel(IDialogWindowService dialogWindowService)
    {
        _dialogWindowService = dialogWindowService;

        LoadedCommand = new LoadedCommand(this);
    }

    private string _message = string.Empty;
    public string Message
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_message);

            return _message!;
        }

        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }

    private IconType? _iconType;
    public IconType IconType
    {
        get
        {
            Guard.Guard.ThrowIfNull(_iconType);

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
            Guard.Guard.ThrowIfNull(_buttonType);

            return _buttonType!.Value;
        }

        set
        {
            _buttonType = value;
            OnPropertyChanged();
        }
    }

    private ICommand? _okCommand;
    public ICommand OkCommand =>
        _okCommand ??= new OkCommand(this, _dialogWindowService);


    private ICommand? _noCommand;
    public ICommand NoCommand =>
        _noCommand ??= new NoCommand(this, _dialogWindowService);


    private ICommand? _yesCommand;
    public ICommand YesCommand =>
        _yesCommand ??= new YesCommand(this, _dialogWindowService);


    private ICommand? _cancelCommand;
    public ICommand CancelCommand =>
        _cancelCommand ??= new CancelCommand(this, _dialogWindowService);
}
