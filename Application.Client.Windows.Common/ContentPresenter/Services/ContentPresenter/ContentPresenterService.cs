using System.Reflection;
using Application.Client.Windows.Common.ContentPresenter.Services.ContentPresenter.Interfaces;
using Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenter.Initializers.Interfaces;
using Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenter.Interfaces;
using Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenterViewData.Initializers.Models.Interfaces;
using Application.Client.Windows.Common.Services.CurrentWindowService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Client.Windows.Common.ContentPresenter.Services.ContentPresenter;

internal class ContentPresenterService : IContentPresenterService
{
    private readonly IServiceProvider _serviceProvider;

    public ContentPresenterService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IContentPresenterViewModel GetContentPresenterViewModel<TContentPresenterViewModel>(ICurrentWindowService currentApplicationWindowService)
        where TContentPresenterViewModel : IContentPresenterViewModel
    {
        Type contentPresenterViewModelType = typeof(TContentPresenterViewModel);
        Type contentPresenterViewModelFactoryType = typeof(Func<,>)
            .MakeGenericType(typeof(ICurrentWindowService), contentPresenterViewModelType);

        Func<ICurrentWindowService, IContentPresenterViewModel> contentPresenterViewModelFactory =
            (Func<ICurrentWindowService, IContentPresenterViewModel>)_serviceProvider.GetRequiredService(contentPresenterViewModelFactoryType);

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