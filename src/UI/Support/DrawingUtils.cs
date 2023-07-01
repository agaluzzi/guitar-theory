using GuitarTheory.Extensions;

namespace GuitarTheory.UI.Support;

public static class DrawingUtils
{
    public static void DrawNote(Note note, PointF center, float radius, ICanvas canvas)
    {
        var color = ColorScheme.GetColor(note);
        canvas.FillCircle(center, radius, color.AsPaint());

        canvas.StrokeColor = Colors.White;
        canvas.StrokeSize = radius * .1f;
        canvas.DrawCircle(center, radius);

        var textOffsetX = note.Accidental == Accidental.Natural ? 0 : 2;
        const float textOffsetY = 6;

        canvas.DrawString(note.Name,
            bounds: new RectF(
                x: center.X - radius + textOffsetX,
                y: center.Y - radius + textOffsetY,
                width: (radius * 2) - textOffsetX,
                height: (radius * 2) - textOffsetY),
            size: radius * 1.2f,
            color: color.GetContrastingColor(),
            weight: FontWeights.Bold);
    }
}