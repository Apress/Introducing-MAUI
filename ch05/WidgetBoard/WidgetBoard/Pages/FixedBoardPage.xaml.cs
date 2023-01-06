using WidgetBoard.ViewModels;

namespace WidgetBoard.Pages;

public partial class FixedBoardPage : ContentPage
{
    public FixedBoardPage(FixedBoardPageViewModel fixedBoardPageViewModel)
    {
        InitializeComponent();

        BindingContext = fixedBoardPageViewModel;
    }
}