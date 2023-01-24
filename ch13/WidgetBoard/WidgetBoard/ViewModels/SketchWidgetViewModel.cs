namespace WidgetBoard.ViewModels;

public class SketchWidgetViewModel : IWidgetViewModel
{
    public const string DisplayName = "Sketch";

    public int Position { get; set; }

    public string Type => DisplayName;

    public Task InitializeAsync() => Task.CompletedTask;
}
