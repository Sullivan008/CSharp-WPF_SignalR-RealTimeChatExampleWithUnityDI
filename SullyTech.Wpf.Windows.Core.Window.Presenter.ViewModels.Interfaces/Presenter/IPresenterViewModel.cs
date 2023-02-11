using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;

public interface IPresenterViewModel
{
    public string PresenterWindowId { get; set; }

    public IPresenterDataViewModel Data { get; }

    public Task OnInitAsync();

    public Task OnDestroyAsync();
}
