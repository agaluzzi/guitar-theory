namespace GuitarTheory;

public record FingerPosition(InstrumentString String, Fret Fret)
{
    public Pitch Pitch => String.GetPitch(Fret);
}