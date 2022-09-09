using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace Application.Client.Windows.Core.Window.Behaviors;

public class DragMoveBehavior : Behavior<Window>
{
    protected override void OnAttached()
    {
        AssociatedObject.MouseMove += AssociatedObject_MouseMove;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
    }

    private static void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed && sender is Window window)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Normal;
                window.Top = 3;
            }

            window.DragMove();
        }
    }
}