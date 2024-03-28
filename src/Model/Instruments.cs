namespace GuitarTheory;

public static class Instruments
{
    public static IReadOnlyList<Instrument> GetAll() =>
        typeof(Instruments).GetPublicStaticFields<Instrument>().ToArray();

    public static readonly Instrument Guitar = new("Guitar",
        frets: 12,
        new InstrumentString(1, Note.E),
        new InstrumentString(2, Note.B),
        new InstrumentString(3, Note.G),
        new InstrumentString(4, Note.D),
        new InstrumentString(5, Note.A),
        new InstrumentString(6, Note.E));

    public static readonly Instrument Bass = new("Bass",
        frets: 12,
        new InstrumentString(1, Note.G),
        new InstrumentString(2, Note.D),
        new InstrumentString(3, Note.A),
        new InstrumentString(4, Note.E));

    public static readonly Instrument Ukulele = new("Ukulele",
        frets: 10,
        new InstrumentString(1, Note.A),
        new InstrumentString(2, Note.E),
        new InstrumentString(3, Note.C),
        new InstrumentString(4, Note.G));
}