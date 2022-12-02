using System.Windows.Input;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Commands;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.Enums;
using Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox.ViewData;
using SullyTech.Guard;
using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Presenter;
using SullyTech.Wpf.Windows.Dialog.Services.CurrentDialogWindow.Interfaces;

namespace Application.Client.Windows.DialogWindow.Impl.MessageBox.Window.Views.MessageBox.ViewModels.MessageBox;

public class MessageBoxViewModel : PresenterViewModel<MessageBoxViewDataViewModel>
{
    private readonly ICurrentDialogWindowService _currentWindowService;

    public MessageBoxViewModel(MessageBoxViewDataViewModel viewData, ICurrentDialogWindowService currentWindowService) : base(viewData)
    {
        _currentWindowService = currentWindowService;
    }

    private MessageBoxIcon? _messageBoxIcon;
    public MessageBoxIcon MessageBoxIcon
    {
        get
        {
            Guard.ThrowIfNull(_messageBoxIcon, nameof(MessageBoxIcon));

            return _messageBoxIcon!.Value;
        }

        set
        {
            _messageBoxIcon = value;
            OnPropertyChanged();
        }
    }

    private MessageBoxButton? _messageBoxButton;
    public MessageBoxButton MessageBoxButton
    {
        get
        {
            Guard.ThrowIfNull(_messageBoxButton, nameof(MessageBoxButton));

            return _messageBoxButton!.Value;
        }

        set
        {
            _messageBoxButton = value;
            OnPropertyChanged();
        }
    }

    private ICommand? _okCommand;
    public ICommand OkCommand => _okCommand ??= new OkCommand(this, _currentWindowService);

    private ICommand? _noCommand;
    public ICommand NoCommand => _noCommand ??= new NoCommand(this, _currentWindowService);

    private ICommand? _yesCommand;
    public ICommand YesCommand => _yesCommand ??= new YesCommand(this, _currentWindowService);

    private ICommand? _cancelCommand;
    public ICommand CancelCommand => _cancelCommand ??= new CancelCommand(this, _currentWindowService);
}