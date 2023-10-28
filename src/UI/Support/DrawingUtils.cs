using GuitarTheory.Extensions;

namespace GuitarTheory.UI.Support;

public static class DrawingUtils
{
    public static void DrawNote(
        Note note,
        Interval? interval,
        PointF center,
        float radius,
        ICanvas canvas,
        NoteOptions options)
    {
        Color color;
        if (options.HasFlag(NoteOptions.GrayedOut))
        {
            color = Colors.Gray;
            canvas.Alpha = 0.4f;
        }
        else
        {
            color = ColorScheme.GetColor(note);
        }
        canvas.FillCircle(center, radius, color.AsPaint());

        canvas.StrokeColor = Colors.White;
        canvas.StrokeSize = radius * (options.HasFlag(NoteOptions.Emphasized) ? 0.2f : 0.1f);
        canvas.DrawCircle(center, radius);

        var text = note.Name;
        var textSize = radius * 1.2f;

        if (options.HasFlag(NoteOptions.IntervalLabel) && interval?.Degree > 1)
        {
            text = interval.Abbreviation;
            textSize = radius * 0.8f;
        }

        var textOffsetX = text.EndsWith("♭") || text.EndsWith("♯") ? 2 : 0;
        const float textOffsetY = 4;

        canvas.DrawString(text,
            bounds: new RectF(
                x: center.X - radius + textOffsetX,
                y: center.Y - radius + textOffsetY,
                width: (radius * 2) - textOffsetX,
                height: (radius * 2) - textOffsetY),
            size: textSize,
            color: color.GetContrastingColor(),
            weight: FontWeights.Bold);

        canvas.Alpha = 1;

        if (options.HasFlag(NoteOptions.UpDownArrow) && interval != null)
        {
            var width = radius * 0.6f;
            var height = radius * 0.4f;
            var y = center.Y;
            canvas.FillColor = Colors.White.WithAlpha(0.75f);
            if (interval.IsLowered)
            {
                var x = center.X + (radius * 1.2f);
                canvas.FillPath(new PathF(x, y)
                    .LineTo(x + width, y - height)
                    .LineTo(x + width, y + height));
            }
            else if (interval.IsRaised)
            {
                var x = center.X - (radius * 1.2f);
                canvas.FillPath(new PathF(x, y)
                    .LineTo(x - width, y - height)
                    .LineTo(x - width, y + height));
            }
        }
    }
}