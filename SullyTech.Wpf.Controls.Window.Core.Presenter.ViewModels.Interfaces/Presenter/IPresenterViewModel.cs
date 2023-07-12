using System.Windows.Input;
using SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.Presenter;

public interface IPresenterViewModel
{
    public string WindowId { get; set; }

    public IPresenterDataViewModel Data { get; }

    public ICommand LoadedCommand { get; set; }

    public Task OnBeforeLoadAsync();

    public Task OnAfterLoadAsync();

    public Task OnDestroyAsync();
}
