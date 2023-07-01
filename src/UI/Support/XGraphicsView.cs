namespace GuitarTheory.UI.Support;

public abstract class XGraphicsView : GraphicsView, IDrawable
{
    protected readonly ILogger Logger;

    protected XGraphicsView()
    {
        Logger = Log.ForContext(GetType());
        Drawable = this;
    }

    public void Draw(ICanvas canvas, RectF bounds)
    {
        try
        {
            Draw(canvas,
                top: bounds.Top,
                bottom: bounds.Bottom,
                left: bounds.Left,
                right: bounds.Right,
                width: bounds.Width,
                height: bounds.Height,
                center: bounds.Center,
                bounds: bounds);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Drawing error");
        }
    }

    protected abstract void Draw(
        ICanvas canvas,
        float top,
        float bottom,
        float left,
        float right,
        float width,
        float height,
        PointF center,
        RectF bounds);
}