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

    private readonly FretboardOverlay overlay;
    private readonly RadioChips<Mode> modeSwitcher;
    private readonly RadioChips<Chord> chordSwitcher;
    private readonly RadioChips<Scale> scaleSwitcher;

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

        modeSwitcher.SelectionChanged += _ => OnSelectionChanged();
        chordSwitcher.SelectionChanged += _ => OnSelectionChanged();
        scaleSwitcher.SelectionChanged += _ => OnSelectionChanged();

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

        var divider = new BoxView {Color = Colors.White};

        this.AddColumn(GridLength.Star, out var modeColumn);
        this.AddColumn(2, out var dividerColumn);
        this.AddColumn(new GridLength(2, GridUnitType.Star), out var typeColumn);

        Add(modeSection.Row(0).Column(modeColumn));
        Add(divider.Row(0).Column(dividerColumn));
        Add(chordSection.Row(0).Column(typeColumn));
        Add(scaleSection.Row(0).Column(typeColumn));
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