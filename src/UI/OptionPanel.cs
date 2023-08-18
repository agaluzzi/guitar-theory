using CommunityToolkit.Maui.Markup;
using GuitarTheory.UI.Support;

namespace GuitarTheory;

public class OptionPanel : Grid
{
    private enum Mode
    {
        Scales,
        Chords,
        Notes,
    }

    private enum NoteDisplay
    {
        Note,
        Interval,
    }

    private readonly FretboardOverlay overlay;
    private readonly RadioChips<Mode> modeSwitcher;
    private readonly RadioChips<Chord> chordSwitcher;
    private readonly RadioChips<Scale> scaleSwitcher;
    private readonly RadioChips<NoteDisplay> noteDisplaySwitcher;

    public OptionPanel(FretboardOverlay overlay)
    {
        this.overlay = overlay;

        BackgroundColor = Colors.Black.WithAlpha(0.5f);
        Padding = 10;
        ColumnSpacing = 20;

        modeSwitcher = new RadioChips<Mode>
        {
            Options = Enum.GetValues<Mode>().Select(m => (Name: m.ToString(), Value: m)),
            Selected = Mode.Scales,
        };

        chordSwitcher = new RadioChips<Chord>
        {
            Options = Chords.All.Select(chord => (chord.Name, Value: chord)),
        };

        scaleSwitcher = new RadioChips<Scale>
        {
            Options = Scales.All.Select(scale => (scale.Name, Value: scale)),
        };

        noteDisplaySwitcher = new RadioChips<NoteDisplay>
        {
            Options = Enum.GetValues<NoteDisplay>().Select(val => (Name: val.ToString(), Value: val)),
            Selected = NoteDisplay.Note,
        };

        modeSwitcher.SelectionChanged += _ => OnSelectionChanged();
        chordSwitcher.SelectionChanged += _ => OnSelectionChanged();
        scaleSwitcher.SelectionChanged += _ => OnSelectionChanged();
        noteDisplaySwitcher.SelectionChanged += _ => OnSelectionChanged();

        var modeSection = BuildSection("MODE", modeSwitcher);

        var chordSection = BuildSection("CHORD", chordSwitcher)
            .Bind(IsVisibleProperty,
                nameof(modeSwitcher.Selected),
                source: modeSwitcher,
                convert: (Mode mode) => mode == Mode.Chords);

        var scaleSection = BuildSection("SCALE", scaleSwitcher)
            .Bind(IsVisibleProperty,
                nameof(modeSwitcher.Selected),
                source: modeSwitcher,
                convert: (Mode mode) => mode == Mode.Scales);

        var noteDisplaySection = BuildSection("DISPLAY", noteDisplaySwitcher);

        this.AddColumn(GridLength.Star, out var left);
        this.AddColumn(2, out var dividerLeft);
        this.AddColumn(new GridLength(2, GridUnitType.Star), out var middle);
        this.AddColumn(2, out var dividerRight);
        this.AddColumn(GridLength.Star, out var right);

        Add(modeSection.Row(0).Column(left));
        Add(Divider().Row(0).Column(dividerLeft));
        Add(chordSection.Row(0).Column(middle));
        Add(scaleSection.Row(0).Column(middle));
        Add(Divider().Row(0).Column(dividerRight));
        Add(noteDisplaySection.Row(0).Column(right));

        return;

        View Divider() => new BoxView {Color = Colors.White};
    }

    private void OnSelectionChanged()
    {
        var mode = modeSwitcher.Selected;
        switch (mode)
        {
            case Mode.Scales:
                overlay.Pattern = scaleSwitcher.Selected;
                break;
            case Mode.Chords:
                overlay.Pattern = chordSwitcher.Selected;
                break;
            case Mode.Notes:
                overlay.Pattern = new SingleNotePattern();
                break;
            default:
                throw new ArgumentOutOfRangeException("Unexpected mode: " + mode);
        }

        overlay.DisplayInterval = noteDisplaySwitcher.Selected == NoteDisplay.Interval;
    }

    private static View BuildSection(string title, View content)
    {
        return new VerticalStackLayout
        {
            Padding = 10,
            Spacing = 10,
            Children =
            {
                new Label
                {
                    Text = $"◀ {title} ▶",
                    TextColor = Colors.White,
                    FontSize = 12,
                    FontAttributes = FontAttributes.Bold,
                },
                content,
            }
        };
    }
}