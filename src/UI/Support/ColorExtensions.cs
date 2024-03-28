namespace GuitarTheory.UI.Support;

public static class ColorExtensions
{
    public static Color ToMauiColor(this System.Drawing.Color color)
    {
        return new Color(red: color.R, green: color.G, blue: color.B, alpha: color.A);
    }

    public static Color GetContrastingColor(this Color color)
    {
        var r = color.Red * 255;
        var g = color.Green * 255;
        var b = color.Blue * 255;
        var yiq = r * 0.299 + g * 0.587 + b * 0.114;
        return yiq >= 150 ? Colors.Black : Colors.White;
    }
}