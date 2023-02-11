namespace SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;

public interface IPresenterDataViewModel
{
    public Task OnInitAsync();

    public Task OnDestroyAsync();
}