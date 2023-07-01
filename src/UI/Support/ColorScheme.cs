namespace GuitarTheory.UI.Support;

public static class ColorScheme
{
    public static Color GetColor(Note note)
    {
        var hues = note.Letter switch
        {
            'A' => Palette.Red,
            'B' => Palette.Orange,
            'C' => Palette.Yellow,
            'D' => Palette.Green,
            'E' => Palette.Blue,
            'F' => Palette.Indigo,
            'G' => Palette.Purple,
            _ => throw new ArgumentOutOfRangeException("Unexpected note letter " + note.Letter)
        };

        return note.Accidental switch
        {
            Accidental.Sharp => hues[4], // lighter
            Accidental.Natural => hues[6],
            Accidental.Flat => hues[8], // darker
            _ => throw new ArgumentOutOfRangeException("Unexpected accidental: " + note.Accidental)
        };
    }
}