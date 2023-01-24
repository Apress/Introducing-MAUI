using SQLite;

namespace WidgetBoard.Models;

public class BoardWidget
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int BoardId { get; set; }

    public int Position { get; set; }

    public string WidgetType { get; set; }
}
