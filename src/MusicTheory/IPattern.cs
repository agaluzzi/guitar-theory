namespace GuitarTheory;

public interface IPattern
{
    string Name { get; }
    IReadOnlyList<Interval> Intervals { get; }

    public IEnumerable<Tone> GetTones(Note root)
    {
        yield return new Tone(root, Interval.Unison);

        foreach (var interval in Intervals)
        {
            yield return new Tone(root + interval, interval);
        }
    }
}