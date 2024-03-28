using Color = System.Drawing.Color;

namespace GuitarTheory.UI.Support;

public static class ColorScheme
{
    public static Color GetColor(Interval interval)
    {
        var hue = interval.Degree switch
        {
            1 or 8 => Palette.Red,
            2 => Palette.Orange,
            3 => Palette.Yellow,
            4 => Palette.Green,
            5 => Palette.LightBlue,
            6 => Palette.Indigo,
            7 => Palette.Purple,
            _ => throw new ArgumentOutOfRangeException($"Unexpected interval degree: {interval.Degree}")
        };

        if (interval.IsLowered)
        {
            return hue.Dark;
        }
        else if (interval.IsRaised)
        {
            return hue.Light;
        }
        else
        {
            return hue.Normal;
        }
    }
}