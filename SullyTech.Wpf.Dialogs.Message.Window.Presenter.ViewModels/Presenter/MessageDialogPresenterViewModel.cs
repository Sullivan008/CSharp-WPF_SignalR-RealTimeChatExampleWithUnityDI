using System.Windows.Input;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Controls.Window.Dialog.Services.DialogWindow.Interfaces;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Commands.Presenter.Cancel;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Commands.Presenter.Loaded;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Commands.Presenter.No;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Commands.Presenter.Ok;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Commands.Presenter.Yes;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Enums.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Dialogs.Message.Window.Presenter.ViewModels.Presenter;

public sealed class MessageDialogPresenterViewModel : PresenterViewModel<IMessageDialogPresenterDataViewModel>, IMessageDialogPresenterViewModel
{
    private readonly IDialogWindowService _dialogWindowService;

    public MessageDialogPresenterViewModel(IMessageDialogPresenterDataViewModel data, IDialogWindowService dialogWindowService) : base(data)
    {
        _dialogWindowService = dialogWindowService;

        LoadedCommand = new LoadedCommand(this);
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
