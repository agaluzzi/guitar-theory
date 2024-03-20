namespace GuitarTheory;

public readonly struct InstrumentString
{
    public int Number { get; }
    public Note OpenNote { get; }

    public InstrumentString(int number, Note openNote)
    {
        if (number < 1)
        {
            throw new ArgumentException("Invalid string number: " + number);
        }
        Number = number;
        OpenNote = openNote;
    }

    public Pitch GetPitch(Fret fret)
    {
        return OpenNote.Pitch + fret.Number;
    }
}