namespace GuitarTheory;

/// <summary>
/// A note that can be described by its interval relation to a root note.
/// </summary>
public record Tone(Note Note, Interval Interval)
{
    public bool Matches(Pitch pitch)
    {
        return Note.Pitch == pitch;
    }
};