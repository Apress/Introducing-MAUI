namespace WidgetBoard.Controls;

public class Placeholder : Border
{
    public Placeholder()
    {
        Content = new Label
        {
            Text = "Tap to add widget",
            FontAttributes = FontAttributes.Italic,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
    }

    public int Position { get; set; }
}
