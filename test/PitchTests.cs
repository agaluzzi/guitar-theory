namespace UnitTests;

public class PitchTests
{
    [Test]
    public void All()
    {
        Pitch.All.Count.Should().Be(12);
        Pitch.All[0].Name.Should().Be("C");

        for (var i = 0; i < 12; i++)
        {
            var value = (int) Pitch.All[i];
            value.Should().Be(i);
        }
    }

    [Test]
    public void ConvertIntToPitch([Range(0, 11)] int value)
    {
        var pitch = (Pitch) value;
        pitch.Number.Should().Be(value);
        ((int) pitch).Should().Be(value);
    }

    [Test]
    public void ConvertLargeIntToPitch()
    {
        ((Pitch) 12).Number.Should().Be(0);
        ((Pitch) 145).Number.Should().Be(1);
    }

    [Test]
    public void ConvertNegativeIntToPitch()
    {
        ((Pitch) (-1)).Number.Should().Be(11);
        ((Pitch) (-2)).Number.Should().Be(10);
        ((Pitch) (-15)).Number.Should().Be(9);
    }
}