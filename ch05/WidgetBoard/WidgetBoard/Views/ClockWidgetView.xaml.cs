using WidgetBoard.ViewModels;

namespace WidgetBoard.Views;

public partial class ClockWidgetView : Label, IWidgetView
{
    public ClockWidgetView()
    {
        InitializeComponent();

        WidgetViewModel = new ClockWidgetViewModel();
        BindingContext = WidgetViewModel;
    }

    public IWidgetViewModel WidgetViewModel { get; set; }
}
