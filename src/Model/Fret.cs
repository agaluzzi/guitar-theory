namespace GuitarTheory;

public record Fret
{
    public int Number { get; }

    public Fret(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Invalid fret number: " + number);
        }
        Number = number;
    }

    public static Fret operator +(Fret fret, int count)
    {
        return new Fret(fret.Number + count);
    }

    public static implicit operator Fret(int number)
    {
        return new Fret(number);
    }
}