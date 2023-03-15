﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.Presenter;
using SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Interfaces.PresenterData;

namespace SullyTech.Wpf.Windows.Core.Window.Presenter.ViewModels.Presenter;

public class PresenterViewModel<TPresenterDataViewModel> : IPresenterViewModel, INotifyPropertyChanged
    where TPresenterDataViewModel : IPresenterDataViewModel
{
    protected PresenterViewModel(TPresenterDataViewModel data)
    {
        Data = data;
    }

    IPresenterDataViewModel IPresenterViewModel.Data => Data;

    private string? _presenterWindowId;
    public string PresenterWindowId
    {
        get
        {
            Guard.Guard.ThrowIfNullOrWhitespace(_presenterWindowId, nameof(PresenterWindowId));

            return _presenterWindowId!;
        }

        set
        {
            Guard.Guard.ThrowIfNotNullOrNotWhitespace(_presenterWindowId, nameof(PresenterWindowId));
            Guard.Guard.ThrowIfNullOrWhitespace(value, nameof(value));

            _presenterWindowId = value;
        }
    }

    private TPresenterDataViewModel? _data;
    public TPresenterDataViewModel Data
    {
        get
        {
            Guard.Guard.ThrowIfNull(_data, nameof(Data));

            return _data!;
        }

        set
        {
            _data = value;
            OnPropertyChanged();
        }
    }

    public virtual async Task OnInitAsync()
    {
        await Task.CompletedTask;
    }

    public virtual async Task OnDestroyAsync()
    {
        await Task.CompletedTask;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public virtual void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}