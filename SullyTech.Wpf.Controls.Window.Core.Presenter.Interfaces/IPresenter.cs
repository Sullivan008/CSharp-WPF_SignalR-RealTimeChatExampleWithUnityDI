namespace SullyTech.Wpf.Controls.Window.Core.Presenter.Interfaces;

public interface IPresenter
{
    public string WindowId { get; set; }

    public object DataContext { get; set; }

    public Task OnBeforeLoadAsync();

    public Task OnAfterLoadAsync();

    public Task OnSetFocusAsync();
}