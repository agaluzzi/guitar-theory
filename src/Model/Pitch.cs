namespace GuitarTheory;

/// <summary>
/// Represents a pitch/tone in the 12-tone chromatic scale.
/// Each pitch has a numeric value in the range of 0 to 11.
/// The first pitch (value 0) is a C note, while the last (value 11) is a B.
/// </summary>
public readonly record struct Pitch
{
    public static readonly IReadOnlyList<Pitch> All = new[]
    {
        new Pitch(0, "C"),
        new Pitch(1, "C♯/D♭"),
        new Pitch(2, "D"),
        new Pitch(3, "D♯/E♭"),
        new Pitch(4, "E"),
        new Pitch(5, "F"),
        new Pitch(6, "F♯/G♭"),
        new Pitch(7, "G"),
        new Pitch(8, "G♯/A♭"),
        new Pitch(9, "A"),
        new Pitch(10, "A♯/B♭"),
        new Pitch(11, "B"),
    };

    public int Number { get; }
    public string Name { get; }

    private Pitch(int number, string name)
    {
        Number = number;
        Name = name;
    }

    public static implicit operator Pitch(int value)
    {
        var index = value % 12;
        if (index < 0) index += 12;
        return All[index];
    }

    public static implicit operator int(Pitch pitch) => pitch.Number;

    public static Pitch operator +(Pitch pitch, int pitches)
    {
        return pitch.Number + pitches;
    }

    public static Pitch operator -(Pitch pitch, int pitches)
    {
        return pitch.Number - pitches;
    }
}