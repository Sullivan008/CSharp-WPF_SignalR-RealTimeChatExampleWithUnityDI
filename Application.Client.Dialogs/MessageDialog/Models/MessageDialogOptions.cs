using System.Windows;
using Application.Utilities.Guard;

namespace Application.Client.Dialogs.MessageDialog.Models
{
    public class MessageDialogOptions
    {
        public MessageBoxImage? Icon { get; init; }

        private readonly MessageBoxButton? _button;
        public MessageBoxButton Button
        {
            get
            {
                Guard.ThrowIfNull(_button, nameof(Button));

                return _button!.Value;
            }

            init => _button = value;
        }
        
        private readonly string? _title;
        public string Title
        {
            get
            {
                Guard.ThrowIfNullOrWhitespace(_title, nameof(Title));

                return _title!;
            }

            init => _title = value;
        }

        private readonly string? _content;
        public string Content
        {
            get
            {
                Guard.ThrowIfNullOrWhitespace(_content, nameof(Content));

                return _content!;
            }
            
            init => _content = value;
        }
    }
}
