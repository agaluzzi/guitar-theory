namespace GuitarTheory;

public static class PaintFactory
{
    public static LinearGradientPaint HorizontalGradient(params (string Color, double Offset)[] stops)
    {
        return LinearGradient(from: (0, 0), to: (1, 0), stops);
    }

    public static LinearGradientPaint VerticalGradient(params (string Color, double Offset)[] stops)
    {
        return LinearGradient(from: (0, 0), to: (0, 1), stops);
    }

    public static LinearGradientPaint LinearGradient(
        (double X, double Y) from,
        (double X, double Y) to,
        params (string Color, double Offset)[] stops)
    {
        return new LinearGradientPaint(
            stops.Select(s => new PaintGradientStop((float) s.Offset, Color.FromArgb(s.Color))).ToArray(),
            startPoint: new Point(from.X, from.Y),
            endPoint: new Point(to.X, to.Y));
    }
}