using System.Collections.ObjectModel;
using WidgetBoard.Data;
using WidgetBoard.Models;

namespace WidgetBoard.ViewModels;

public class AppShellViewModel : BaseViewModel
{
    private Board currentBoard;
    private readonly IBoardRepository boardRepository;
    private readonly IPreferences preferences;

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

    public ObservableCollection<Board> Boards { get; } = new ObservableCollection<Board>();

    public AppShellViewModel(
        IBoardRepository boardRepository,
        IPreferences preferences)
    {
        this.boardRepository = boardRepository;
        this.preferences = preferences;
    }

    public void LoadBoards()
    {
        var boards = this.boardRepository.ListBoards();
        var lastUsedBoardId = preferences.Get("LastUsedBoardId", -1);
        Board lastUsedBoard = null;

        foreach (var board in boards)
        {
            Boards.Add(board);

            if (lastUsedBoardId == board.Id)
            {
                lastUsedBoard = board;
            }
        }

        if (lastUsedBoard is not null)
        {
            Dispatcher.GetForCurrentThread().Dispatch(() =>
            {
                BoardSelected(lastUsedBoard);
            });
        }
    }

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
