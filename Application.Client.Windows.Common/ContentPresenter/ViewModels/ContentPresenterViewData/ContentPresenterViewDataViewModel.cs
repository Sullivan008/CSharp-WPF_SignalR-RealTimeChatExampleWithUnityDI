using System.ComponentModel;
using System.Runtime.CompilerServices;
using Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenterViewData.Interfaces;

namespace Application.Client.Windows.Common.ContentPresenter.ViewModels.ContentPresenterViewData;

public class ContentPresenterViewDataViewModel : IContentPresenterViewDataViewModel, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}