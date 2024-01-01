namespace SullyTech.Wpf.Notifications.Toast.Infrastructure.Configurations.ToastNotification.Models.SubModels.Color;

public sealed class ColorConfiguration
{
    public SubModels.Color Error { get; init; } = new() { Background = "#FFFFFF", Foreground = "#B00020" };

    public SubModels.Color Success { get; init; } = new() { Background = "#FFFFFF", Foreground = "#1E88E5" };

    public SubModels.Color Warning { get; init; } = new() { Background = "#FFFFFF", Foreground = "#4CAF50" };

    public SubModels.Color Information { get; init; } = new() { Background = "#FFFFFF", Foreground = "#EDBA00" };
}