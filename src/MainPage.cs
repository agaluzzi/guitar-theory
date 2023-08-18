using CommunityToolkit.Maui.Markup;
using GuitarTheory.UI.Support;
using Microsoft.Maui.Layouts;

namespace GuitarTheory;

public class MainPage : ContentPage
{
    private readonly Guitar guitar = new(frets: 13);
    private readonly FretboardOverlay overlay = new();
    private readonly AbsoluteLayout rootLayout = new();

    public MainPage()
    {
        BackgroundColor = Colors.SlateGray;
        Content = rootLayout;
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        rootLayout.Clear();
        rootLayout.Add(BuildLayout().LayoutBounds(0, 0, 1, 1).LayoutFlags(AbsoluteLayoutFlags.SizeProportional));
        base.OnSizeAllocated(width, height);
    }

    private Grid BuildLayout()
    {
        var titleLabel = BuildTitleLabel();
        var chromaticPanel = new ChromaticPanel(overlay);
        var optionPanel = new OptionPanel(overlay);
        var guitarView = new GuitarView(guitar, overlay);

        var layout = new Grid()
            .AddRow(GridLength.Auto, out var titleRow)
            .AddRow(GridLength.Star, out var controlsRow)
            .AddRow(new GridLength(3, GridUnitType.Star), out var guitarRow)
            .AddRow(GridLength.Auto, out var optionsRow);

        layout.Add(titleLabel.Row(titleRow).Column(0));
        layout.Add(chromaticPanel.Row(controlsRow).Column(0));
        layout.Add(optionPanel.Row(optionsRow).Column(0));
        layout.Add(guitarView.Row(guitarRow).Column(0));

        return layout;
    }

    private View BuildTitleLabel()
    {
        var label = new Label
        {
            Text = overlay.Title,
            FontSize = 28,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.White,
        }.TextCenter();
        overlay.Changed += () =>
        {
            label.Text = overlay.Title;
        };
        return label;
    }
}