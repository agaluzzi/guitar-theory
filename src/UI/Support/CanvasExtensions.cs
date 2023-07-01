using Font = Microsoft.Maui.Graphics.Font;

namespace GuitarTheory.Extensions;

public static class CanvasExtensions
{
    public static void FillRectangle(this ICanvas canvas, float x, float y, float width, float height, Paint paint)
    {
        var bounds = new RectF(x, y, width, height);
        FillRectangle(canvas, bounds, paint);
    }

    public static void FillRectangle(this ICanvas canvas, RectF bounds, Paint paint)
    {
        canvas.SetFillPaint(paint, bounds);
        canvas.FillRectangle(bounds);
    }

    public static void FillCircle(this ICanvas canvas, float centerX, float centerY, float radius, Paint paint)
    {
        var diameter = radius * 2;
        var bounds = new RectF(centerX - radius, centerY - radius, diameter, diameter);
        canvas.SetFillPaint(paint, bounds);
        canvas.FillCircle(centerX: centerX, centerY: centerY, radius: radius);
    }

    public static void FillCircle(this ICanvas canvas, PointF center, float radius, Paint paint)
    {
        FillCircle(canvas, center.X, center.Y, radius, paint);
    }

    public static void ClearShadow(this ICanvas canvas)
    {
        canvas.SetShadow(offset: SizeF.Zero, blur: 0f, Colors.Transparent);
    }

    public static void DrawString(
        this ICanvas canvas,
        string value,
        RectF bounds,
        float size,
        Color color,
        FontStyleType style = FontStyleType.Normal,
        int weight = FontWeights.Normal,
        HorizontalAlignment horizontal = HorizontalAlignment.Center,
        VerticalAlignment vertical = VerticalAlignment.Center)
    {
        canvas.Font = new Font(name: null, weight: weight, styleType: style);
        canvas.FontSize = size;
        canvas.FontColor = color;
        canvas.DrawString(value, bounds, horizontal, vertical);
    }
}