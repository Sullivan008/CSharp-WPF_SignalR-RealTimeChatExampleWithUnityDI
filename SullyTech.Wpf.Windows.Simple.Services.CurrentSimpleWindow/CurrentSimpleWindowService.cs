using SullyTech.Wpf.Windows.Core.Services.CurrentWindow.Abstractions;
using SullyTech.Wpf.Windows.Simple.Services.CurrentSimpleWindow.Interfaces;
using SullyTech.Wpf.Windows.Simple.Window.Interfaces;

namespace SullyTech.Wpf.Windows.Simple.Services.CurrentSimpleWindow;

public sealed class CurrentSimpleWindowService : CurrentWindowService, ICurrentSimpleWindowService
{
    public CurrentSimpleWindowService(ISimpleWindow window) : base(window)
    { }
}