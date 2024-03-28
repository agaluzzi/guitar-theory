namespace GuitarTheory;

public static class Scales
{
    public static IReadOnlyList<Scale> GetAll() => typeof(Scales).GetPublicStaticFields<Scale>().ToArray();

    public static readonly Scale Major = new("Major",
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh);

    public static readonly Scale Minor = new("Minor",
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MinorSeventh);

    public static readonly Scale MelodicMinor = new("Melodic Minor",
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MajorSixth,
        Interval.MajorSeventh);

    public static readonly Scale HarmonicMinor = new("Harmonic Minor",
        Interval.MajorSecond,
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSixth,
        Interval.MajorSeventh);

    public static readonly Scale PentatonicMajor = new("Pentatonic Major",
        Interval.MajorSecond,
        Interval.MajorThird,
        Interval.PerfectFifth,
        Interval.MajorSixth);

    public static readonly Scale PentatonicMinor = new("Pentatonic Minor",
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.PerfectFifth,
        Interval.MinorSeventh);

    public static readonly Scale Blues = new("Blues",
        Interval.MinorThird,
        Interval.PerfectFourth,
        Interval.DiminishedFifth,
        Interval.PerfectFifth,
        Interval.MinorSeventh);
}