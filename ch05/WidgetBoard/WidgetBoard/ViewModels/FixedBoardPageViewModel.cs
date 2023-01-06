using WidgetBoard.Models;

namespace WidgetBoard.ViewModels;

public class FixedBoardPageViewModel : BaseViewModel, IQueryAttributable
{
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var board = query["Board"] as Board;
    }
}
