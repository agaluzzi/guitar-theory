namespace GuitarTheory.UI.Support;

public static class ColorScheme
{
    public static Color GetColor(Note note)
    {
        var pitch = note.Pitch.Number;

        const int sharp = 4;
        const int natural = 6;
        const int flat = 8;

        return pitch switch
        {
            0 => C[natural],
            1 => C[sharp],
            2 => D[natural],
            3 => E[flat],
            4 => E[natural],
            5 => F[natural],
            6 => F[sharp],
            7 => G[natural],
            8 => A[flat],
            9 => A[natural],
            10 => B[flat],
            11 => B[natural],

            _ => throw new ArgumentException($"Unexpected pitch: {pitch}")
        };
    }

    private static IReadOnlyList<Color> A => Palette.Red;
    private static IReadOnlyList<Color> B => Palette.Orange;
    private static IReadOnlyList<Color> C => Palette.Yellow;
    private static IReadOnlyList<Color> D => Palette.Green;
    private static IReadOnlyList<Color> E => Palette.Blue;
    private static IReadOnlyList<Color> F => Palette.Indigo;
    private static IReadOnlyList<Color> G => Palette.Purple;
}