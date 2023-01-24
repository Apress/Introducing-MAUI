using WidgetBoard.ViewModels;

namespace WidgetBoard.Tests.Mocks;

public class MockClockWidgetViewModel : IWidgetViewModel
{
    public int Position { get; set; }

    public string Type => "Mock";

    public MockClockWidgetViewModel(DateTime time)
    {
        Time = time;
    }

    public DateTime Time { get; }

    public Task InitializeAsync() => Task.CompletedTask;
}
