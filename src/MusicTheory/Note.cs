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

    public static Note Get(Pitch pitch, Accidental prefer = Accidental.Natural)
    {
        return pitch.Number switch
        {
            0 => C,
            1 => prefer == Accidental.Flat ? DFlat : CSharp,
            2 => D,
            3 => prefer == Accidental.Sharp ? DSharp : EFlat,
            4 => E,
            5 => F,
            6 => prefer == Accidental.Flat ? GFlat : FSharp,
            7 => G,
            8 => prefer == Accidental.Sharp ? GSharp : AFlat,
            9 => A,
            10 => prefer == Accidental.Sharp ? ASharp : BFlat,
            11 => B,
            _ => throw new ArgumentException($"Unexpected pitch: {pitch}")
        };
    }

    public Pitch Pitch { get; }
    public string Name { get; }
    public char Letter => Name[0];
    public Accidental Accidental { get; }
    public bool IsSharp => Accidental == Accidental.Sharp;
    public bool IsFlat => Accidental == Accidental.Flat;
    public bool IsNatural => Accidental == Accidental.Natural;
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
            Accidental.Flat => Get(Pitch, prefer: Accidental.Sharp),
            Accidental.Sharp => Get(Pitch, prefer: Accidental.Flat),
            Accidental.Natural => this,
            _ => throw new ArgumentOutOfRangeException($"Unexpected accidental: {Accidental}")
        };
    }

    public Note Shift(int semitones, Accidental prefer)
    {
        return Get(Pitch + semitones, prefer);
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
        var preference = root.Accidental;
        if (preference == Accidental.Natural && interval.IsLowered)
        {
            preference = Accidental.Flat;
        }
        else if (preference == Accidental.Natural && interval.IsRaised)
        {
            preference = Accidental.Sharp;
        }
        return root.Shift(interval.Semitones, preference);
    }
}