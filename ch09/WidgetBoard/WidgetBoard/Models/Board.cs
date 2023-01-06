using SQLite;

namespace WidgetBoard.Models;

public class Board
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Name { get; init; }

    public int NumberOfColumns { get; init; }

    public int NumberOfRows { get; init; }

    public IList<BoardWidget> BoardWidgets { get; set; }
}
