using GuitarTheory.UI.Support;

namespace UnitTests;

public class PaletteTests
{
    private IEnumerable<(string, IReadOnlyList<Color>)> GetColors()
    {
        foreach (var field in typeof(Palette)
                     .GetFields()
                     .Where(f => f.IsStatic && f.IsPublic))
        {
            if (field.GetValue(null) is IReadOnlyList<Color> list)
            {
                yield return (field.Name, list);
            }
        }
    }

    [Test]
    public void ShouldHaveEnoughColorsForChromaticScale()
    {
        GetColors().Count().Should().BeGreaterOrEqualTo(12);
    }

    [Test]
    public void ShouldHaveColorListsOfSameSize()
    {
        foreach (var (_, colors) in GetColors())
        {
            colors.Should().HaveCount(10);
        }
    }
}