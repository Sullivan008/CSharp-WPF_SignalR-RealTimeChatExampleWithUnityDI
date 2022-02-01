using System.Reflection;
using Application.Client.Windows.ApplicationWindow.Services.CurrentApplicationWindow.Interfaces;
using Application.Client.Windows.ContentPresenter.Services.ContentPresenter.Interfaces;
using Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenter.Initializers.Interfaces;
using Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.ContentPresenter.Services.ContentPresenter;

internal class ContentPresenterService : IContentPresenterService
{
    private readonly IServiceProvider _serviceProvider;

    public ContentPresenterService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IContentPresenterViewModel GetContentPresenterViewModel<TContentPresenterViewModel>(ICurrentApplicationWindowService currentApplicationWindowService)
        where TContentPresenterViewModel : IContentPresenterViewModel
    {
        Type contentPresenterViewModelType = typeof(TContentPresenterViewModel);
        Type contentPresenterViewModelFactoryType = typeof(Func<,>)
            .MakeGenericType(typeof(ICurrentApplicationWindowService), contentPresenterViewModelType);

        Func<ICurrentApplicationWindowService, IContentPresenterViewModel> contentPresenterViewModelFactory =
            (Func<ICurrentApplicationWindowService, IContentPresenterViewModel>)_serviceProvider.GetRequiredService(contentPresenterViewModelFactoryType);

        return contentPresenterViewModelFactory(currentApplicationWindowService);
    }

    public void InitializeContentPresenterViewModel(IContentPresenterViewModel contentPresenterViewModel,
        IContentPresenterViewDataViewModelInitializerModel contentPresenterViewModelInitializerModel)
    {
        Type contentPresenterViewModelType = contentPresenterViewModel.GetType();
        Type contentPresenterViewModelInitializerModelType = contentPresenterViewModelInitializerModel.GetType();

        Type contentPresenterViewModelInitializerType = typeof(IContentPresenterViewModelInitializer<,>)
            .MakeGenericType(contentPresenterViewModelType, contentPresenterViewModelInitializerModelType);

        MethodInfo contentPresenterViewModelInitializerInitializeMethodInfo = contentPresenterViewModelInitializerType
            .GetMethods()
            .Single();

        var contentPresenterViewModelInitializer =
            _serviceProvider.GetRequiredService(contentPresenterViewModelInitializerType);

        contentPresenterViewModelInitializerInitializeMethodInfo
            .Invoke(contentPresenterViewModelInitializer, new object[] { contentPresenterViewModel, contentPresenterViewModelInitializerModel });
    }
}