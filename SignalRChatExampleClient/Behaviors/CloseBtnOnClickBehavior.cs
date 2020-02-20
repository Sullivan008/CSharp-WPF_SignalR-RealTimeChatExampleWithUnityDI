using System.Windows;
using System.Windows.Controls;

namespace SignalRChatExampleClient.Behaviors
{
    public static class CloseBtnOnClickBehaviour
    {
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached(
                "IsEnabled",
                typeof(bool),
                typeof(CloseBtnOnClickBehaviour),
                new PropertyMetadata(false, OnIsEnabledPropertyChanged)
            );

        public static bool GetIsEnabled(DependencyObject obj)
        {
            object val = obj.GetValue(IsEnabledProperty);

            return (bool)val;
        }

        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }

        static void OnIsEnabledPropertyChanged(DependencyObject dpo, DependencyPropertyChangedEventArgs args)
        {
            Button button = dpo as Button;

            if (button == null)
                return;

            bool oldValue = (bool)args.OldValue;
            bool newValue = (bool)args.NewValue;

            if (!oldValue && newValue)
            {
                button.Click += OnClick;
            }
            else if (oldValue && !newValue)
            {
                button.PreviewMouseLeftButtonDown -= OnClick;
            }
        }

        static void OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button == null)
                return;

            Window window = Window.GetWindow(button);

            if (window == null)
                return;

            window.Close();
        }

    }
}