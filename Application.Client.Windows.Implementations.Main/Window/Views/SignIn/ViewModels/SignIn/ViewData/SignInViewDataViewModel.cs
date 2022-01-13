﻿using Application.Client.Windows.Navigation.ViewNavigation.Pages.ViewModels.Abstractions;
using Application.Common.Utilities.Guard;

namespace Application.Client.Windows.Implementations.Main.Window.Views.SignIn.ViewModels.SignIn.ViewData;

public class SignInViewDataViewModel : BasePageViewDataViewModel
{
    private string _content = string.Empty;
    public string Content
    {
        get => _content;
        set
        {
            Guard.ThrowIfNullOrWhitespace(value, nameof(Content));
            _content = value;

            OnPropertyChanged();
        }
    }
}