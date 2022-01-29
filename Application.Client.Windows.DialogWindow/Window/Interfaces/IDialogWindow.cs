namespace Application.Client.Windows.DialogWindow.Window.Interfaces;

public interface IDialogWindow
{
    public object DataContext { get; set; }

    public bool? DialogResult { get; set; }

    public bool? ShowDialog();
}