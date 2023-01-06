using SQLite;
using WidgetBoard.Models;

namespace WidgetBoard.Data;

public class SqliteBoardRepository : IBoardRepository
{
    private readonly SQLiteConnection connection;

    public SqliteBoardRepository(IFileSystem fileSystem)
    {
        var dbPath = Path.Combine(fileSystem.AppDataDirectory, "widgetboard_sqlite.db");

        connection = new SQLiteConnection(dbPath);
        connection.CreateTable<Board>();
        connection.CreateTable<BoardWidget>();
    }

    public void CreateBoard(Board board)
    {
        connection.Insert(board);
    }

    public void CreateBoardWidget(BoardWidget boardWidget)
    {
        connection.Insert(boardWidget);
    }

    public void DeleteBoard(Board board)
    {
        connection.RunInTransaction(() =>
        {
            if (board.BoardWidgets.Any())
            {
                foreach (var boardWidget in board.BoardWidgets)
                {
                    connection.Delete(boardWidget);
                }
            }

            connection.Delete(board);
        });
    }

    public IReadOnlyList<Board> ListBoards()
    {
        return connection.Table<Board>().OrderBy(b => b.Name).ToList();
    }

    public Board LoadBoard(int boardId)
    {
        var board = connection.Find<Board>(boardId);

        if (board is null)
        {
            return null;
        }

        var widgets = connection.Table<BoardWidget>().Where(w => w.BoardId == boardId).ToList();

        board.BoardWidgets = widgets;

        return board;
    }

    public void UpdateBoard(Board board)
    {
        connection.Update(board);
    }
}
