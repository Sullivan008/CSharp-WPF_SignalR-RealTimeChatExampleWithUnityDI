using System.ComponentModel;
using System.Runtime.CompilerServices;
using Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData.Interfaces;

namespace Application.Client.Windows.Core.ContentPresenter.ViewModels.ContentPresenterViewData;

public class ContentPresenterViewDataViewModel : INotifyPropertyChanged, IContentPresenterViewDataViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        if (name != null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}