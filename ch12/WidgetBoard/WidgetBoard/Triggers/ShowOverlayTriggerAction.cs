namespace WidgetBoard.Triggers;

public class ShowOverlayTriggerAction : TriggerAction<VisualElement>
{
    public bool ShowOverlay { get; set; }

    protected async override void Invoke(VisualElement sender)
    {
        if (ShowOverlay)
        {
            sender.Scale = 0;
            sender.IsVisible = true;
            sender.Opacity = 0;

            await Task.WhenAll(
                sender.FadeTo(1),
                sender.ScaleTo(1, 500, Easing.SpringOut));
        }
        else
        {
            await sender.ScaleTo(0, 500, Easing.SpringIn);

            sender.Opacity = 0;

            sender.IsVisible = false;
        }
    }

}

