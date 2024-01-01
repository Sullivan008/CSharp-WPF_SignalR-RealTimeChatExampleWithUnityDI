namespace SullyTech.Wpf.Controls.Window.Core.ViewModels.Window.Initializers.Models;

public record WindowViewModelInitializerModel
{
    public string? Title { get; init; }

    public double? Height { get; init; }

    public double? Width { get; init; }

    public double? Top { get; init; }

    public double? Bottom { get; init; }

    public double? Left { get; init; }

    public double? Right { get; init; }
}