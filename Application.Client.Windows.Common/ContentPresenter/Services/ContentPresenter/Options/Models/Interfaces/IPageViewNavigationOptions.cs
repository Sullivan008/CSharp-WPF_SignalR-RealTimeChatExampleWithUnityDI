namespace Application.Client.Windows.Common.ContentPresenter.Services.ContentPresenter.Options.Models.Interfaces;

public interface IPageViewNavigationOptions
{
    public Type PageViewViewModelType { get; }

    public Type PageViewViewModelInitializerModelType { get; }

    public IPageViewViewModelInitializerModel? PageViewViewModelInitializerModel { get; }
}