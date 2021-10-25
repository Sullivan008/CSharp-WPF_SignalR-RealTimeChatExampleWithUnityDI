using Application.Client.Windows.Main.ViewModels.Interfaces;

namespace Application.Client.Windows.Main
{
    public partial class MainWindow
    {
        public MainWindow(IMainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();

            DataContext = mainWindowViewModel;
        }
    }
}
