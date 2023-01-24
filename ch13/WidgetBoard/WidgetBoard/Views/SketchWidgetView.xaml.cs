using Microsoft.Maui.Controls;
using WidgetBoard.ViewModels;

namespace WidgetBoard.Views;

public partial class SketchWidgetView : GraphicsView, IWidgetView, IDrawable
{
    private DrawingPath currentPath;
    private readonly IList<DrawingPath> paths = new List<DrawingPath>();

    public SketchWidgetView()
	{
		InitializeComponent();
        this.Drawable = this;
	}

    public IWidgetViewModel WidgetViewModel
    {
        get => BindingContext as IWidgetViewModel;
        set => BindingContext = value;
    }

    void GraphicsView_StartInteraction(object sender, TouchEventArgs e)
    {
        currentPath = new DrawingPath(Colors.Black, 2);
        currentPath.Add(e.Touches.First());
        paths.Add(currentPath);

        Invalidate();
    }

    void GraphicsView_DragInteraction(object sender, TouchEventArgs e)
    {
        currentPath.Add(e.Touches.First());

        Invalidate();
    }

    void GraphicsView_EndInteraction(object sender, TouchEventArgs e)
    {
        currentPath.Add(e.Touches.First());

        Invalidate();
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        foreach (var path in paths)
        {
            canvas.StrokeColor = path.Color;
            canvas.StrokeSize = path.Thickness;
            canvas.StrokeLineCap = LineCap.Round;
            canvas.DrawPath(path.Path);
        }
    }
}
