using System.Collections;
using WidgetBoard.Controls;
using WidgetBoard.Views;

namespace WidgetBoard.Layouts;

public partial class BoardLayout
{
    public BoardLayout()
    {
        InitializeComponent();
    }

    private ILayoutManager layoutManager;

    public ILayoutManager LayoutManager
    {
        get => layoutManager;
        set
        {
            layoutManager = value;
            layoutManager.Board = this;
        }
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        layoutManager.BindingContext = this.BindingContext;
    }

    public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IEnumerable),
            typeof(BoardLayout));

    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly BindableProperty ItemTemplateSelectorProperty =
        BindableProperty.Create(
            nameof(ItemTemplateSelector),
            typeof(DataTemplateSelector),
            typeof(BoardLayout));

    public DataTemplateSelector ItemTemplateSelector
    {
        get => (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty);
        set => SetValue(ItemTemplateSelectorProperty, value);
    }

    private void Widgets_ChildAdded(object sender, ElementEventArgs e)
    {
        if (e.Element is IWidgetView widgetView)
        {
            LayoutManager.SetPosition(e.Element, widgetView.Position);
        }
    }

    public void AddPlaceholder(Placeholder placeholder) => PlaceholderGrid.Children.Add(placeholder);

    public void RemovePlaceholder(Placeholder placeholder) => PlaceholderGrid.Children.Remove(placeholder);

    public void AddColumn(ColumnDefinition columnDefinition)
    {
        PlaceholderGrid.ColumnDefinitions.Add(columnDefinition);
        WidgetGrid.ColumnDefinitions.Add(columnDefinition);
    }

    public void AddRow(RowDefinition rowDefinition)
    {
        PlaceholderGrid.RowDefinitions.Add(rowDefinition);
        WidgetGrid.RowDefinitions.Add(rowDefinition);
    }

    public IReadOnlyList<Placeholder> Placeholders => PlaceholderGrid.Children.OfType<Placeholder>().ToList();
}
