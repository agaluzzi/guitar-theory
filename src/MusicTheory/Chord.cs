namespace GuitarTheory;

public class Chord : IPattern
{
    public string Name { get; }
    public IReadOnlyList<Interval> Intervals { get; }

    public Chord(string name, params Interval[] intervals)
    {
        Name = name;
        Intervals = intervals;
    }

    public string Describe(Note root)
    {
        return $"{root} {Name} Chord";
    }
}