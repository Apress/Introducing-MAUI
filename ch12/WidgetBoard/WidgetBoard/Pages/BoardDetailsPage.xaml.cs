using WidgetBoard.ViewModels;

namespace WidgetBoard.Pages;

public partial class BoardDetailsPage : ContentPage
{
    public BoardDetailsPage(BoardDetailsPageViewModel boardDetailsPageViewModel)
    {
        InitializeComponent();

        BindingContext = boardDetailsPageViewModel;
    }

}