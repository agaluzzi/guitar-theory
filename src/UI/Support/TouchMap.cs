namespace GuitarTheory.UI.Support;

public class TouchMap<T> where T : class
{
    private readonly List<(RectF Boundary, T Value)> boundaries = new();

    public void Add(RectF boundary, T value)
    {
        boundaries.Add((boundary, value));
    }

    public void Clear()
    {
        boundaries.Clear();
    }

    public T? GetValueAt(PointF point)
    {
        foreach (var (boundary, value) in boundaries)
        {
            if (boundary.Contains(point))
            {
                return value;
            }
        }
        return null;
    }
}