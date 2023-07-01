using static GuitarTheory.Accidental;

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
            .Select(pitch => Note.Get(pitch))
            .Select(note => note.Name)
            .Should().Equal("C", "C♯", "D", "E♭", "E", "F", "F♯", "G", "A♭", "A", "B♭", "B");

        Pitch.All
            .Select(pitch => Note.Get(pitch, prefer: Sharp))
            .Select(note => note.Name)
            .Should().Equal("C", "C♯", "D", "D♯", "E", "F", "F♯", "G", "G♯", "A", "A♯", "B");

        Pitch.All
            .Select(pitch => Note.Get(pitch, prefer: Flat))
            .Select(note => note.Name)
            .Should().Equal("C", "D♭", "D", "E♭", "E", "F", "G♭", "G", "A♭", "A", "B♭", "B");
    }

    [Theory]
    public void ShouldShiftZero(Note note)
    {
        note.Shift(0, note.Accidental).Should().Be(note);
    }

    [Theory]
    public void ShouldShiftOctave(Note note)
    {
        note.Shift(12, note.Accidental).Should().Be(note);
    }

    [Test]
    public void ShouldShiftUp()
    {
        Note.C.Shift(1, prefer: Sharp).Should().Be(Note.CSharp);
        Note.C.Shift(1, prefer: Flat).Should().Be(Note.DFlat);

        Note.C.Shift(11, prefer: Natural).Should().Be(Note.B);
        Note.C.Shift(11, prefer: Natural).Should().Be(Note.B);
    }

    [Test]
    public void ShouldShiftDown()
    {
        Note.E.Shift(-1, prefer: Sharp).Should().Be(Note.DSharp);
        Note.E.Shift(-1, prefer: Flat).Should().Be(Note.EFlat);

        Note.E.Shift(-11, prefer: Natural).Should().Be(Note.F);
        Note.E.Shift(-11, prefer: Natural).Should().Be(Note.F);
    }

    [Theory]
    public void ShouldAddIntervalToRoot(Note root)
    {
        (root + Interval.Unison).Should().Be(root);
        (root + Interval.Octave).Should().Be(root);

        (root + Interval.AugmentedFourth).Should().Be(root.Shift(6, prefer: root.IsFlat ? Flat : Sharp));
        (root + Interval.MinorSeventh).Should().Be(root.Shift(10, prefer: root.IsSharp ? Sharp : Flat));
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