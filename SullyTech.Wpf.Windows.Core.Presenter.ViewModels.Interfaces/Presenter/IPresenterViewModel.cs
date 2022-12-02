using SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Windows.Core.Presenter.ViewModels.Interfaces.Presenter;

public interface IPresenterViewModel
{
    public IPresenterDataViewModel Data { get; }
}