namespace GuitarTheory;

public static class Instruments
{
    public static Instrument Default => All[0];

    public static readonly IReadOnlyList<Instrument> All = new[]
    {
        new Instrument("Guitar",
            frets: 12,
            new InstrumentString(1, Note.E),
            new InstrumentString(2, Note.B),
            new InstrumentString(3, Note.G),
            new InstrumentString(4, Note.D),
            new InstrumentString(5, Note.A),
            new InstrumentString(6, Note.E)),

        new Instrument("Bass",
            frets: 12,
            new InstrumentString(1, Note.G),
            new InstrumentString(2, Note.D),
            new InstrumentString(3, Note.A),
            new InstrumentString(4, Note.E)),

        new Instrument("Ukulele",
            frets: 10,
            new InstrumentString(1, Note.A),
            new InstrumentString(2, Note.E),
            new InstrumentString(3, Note.C),
            new InstrumentString(4, Note.G)),
    };
}