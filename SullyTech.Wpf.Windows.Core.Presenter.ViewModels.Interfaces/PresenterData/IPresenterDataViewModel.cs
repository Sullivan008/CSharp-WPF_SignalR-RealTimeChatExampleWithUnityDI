namespace SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;

public interface IPresenterDataViewModel
{
    public Task OnInit();

    public Task OnDestroy();
}