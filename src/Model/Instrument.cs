using System.Collections.Immutable;

namespace GuitarTheory;

public class Instrument
{
    public string Name { get; }

    public IEnumerable<FingerPosition> FingerPositions =>
        from str in Strings
        from fret in Frets
        select new FingerPosition(str, fret);

    public IReadOnlyList<InstrumentString> Strings { get; }
    public IReadOnlyList<Fret> Frets { get; }

    public Instrument(string name, int frets, params InstrumentString[] strings)
    {
        Name = name;
        Strings = strings;

        Frets = Enumerable.Range(start: 0, count: frets + 1) // extra "fret" (0) for open string
            .Select(f => new Fret(f))
            .ToImmutableArray();
    }

    public override string ToString()
    {
        return Name;
    }
}