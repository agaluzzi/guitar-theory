namespace UnitTests;

public class NoteTests
{
    [Datapoints]
    private static IEnumerable<Note> Notes => Note.All;

    private static IReadOnlySet<string> Letters = new HashSet<string>()
    {
        "A", "B", "C", "D", "E", "F", "G"
    };

    [Test]
    public void ShouldHaveAllNotes()
    {
        var notes = Note.All;
        notes.Should().HaveCount(17);
        notes[0].Name.Should().Be("C");
        notes[0].Pitch.Should().Be((Pitch) 0);
        for (var i = 1; i < 17; i++)
        {
            var note = notes[i];
            var prev = notes[i - 1];
            note.Pitch.Number.Should().BeGreaterOrEqualTo(prev.Pitch.Number);
            note.Should().NotBe(prev);
        }
    }

    [Test]
    public void ShouldHaveProperName()
    {
        foreach (var note in Note.All)
        {
            note.Name[0].Should().BeInRange('A', 'G');
            if (note.IsSharp)
            {
                note.Name.Should().HaveLength(2);
                note.Name[1].Should().Be('♯');
            }
            else if (note.IsFlat)
            {
                note.Name.Should().HaveLength(2);
                note.Name[1].Should().Be('♭');
            }
            else
            {
                note.Name.Should().HaveLength(1);
            }
        }
    }

    [Test]
    public void ShouldGetNoteByPitch()
    {
        Pitch.All
            .Select(pitch => Note.Get(pitch, preferFlat: false))
            .Select(note => note.Name)
            .Should().Equal("C", "C♯", "D", "D♯", "E", "F", "F♯", "G", "G♯", "A", "A♯", "B");

        Pitch.All
            .Select(pitch => Note.Get(pitch, preferFlat: true))
            .Select(note => note.Name)
            .Should().Equal("C", "D♭", "D", "E♭", "E", "F", "G♭", "G", "A♭", "A", "B♭", "B");
    }

    [Theory]
    public void ShouldShiftZero(Note note)
    {
        note.Shift(0, preferFlat: note.IsFlat).Should().Be(note);
    }

    [Theory]
    public void ShouldShiftOctave(Note note)
    {
        note.Shift(12, preferFlat: note.IsFlat).Should().Be(note);
    }

    [Test]
    public void ShouldShiftUp()
    {
        Note.C.Shift(1, preferFlat: false).Should().Be(Note.CSharp);
        Note.C.Shift(1, preferFlat: true).Should().Be(Note.DFlat);

        Note.C.Shift(11, preferFlat: false).Should().Be(Note.B);
        Note.C.Shift(11, preferFlat: true).Should().Be(Note.B);
    }

    [Test]
    public void ShouldShiftDown()
    {
        Note.E.Shift(-1, preferFlat: false).Should().Be(Note.DSharp);
        Note.E.Shift(-1, preferFlat: true).Should().Be(Note.EFlat);

        Note.E.Shift(-11, preferFlat: false).Should().Be(Note.F);
        Note.E.Shift(-11, preferFlat: true).Should().Be(Note.F);
    }

    [Theory]
    public void ShouldAddIntervalToRoot(Note note)
    {
        (note + Interval.Unison).Should().Be(note);
        (note + Interval.Octave).Should().Be(note);

        (note + Interval.MajorThird).Should().Be(note.Shift(4, preferFlat: note.IsFlat));
        (note + Interval.MinorSeventh).Should().Be(note.Shift(10, preferFlat: true));
    }

    [Theory]
    public void ShouldGetAlternate(Note note)
    {
        if (note.HasAlternate)
        {
            var alternate = note.GetAlternate();
            if (note.IsFlat) alternate.IsSharp.Should().BeTrue();
            if (note.IsSharp) alternate.IsFlat.Should().BeTrue();
        }
        else
        {
            note.GetAlternate().Should().Be(note);
        }
    }
}