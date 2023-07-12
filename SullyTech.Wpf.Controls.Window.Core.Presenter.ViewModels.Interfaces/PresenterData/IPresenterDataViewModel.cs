namespace SullyTech.Wpf.Controls.Window.Core.Presenter.ViewModels.Interfaces.PresenterData;

public interface IPresenterDataViewModel
{
    public Task OnBeforeLoadAsync();

    public Task OnAfterLoadAsync();

    public Task OnDestroyAsync();
}