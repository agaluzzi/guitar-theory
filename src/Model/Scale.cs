namespace GuitarTheory;

public class Scale : IPattern
{
    public string Name { get; }
    public IReadOnlyList<Interval> Intervals { get; }

    public Scale(string name, params Interval[] intervals)
    {
        Name = name;
        Intervals = intervals;
    }
}