using WidgetBoard.ViewModels;

namespace WidgetBoard;

public class WidgetTemplateSelector : DataTemplateSelector
{
    private readonly WidgetFactory widgetFactory;

    public WidgetTemplateSelector(WidgetFactory widgetFactory)
    {
        this.widgetFactory = widgetFactory;
    }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item is IWidgetViewModel widgetViewModel)
        {
            return new DataTemplate(() => widgetFactory.CreateWidget(widgetViewModel));
        }

        return null;
    }
}
