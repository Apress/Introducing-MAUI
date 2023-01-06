using WidgetBoard.ViewModels;

namespace WidgetBoard;

public partial class AppShell : Shell
{
    public AppShell(AppShellViewModel appShellViewModel)
    {
        InitializeComponent();

        BindingContext = appShellViewModel;
    }
}
