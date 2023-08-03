using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace SullyTech.Wpf.Controls.Window.Core.Behaviors.DragMove;

public sealed class DragMoveBehavior : Behavior<Window>
{
    protected override void OnAttached()
    {
        AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
    }

    private static void AssociatedObject_MouseLeftButtonDown(object sender, MouseEventArgs e)
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