using SullyTech.Wpf.Notifications.Toast.Configuration.Models.SubModels.Color.SubModels;

namespace SullyTech.Wpf.Notifications.Toast.Configuration.Models.SubModels.Color;

public sealed class ColorConfiguration
{
    public ErrorColor ErrorColor { get; init; } = new();

    public SuccessColor SuccessColor { get; init; } = new();

    public WarningColor WarningColor { get; init; } = new();

    public InformationColor InformationColor { get; init; } = new();
}