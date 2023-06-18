using System.Collections.Immutable;

namespace GuitarTheory;

public class Guitar
{
    public IEnumerable<FingerPosition> FingerPositions =>
        from str in Strings
        from fret in Frets
        select new FingerPosition(str, fret);

    public IReadOnlyList<GuitarString> Strings { get; }
    public IReadOnlyList<Fret> Frets { get; }

    public Guitar(int frets)
    {
        Strings = new[]
        {
            new GuitarString(1, Note.E),
            new GuitarString(2, Note.B),
            new GuitarString(3, Note.G),
            new GuitarString(4, Note.D),
            new GuitarString(5, Note.A),
            new GuitarString(6, Note.E),
        };

        Frets = Enumerable.Range(start: 0, count: frets + 1)
            .Select(f => new Fret(f))
            .ToImmutableArray();
    }
}