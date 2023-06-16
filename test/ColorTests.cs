using System.Text;
using GuitarTheory.UI.Support;

namespace UnitTests;

public class ColorTests
{
    [Datapoints]
    private static IEnumerable<Note> Notes => Note.All;

    [Theory]
    public void ShouldHaveColor(Note note)
    {
        ColorScheme.GetColor(note).Should().NotBeNull();
    }

    [Test, Explicit]
    public void CreateReport()
    {
        var report = new StringBuilder();
        report.Append("<html><body>");

        foreach (var note in Note.All)
        {
            var color = ColorScheme.GetColor(note);
            AppendColor(color, note.Name);
        }

        foreach (var field in typeof(Palette).GetFields().Where(f => f.IsStatic && f.IsPublic))
        {
            if (field.GetValue(null) is IReadOnlyList<Color> colors)
            {
                report.Append("<br/><br/>");
                for (var i = 0; i < colors.Count; i++)
                {
                    AppendColor(colors[i], $"{field.Name}-{i}");
                }
            }
        }

        report.Append("</html></body>");
        var file = "/tmp/guitar_colors.html";
        File.WriteAllText(file, report.ToString());
        Console.WriteLine($"Created: {file}");

        void AppendColor(Color color, string name)
        {
            report.Append($"<div style=\"" +
                          $"padding:10px;" +
                          $"background-color:{color.ToHex()};" +
                          $"color:{color.GetContrastingColor().ToHex()};" +
                          $"width:50%;" +
                          $"font-size:2em;\">" +
                          $"{name}" +
                          $"</div>");
        }
    }
}