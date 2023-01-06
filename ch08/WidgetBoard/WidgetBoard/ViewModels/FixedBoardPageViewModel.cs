using System.Collections.ObjectModel;
using System.Windows.Input;
using WidgetBoard.Models;

namespace WidgetBoard.ViewModels;

public class FixedBoardPageViewModel : BaseViewModel, IQueryAttributable
{
    private string boardName;
    private int numberOfColumns;
    private int numberOfRows;

    private int addingPosition;
    private string selectedWidget;
    private bool isAddingWidget;
    private readonly WidgetFactory widgetFactory;

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


    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var board = query["Board"] as Board;

        BoardName = board.Name;
        NumberOfColumns = ((FixedLayout)board.Layout).NumberOfColumns;
        NumberOfRows = ((FixedLayout)board.Layout).NumberOfRows;

    }

    public FixedBoardPageViewModel(
        WidgetTemplateSelector widgetTemplateSelector,
        WidgetFactory widgetFactory)
    {
        WidgetTemplateSelector = widgetTemplateSelector;
        this.widgetFactory = widgetFactory;

        Widgets = new ObservableCollection<IWidgetViewModel>();

        AddWidgetCommand = new Command(OnAddWidget);

        AddNewWidgetCommand = new Command<int>(index =>
        {
            IsAddingWidget = true;
            addingPosition = index;
        });
    }

    private void OnAddWidget()
    {
        if (SelectedWidget is null)
        {
            return;
        }

        var widgetViewModel = widgetFactory.CreateWidgetViewModel(SelectedWidget);

        widgetViewModel.Position = addingPosition;

        Widgets.Add(widgetViewModel);

        IsAddingWidget = false;
    }
}
