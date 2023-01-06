namespace WidgetBoard.Layouts;

public interface ILayoutManager
{
    object BindingContext { get; set; }

    BoardLayout Board { get; set; }

    void SetPosition(BindableObject bindableObject, int position);
}
