namespace GuitarTheory.UI.Support;

using Color = System.Drawing.Color;

public record Hue
{
    public Color ExtraLight { get; }
    public Color Light { get; }
    public Color Normal { get; }
    public Color Dark { get; }
    public Color ExtraDark { get; }

    public Hue(Color c1, Color c2, Color c3, Color c4, Color c5, Color c6, Color c7, Color c8, Color c9)
    {
        ExtraLight = c1;
        Light = c3;
        Normal = c5;
        Dark = c7;
        ExtraDark = c9;
    }
}