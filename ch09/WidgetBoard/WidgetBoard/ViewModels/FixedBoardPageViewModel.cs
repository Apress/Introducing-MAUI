using System.Collections.ObjectModel;
using System.Windows.Input;
using WidgetBoard.Data;
using WidgetBoard.Models;
using WidgetBoard.Views;

namespace WidgetBoard.ViewModels;

public class FixedBoardPageViewModel : BaseViewModel, IQueryAttributable
{
    private Board board;
    private string boardName;
    private int numberOfColumns;
    private int numberOfRows;

    private int addingPosition;
    private string selectedWidget;
    private bool isAddingWidget;
    private readonly WidgetFactory widgetFactory;
    private readonly IBoardRepository boardRepository;

    public IList<string> AvailableWidgets => widgetFactory.AvailableWidgets;

    public ICommand AddWidgetCommand { get; }

    public ICommand AddNewWidgetCommand { get; }

    public bool IsAddingWidget
    {
        get => isAddingWidget;
        set => SetProperty(ref isAddingWidget, value);
    }

    public string SelectedWidget
    {
        get => selectedWidget;
        set => SetProperty(ref selectedWidget, value);
    }

    public string BoardName
    {
        get => boardName;
        set => SetProperty(ref boardName, value);
    }

    public int NumberOfColumns
    {
        get => numberOfColumns;
        set => SetProperty(ref numberOfColumns, value);
    }

    public int NumberOfRows
    {
        get => numberOfRows;
        set => SetProperty(ref numberOfRows, value);
    }

    public ObservableCollection<IWidgetViewModel> Widgets { get; }

    public WidgetTemplateSelector WidgetTemplateSelector { get; }

    public FixedBoardPageViewModel(
        WidgetTemplateSelector widgetTemplateSelector,
        WidgetFactory widgetFactory,
        IBoardRepository boardRepository)
    {
        WidgetTemplateSelector = widgetTemplateSelector;
        this.widgetFactory = widgetFactory;
        this.boardRepository = boardRepository;

        Widgets = new ObservableCollection<IWidgetViewModel>();

        AddWidgetCommand = new Command(OnAddWidget);

        AddNewWidgetCommand = new Command<int>(index =>
        {
            IsAddingWidget = true;
            addingPosition = index;
        });
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var boardParameter = query["Board"] as Board;

        board = boardRepository.LoadBoard(boardParameter.Id);

        BoardName = board.Name;
        NumberOfColumns = board.NumberOfColumns;
        NumberOfRows = board.NumberOfRows;

        // Set widgets
        foreach (var boardWidget in board.BoardWidgets)
        {
            CreateAndAddWidget(boardWidget.WidgetType, boardWidget.Position);
        }
    }

    private void OnAddWidget()
    {
        if (SelectedWidget is null)
        {
            return;
        }

        IWidgetViewModel widgetViewModel = CreateAndAddWidget(SelectedWidget, addingPosition);

        SaveWidget(widgetViewModel);

        IsAddingWidget = false;
    }

    private IWidgetViewModel CreateAndAddWidget(string widgetType, int position)
    {
        var widgetViewModel = widgetFactory.CreateWidgetViewModel(widgetType);

        widgetViewModel.Position = position;

        Widgets.Add(widgetViewModel);
        return widgetViewModel;
    }

    private void SaveWidget(IWidgetViewModel widgetViewModel)
    {
        var boardWidget = new BoardWidget
        {
            BoardId = board.Id,
            Position = widgetViewModel.Position,
            WidgetType = widgetViewModel.Type
        };

        boardRepository.CreateBoardWidget(boardWidget);
    }
}
