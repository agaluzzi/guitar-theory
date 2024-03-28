namespace GuitarTheory;

public static class Chords
{
    public static IReadOnlyList<Chord> GetAll() =>
        typeof(Chords).GetPublicStaticFields<Chord>().ToArray();

    public static readonly Chord Major = new("Major",
        Interval.MajorThird,
        Interval.PerfectFifth);

    public static readonly Chord Minor = new("Minor",
        Interval.MinorThird,
        Interval.PerfectFifth);

    public static readonly Chord Dominant7th = new("7",
        Interval.MajorThird,
        Interval.PerfectFifth,
        Interval.MinorSeventh);

    public static readonly Chord Major7th = new("maj7",
        Interval.MajorThird,
        Interval.PerfectFifth,
        Interval.MajorSeventh);

    public static readonly Chord Minor7th = new("min7",
        Interval.MinorThird,
        Interval.PerfectFifth,
        Interval.MinorSeventh);

    public static readonly Chord Diminished = new("Diminished",
        Interval.MinorThird,
        Interval.DiminishedFifth);

    public static readonly Chord Augmented = new("Augmented",
        Interval.MajorThird,
        Interval.AugmentedFifth);

    public static readonly Chord Suspended4th = new("sus4",
        Interval.PerfectFourth,
        Interval.PerfectFifth);

    public static readonly Chord Suspended2nd = new("sus2",
        Interval.MajorSecond,
        Interval.PerfectFifth);
}