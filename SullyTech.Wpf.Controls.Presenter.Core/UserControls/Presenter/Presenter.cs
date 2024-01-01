namespace SullyTech.Wpf.Controls.Presenter.Core.UserControls.Presenter;

public class Presenter : System.Windows.Controls.UserControl
{
    private string? _windowId;
    public string WindowId
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_windowId);

            return _windowId!;
        }

        set
        {
            Guard.Guard.ThrowIfNullOrWhitespace(value);
            Guard.Guard.ThrowIfNotNullOrNotWhitespace(_windowId);

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