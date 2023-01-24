using WidgetBoard.ViewModels;

namespace WidgetBoard.Views;

public partial class ClockWidgetView : Label, IWidgetView
{
    public ClockWidgetView(ClockWidgetViewModel clockWidgetViewModel)
    {
        InitializeComponent();

        WidgetViewModel = clockWidgetViewModel;
        BindingContext = clockWidgetViewModel;
    }

    public IWidgetViewModel WidgetViewModel { get; set; }
}
