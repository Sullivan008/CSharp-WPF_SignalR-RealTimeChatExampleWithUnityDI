namespace SullyTech.Wpf.Windows.Core.Services.CurrentWindow.Interfaces;

public interface ICurrentWindowService
{
    public Task CloseWindowAsync();

    public Task SetWindowWidthAsync(double width);

    public Task SetWindowHeightAsync(double height);
}