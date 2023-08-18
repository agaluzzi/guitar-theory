namespace GuitarTheory;

public record Interval
{
    public static readonly Interval Unison =
        new("Unison", IntervalType.Perfect, degree: 1, semitones: 0);

    public static readonly Interval MinorSecond =
        new("Minor 2nd", type: IntervalType.Minor, degree: 2, semitones: 1);

    public static readonly Interval MajorSecond =
        new("Major 2nd", type: IntervalType.Major, degree: 2, semitones: 2);

    public static readonly Interval MinorThird =
        new("Minor 3rd", IntervalType.Minor, degree: 3, semitones: 3);

    public static readonly Interval MajorThird =
        new("Major 3rd", IntervalType.Major, degree: 3, semitones: 4);

    public static readonly Interval DiminishedFourth =
        new("Diminished 4th", IntervalType.Diminished, degree: 4, semitones: 4);

    public static readonly Interval PerfectFourth =
        new("Perfect 4th", IntervalType.Perfect, degree: 4, semitones: 5);

    public static readonly Interval AugmentedFourth =
        new("Augmented 4th", IntervalType.Augmented, degree: 4, semitones: 6);

    public static readonly Interval DiminishedFifth =
        new("Diminished 5th", IntervalType.Diminished, degree: 5, semitones: 6);

    public static readonly Interval PerfectFifth =
        new("Perfect 5th", IntervalType.Perfect, degree: 5, semitones: 7);

    public static readonly Interval AugmentedFifth =
        new("Augmented 5th", IntervalType.Augmented, degree: 5, semitones: 8);

    public static readonly Interval MinorSixth =
        new("Minor 6th", IntervalType.Minor, degree: 6, semitones: 8);

    public static readonly Interval MajorSixth =
        new("Major 6th", IntervalType.Major, degree: 6, semitones: 9);

    public static readonly Interval MinorSeventh =
        new("Minor 7th", IntervalType.Minor, degree: 7, semitones: 10);

    public static readonly Interval MajorSeventh =
        new("Major 7th", IntervalType.Major, degree: 7, semitones: 11);

    public static readonly Interval Octave =
        new("Octave", IntervalType.Perfect, degree: 8, semitones: 12);

    public string Name { get; }
    public int Degree { get; }
    public int Semitones { get; }
    public IntervalType Type { get; }
    public bool IsLowered => Type is IntervalType.Minor or IntervalType.Diminished;
    public bool IsRaised => Type is IntervalType.Augmented;
    public bool IsRoot => Semitones == 0;

    public string Abbreviation
    {
        get
        {
            var prefix = Type switch
            {
                IntervalType.Perfect => "P",
                IntervalType.Minor => "m",
                IntervalType.Major => "M",
                IntervalType.Diminished => "d",
                IntervalType.Augmented => "A",
                _ => throw new ArgumentException($"Unexpected interval type: {Type}")
            };

            return $"{prefix}{Degree}";
        }
    }

    private Interval(string name, IntervalType type, int degree, int semitones)
    {
        Name = name;
        Degree = degree;
        Semitones = semitones;
        Type = type;
    }
}