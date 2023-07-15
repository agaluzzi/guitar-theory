namespace GuitarTheory;

public static class Scales
{
    public static readonly IReadOnlyList<Scale> All = new[]
    {
        new("Major",
            Interval.MajorSecond,
            Interval.MajorThird,
            Interval.PerfectFourth,
            Interval.PerfectFifth,
            Interval.MajorSixth,
            Interval.MajorSeventh),

        new Scale("Minor",
            Interval.MajorSecond,
            Interval.MinorThird,
            Interval.PerfectFourth,
            Interval.PerfectFifth,
            Interval.MinorSixth,
            Interval.MinorSeventh),

        new Scale("Melodic Minor",
            Interval.MajorSecond,
            Interval.MinorThird,
            Interval.PerfectFourth,
            Interval.PerfectFifth,
            Interval.MajorSixth,
            Interval.MajorSeventh),

        new Scale("Harmonic Minor",
            Interval.MajorSecond,
            Interval.MinorThird,
            Interval.PerfectFourth,
            Interval.PerfectFifth,
            Interval.MinorSixth,
            Interval.MajorSeventh),

        new Scale("Pentatonic Major",
            Interval.MajorSecond,
            Interval.MajorThird,
            Interval.PerfectFifth,
            Interval.MajorSixth),

        new Scale("Pentatonic Minor",
            Interval.MinorThird,
            Interval.PerfectFourth,
            Interval.PerfectFifth,
            Interval.MinorSeventh),

        new Scale("Blues",
            Interval.MinorThird,
            Interval.PerfectFourth,
            Interval.DiminishedFifth,
            Interval.PerfectFifth,
            Interval.MinorSeventh),
    };
}