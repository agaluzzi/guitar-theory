namespace UnitTests;

public class GuitarTests
{
    [Test]
    public void ShouldGetStrings()
    {
        var guitar = new Guitar(frets: 15);

        guitar.Strings.Should().HaveCount(6);

        ExpectString(index: 0, number: 1, Note.E);
        ExpectString(index: 1, number: 2, Note.B);
        ExpectString(index: 2, number: 3, Note.G);
        ExpectString(index: 3, number: 4, Note.D);
        ExpectString(index: 4, number: 5, Note.A);
        ExpectString(index: 5, number: 6, Note.E);

        void ExpectString(int index, int number, Note note)
        {
            var str = guitar.Strings[index];
            str.Number.Should().Be(number);
            str.OpenNote.Should().Be(note);
            str.GetPitch(12).Should().Be(note.Pitch);
        }
    }

    [Test]
    public void ShouldGetAllFrets()
    {
        const int count = 12;
        var guitar = new Guitar(frets: count);
        guitar.Frets.Should().HaveCount(count + 1); // including the open string (fret 0)
        for (var i = 0; i < count + 1; i++)
        {
            guitar.Frets[i].Number.Should().Be(i);
        }
    }
}