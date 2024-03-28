using System.Reflection;
using System.Text;
using GuitarTheory.UI.Support;
using Color = System.Drawing.Color;

namespace UnitTests;

public class ColorTests
{
    [Test]
    public void IntervalShouldHaveUniqueColor()
    {
        var mapping = Interval.GetAll()
            .ToDictionary(
                keySelector: interval => interval,
                elementSelector: ColorScheme.GetColor);

        var distinctColors = mapping.Values.Distinct().Count();
        distinctColors.Should().Be(mapping.Count - 1);
        mapping[Interval.Unison].Should().Be(mapping[Interval.Octave]);
    }

    [Test, Explicit]
    public void CreateReport()
    {
        var report = new StringBuilder();
        report.Append("<html><body>");

        report.Append("<h2>Intervals</h2>");
        foreach (var interval in Interval.GetAll())
        {
            var color = ColorScheme.GetColor(interval);
            AppendColor(color, $"{interval.Abbreviation} ~ {interval.Name}");
        }

        report.Append($"<br/><br/>");

        foreach (var field in typeof(Palette)
                     .GetFields(BindingFlags.Public | BindingFlags.Static)
                     .Where(f => f.FieldType == typeof(Hue)))
        {
            var hue = (Hue) field.GetValue(null)!;
            report.Append($"<h2>{field.Name}</h2>");
            AppendColor(hue.ExtraLight, "ExtraLight");
            AppendColor(hue.Light, "Light");
            AppendColor(hue.Normal, "Normal");
            AppendColor(hue.Dark, "Dark");
            AppendColor(hue.ExtraDark, "ExtraDark");
        }

        report.Append("</html></body>");
        var file = "/tmp/guitar_colors.html";
        File.WriteAllText(file, report.ToString());
        Console.WriteLine($"Created: {file}");

        void AppendColor(Color color, string name)
        {
            var mauiColor = color.ToMauiColor();

            report.Append($"<div style=\"" +
                          $"padding:10px;" +
                          $"background-color:{mauiColor.ToHex()};" +
                          $"color:{mauiColor.GetContrastingColor().ToHex()};" +
                          $"width:50%;" +
                          $"font-size:2em;\">" +
                          $"{name}" +
                          $"</div>");
        }
    }
}