using System.Windows;
using App.Client.Wpf.Modules.Identity.Presenters.SignIn.ViewModels;
using SullyTech.Wpf.Controls.Window.Core.ViewModels.Window;
using SullyTech.Wpf.Controls.Window.Standard.Core.ViewModels.Window;

namespace App.Client.Wpf.Modules.Identity.Presenters.SignIn.UserControls;

public sealed partial class SignInPresenter : SullyTech.Wpf.Controls.Presenter.Core.UserControls.Presenter.Presenter
{
    private readonly SignInPresenterViewModel _asd;

    public SignInPresenter(SignInPresenterViewModel asd)
    {
        _asd = asd;


        InitializeComponent();

        DataContext = _asd;

        Loaded += MyUserControl_Loaded;

        Unloaded += OnUnloaded;

        //asd.NickName = "KisKutty";
    }

    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
        
    }

    private void OnInitialized(object? sender, EventArgs e)
    {
        
    }

    private void MyUserControl_Loaded(object sender, RoutedEventArgs e)
    {
        // Itt lekérheted a szülő Window-t
        var parentWindow = Window.GetWindow(this);

        if (parentWindow != null)
        {
            _asd.WindowId = ((StandardWindowViewModel)(parentWindow.DataContext)).Id;

            MessageBox.Show($"This UserControl belongs to {parentWindow.Title}");
        }
    }

    public override void OnApplyTemplate()
    {
        _asd.NickName = "terefere";

        base.OnApplyTemplate();
    }
}