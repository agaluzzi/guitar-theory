namespace GuitarTheory;

public record FingerPosition(GuitarString String, Fret Fret)
{
    public Pitch Pitch => String.GetPitch(Fret);
}