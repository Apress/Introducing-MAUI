using WidgetBoard.Models;

namespace WidgetBoard.Data;

public interface IBoardRepository
{
    void CreateBoard(Board board);

    void CreateBoardWidget(BoardWidget boardWidget);

    void DeleteBoard(Board board);

    IReadOnlyList<Board> ListBoards();

    Board LoadBoard(int boardId);

    void UpdateBoard(Board board);
}
