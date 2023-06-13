namespace GuitarTheory.UI.Support;

public class Interpolation
{
    private readonly double x1, y1, x2, y2;

    public Interpolation((double X, double Y) from, (double X, double Y) to)
    {
        x1 = from.X;
        y1 = from.Y;
        x2 = to.X;
        y2 = to.Y;
    }

    public double GetY(double x)
    {
        return y1 + (x - x1) * ((y2 - y1) / (x2 - x1));
    }
}