using System.Collections.ObjectModel;
using WidgetBoard.Models;

namespace WidgetBoard.ViewModels;

public class AppShellViewModel : BaseViewModel
{
    private Board currentBoard;

    public Board CurrentBoard
    {
        get => currentBoard;
        set
        {
            if (SetProperty(ref currentBoard, value))
            {
                BoardSelected(value);
            }
        }
    }

    public AppShellViewModel()
    {
        Boards.Add(
            new Board
            {
                Name = "My first board",
                Layout = new FixedLayout
                {
                    NumberOfColumns = 3,
                    NumberOfRows = 2
                }
            });
    }

    public ObservableCollection<Board> Boards { get; } = new ObservableCollection<Board>();

    private async void BoardSelected(Board board)
    {
        await Shell.Current.GoToAsync(
            "fixedboard",
            new Dictionary<string, object>
            {
            { "Board", board}
            });
    }

}
