namespace GuitarTheory;

public record Interval
{
    public static readonly Interval Unison =
        new("Unison", IntervalType.Perfect, degree: 1, halfSteps: 0);

    public static readonly Interval MinorSecond =
        new("Minor 2nd", type: IntervalType.Minor, degree: 2, halfSteps: 1);

    public static readonly Interval MajorSecond =
        new("Major 2nd", type: IntervalType.Major, degree: 2, halfSteps: 2);

    public static readonly Interval MinorThird =
        new("Minor 3rd", IntervalType.Minor, degree: 3, halfSteps: 3);

    public static readonly Interval MajorThird =
        new("Major 3rd", IntervalType.Major, degree: 3, halfSteps: 4);

    public static readonly Interval DiminishedFourth =
        new("Diminished 4th", IntervalType.Diminished, degree: 4, halfSteps: 4);

    public static readonly Interval PerfectFourth =
        new("Perfect 4th", IntervalType.Perfect, degree: 4, halfSteps: 5);

    public static readonly Interval AugmentedFourth =
        new("Augmented 4th", IntervalType.Augmented, degree: 4, halfSteps: 6);

    public static readonly Interval DiminishedFifth =
        new("Diminished 5th", IntervalType.Diminished, degree: 5, halfSteps: 6);

    public static readonly Interval PerfectFifth =
        new("Perfect 5th", IntervalType.Perfect, degree: 5, halfSteps: 7);

    public static readonly Interval AugmentedFifth =
        new("Augmented 5th", IntervalType.Augmented, degree: 5, halfSteps: 8);

    public static readonly Interval MinorSixth =
        new("Minor 6th", IntervalType.Minor, degree: 6, halfSteps: 8);

    public static readonly Interval MajorSixth =
        new("Major 6th", IntervalType.Major, degree: 6, halfSteps: 9);

    public static readonly Interval MinorSeventh =
        new("Minor 7th", IntervalType.Minor, degree: 7, halfSteps: 10);

    public static readonly Interval MajorSeventh =
        new("Major 7th", IntervalType.Major, degree: 7, halfSteps: 11);

    public static readonly Interval Octave =
        new("Octave", IntervalType.Perfect, degree: 8, halfSteps: 12);

    public string Name { get; }
    public string Abbreviation { get; }
    public int Degree { get; }
    public int HalfSteps { get; }
    public IntervalType Type { get; }
    public bool IsLowered => Type is IntervalType.Minor or IntervalType.Diminished;
    public bool IsRaised => Type is IntervalType.Augmented;

    private Interval(string name, IntervalType type, int degree, int halfSteps)
    {
        Name = name;
        Abbreviation = GetAbbreviation(type, Degree);
        Degree = degree;
        HalfSteps = halfSteps;
        Type = type;
    }

    private static string GetAbbreviation(IntervalType type, int degree)
    {
        var prefix = type switch
        {
            IntervalType.Perfect => "P",
            IntervalType.Minor => "m",
            IntervalType.Major => "M",
            IntervalType.Diminished => "d",
            IntervalType.Augmented => "A",
            _ => throw new ArgumentException($"Unexpected interval type: {type}")
        };

        return $"{prefix}{degree}";
    }
}