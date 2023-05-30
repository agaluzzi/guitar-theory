namespace GuitarTheory;

public static class Chords
{
    public static Chord Default => All[0];

    public static readonly IReadOnlyList<Chord> All = new[]
    {
        new Chord("Major",
            Interval.MajorThird,
            Interval.PerfectFifth),

        new Chord("Minor",
            Interval.MinorThird,
            Interval.PerfectFifth),

        new Chord("7",
            Interval.MajorThird,
            Interval.PerfectFifth,
            Interval.MinorSeventh),

        new Chord("maj7",
            Interval.MajorThird,
            Interval.PerfectFifth,
            Interval.MajorSeventh),

        new Chord("min7",
            Interval.MinorThird,
            Interval.PerfectFifth,
            Interval.MinorSeventh),

        new Chord("Diminished",
            Interval.MinorThird,
            Interval.DiminishedFifth),

        new Chord("Augmented",
            Interval.MajorThird,
            Interval.AugmentedFifth),

        new Chord("sus4",
            Interval.PerfectFourth,
            Interval.PerfectFifth),

        new Chord("sus2",
            Interval.MajorSecond,
            Interval.PerfectFifth),
    };
}