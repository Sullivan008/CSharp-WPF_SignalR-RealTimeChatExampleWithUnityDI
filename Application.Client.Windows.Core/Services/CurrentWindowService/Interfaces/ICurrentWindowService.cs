namespace Application.Client.Windows.Core.Services.CurrentWindowService.Interfaces;

public interface ICurrentWindowService
{
    public Task CloseWindow();

    public Task SetWindowHeight(int height);
}