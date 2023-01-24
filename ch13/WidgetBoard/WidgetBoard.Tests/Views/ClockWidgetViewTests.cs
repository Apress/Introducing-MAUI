using WidgetBoard.Tests.Mocks;
using WidgetBoard.Views;

namespace WidgetBoard.Tests.Views;

public class ClockWidgetViewTests
{
    [Fact]
    public void TextIsUpdatedByTimeProperty()
    {
        var time = new DateTime(2022, 01, 01);

        var clockWidget = new ClockWidgetView();

        Assert.Null(clockWidget.Text);

        clockWidget.WidgetViewModel = new MockClockWidgetViewModel(time);

        Assert.Equal(time.ToString(), clockWidget.Text);
    }
}
