using WidgetBoard.ViewModels;

namespace WidgetBoard;

public partial class AppShell : Shell
{
    public AppShell(
        AppShellViewModel appShellViewModel)
    {
        InitializeComponent();

        BindingContext = appShellViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ((AppShellViewModel)BindingContext).LoadBoards();
    }
}

