namespace GuitarTheory;

public record Note : IComparable<Note>
{
    public static readonly Note C = new(0, "C", Accidental.Natural);
    public static readonly Note CSharp = new(1, "C♯", Accidental.Sharp);
    public static readonly Note DFlat = new(1, "D♭", Accidental.Flat);
    public static readonly Note D = new(2, "D", Accidental.Natural);
    public static readonly Note DSharp = new(3, "D♯", Accidental.Sharp);
    public static readonly Note EFlat = new(3, "E♭", Accidental.Flat);
    public static readonly Note E = new(4, "E", Accidental.Natural);
    public static readonly Note F = new(5, "F", Accidental.Natural);
    public static readonly Note FSharp = new(6, "F♯", Accidental.Sharp);
    public static readonly Note GFlat = new(6, "G♭", Accidental.Flat);
    public static readonly Note G = new(7, "G", Accidental.Natural);
    public static readonly Note GSharp = new(8, "G♯", Accidental.Sharp);
    public static readonly Note AFlat = new(8, "A♭", Accidental.Flat);
    public static readonly Note A = new(9, "A", Accidental.Natural);
    public static readonly Note ASharp = new(10, "A♯", Accidental.Sharp);
    public static readonly Note BFlat = new(10, "B♭", Accidental.Flat);
    public static readonly Note B = new(11, "B", Accidental.Natural);

    public static IReadOnlyList<Note> All = new[]
        {C, CSharp, DFlat, D, DSharp, EFlat, E, F, FSharp, GFlat, G, GSharp, AFlat, A, ASharp, BFlat, B};

    public static Note Get(Pitch pitch, bool preferFlat)
    {
        return pitch.Number switch
        {
            0 => C,
            1 => preferFlat ? DFlat : CSharp,
            2 => D,
            3 => preferFlat ? EFlat : DSharp,
            4 => E,
            5 => F,
            6 => preferFlat ? GFlat : FSharp,
            7 => G,
            8 => preferFlat ? AFlat : GSharp,
            9 => A,
            10 => preferFlat ? BFlat : ASharp,
            11 => B,
            _ => throw new ArgumentException($"Unexpected pitch: {pitch}")
        };
    }

    public Pitch Pitch { get; }
    public string Name { get; }
    public Accidental Accidental { get; }
    public bool IsSharp => Accidental == Accidental.Sharp;
    public bool IsFlat => Accidental == Accidental.Flat;
    public bool HasAlternate => Accidental != Accidental.Natural;

    private Note(Pitch pitch, string name, Accidental accidental)
    {
        Pitch = pitch;
        Name = name;
        Accidental = accidental;
    }

    public Note GetAlternate()
    {
        return Accidental switch
        {
            Accidental.Flat => Get(Pitch, preferFlat: false),
            Accidental.Sharp => Get(Pitch, preferFlat: true),
            Accidental.Natural => this,
            _ => throw new ArgumentOutOfRangeException($"Unexpected accidental: {Accidental}")
        };
    }

    public Note GetNatural()
    {
        return Accidental switch
        {
            Accidental.Flat => Shift(1, preferFlat: false),
            Accidental.Sharp => Shift(-1, preferFlat: false),
            Accidental.Natural => this,
            _ => throw new ArgumentOutOfRangeException($"Unexpected accidental: {Accidental}")
        };
    }

    public Note Shift(int halfSteps, bool preferFlat)
    {
        return Get(Pitch + halfSteps, preferFlat: preferFlat);
    }

    public override string ToString()
    {
        return Name;
    }

    public int CompareTo(Note? other)
    {
        if (other == null) return 1;

        if (Pitch == other.Pitch)
        {
            return Accidental == Accidental.Flat ? 1 : -1;
        }
        else
        {
            return Pitch > other.Pitch ? 1 : -1;
        }
    }

    public static Note operator +(Note root, Interval interval)
    {
        return root.Shift(interval.HalfSteps, preferFlat: root.IsFlat || interval.IsLowered);
    }
}