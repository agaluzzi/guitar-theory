namespace GuitarTheory;

public class SingleNotePattern : IPattern
{
    public string Name => "Single Note";
    public IReadOnlyList<Interval> Intervals => new[] {Interval.Unison};

    public string Describe(Note root)
    {
        return $"{root.Name} Notes";
    }
}