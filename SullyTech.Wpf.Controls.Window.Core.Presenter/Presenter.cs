using SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter;

public class Presenter : System.Windows.Controls.UserControl, IPresenter
{
    private string? _windowId;
    public string WindowId
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_windowId, nameof(WindowId));

            return _windowId!;
        }

        set
        {
            Guard.Guard.ThrowIfNotNullOrNotWhitespace(_windowId, nameof(WindowId));
            Guard.Guard.ThrowIfNullOrWhitespace(value, nameof(value));

            _windowId = value;
        }
    }

    public virtual async Task OnBeforeLoadAsync()
    {
        await Task.CompletedTask;
    }

    public virtual async Task OnAfterLoadAsync()
    {
        await Task.CompletedTask;
    }

    public virtual async Task OnSetFocusAsync()
    {
        await Task.CompletedTask;
    }
}